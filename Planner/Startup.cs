using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.IdentityModel.Tokens;
using Planner.Data;
using Planner.Middleware;
using Planner.Models;
using Planner.Services;
using Planner.Services.Filters;
using Planner.Services.Interfaces;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;

namespace Planner
{
    [ExcludeFromCodeCoverage]
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets<Startup>();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                context.Database.Migrate();
                if (env.IsDevelopment())
                    context.EnsureSeedData();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();

            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["JwtSecretKey"]));

            var options = new TokenProviderOptions
            {
                Audience = Configuration["TokenAudience"],
                Issuer = Configuration["TokenIssuer"],
                SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256),
            };

            app.UseMiddleware<TokenProviderMiddleware>(Options.Create(options));

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,
                ValidateIssuer = true,
                ValidIssuer = Configuration["TokenIssuer"],
                ValidateAudience = true,
                ValidAudience = Configuration["TokenAudience"],
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };

            app.UseJwtBearerAuthentication(new JwtBearerOptions
            {
                AutomaticAuthenticate = true,
                AutomaticChallenge = true,
                TokenValidationParameters = tokenValidationParameters
            });
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AutomaticAuthenticate = true,
                AutomaticChallenge = true,
                AuthenticationScheme = "Cookie",
                CookieName = "access_token",
                TicketDataFormat = new CustomJwtDataFormat(SecurityAlgorithms.HmacSha256, tokenValidationParameters)
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseSwagger();
            app.UseSwaggerUi(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Planner API v1");
            });
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddMvc();

            services.AddLogging();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Planner API", Version = "v1" });

                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath, "Planner.xml");
                c.IncludeXmlComments(xmlPath);

                c.OperationFilter<AuthResponseOperationFilter>();
            });

            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();

            services.AddTransient<IApiDescriptionProvider, ExtendedApiDescriptionProvider>();

            services.AddTransient<IEventService, EventService>();
        }
    }
}