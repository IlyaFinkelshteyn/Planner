using Microsoft.EntityFrameworkCore;
using Planner.Models.EventsModel;
using System.Diagnostics.CodeAnalysis;

namespace Planner.Data
{
    /// <summary>
    /// Data context containing all of the events data.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
        /// </summary>
        /// <param name="options">Database context options.</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// The deployments associated with all events.
        /// </summary>
        public virtual DbSet<Deployment> Deployments { get; set; }

        /// <summary>
        /// The email addresses used to send out event emails.
        /// </summary>
        public virtual DbSet<Email> Emails { get; set; }

        /// <summary>
        /// The events registered with the system.
        /// </summary>
        public virtual DbSet<Event> Events { get; set; }

        /// <summary>
        /// The expected incidents associated with all events.
        /// </summary>
        public virtual DbSet<ExpectedIncident> ExpectedIncidents { get; set; }

        /// <summary>
        /// The no-go areas associated with all events.
        /// </summary>
        public virtual DbSet<NoGoArea> NoGoAreas { get; set; }

        /// <summary>
        /// The notes associated with all events.
        /// </summary>
        public virtual DbSet<Note> Notes { get; set; }

        /// <summary>
        /// The schedule items associated with all events
        /// </summary>
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