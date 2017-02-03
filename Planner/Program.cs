using Microsoft.AspNetCore.Hosting;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace Planner
{
    [ExcludeFromCodeCoverage]
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .UseApplicationInsights()
                .Build();

            host.Run();
        }
    }
}