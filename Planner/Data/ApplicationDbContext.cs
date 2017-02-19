using Microsoft.EntityFrameworkCore;
using Planner.Models.EventsModel;
using System.Diagnostics.CodeAnalysis;

namespace Planner.Data
{
    [ExcludeFromCodeCoverage]
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Deployment> Deployments { get; set; }

        public virtual DbSet<Email> Emails { get; set; }

        public virtual DbSet<Event> Events { get; set; }

        public virtual DbSet<ExpectedIncident> ExpectedIncidents { get; set; }

        public virtual DbSet<NoGoArea> NoGoAreas { get; set; }

        public virtual DbSet<Note> Notes { get; set; }

        public virtual DbSet<ScheduleItem> ScheduleItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}