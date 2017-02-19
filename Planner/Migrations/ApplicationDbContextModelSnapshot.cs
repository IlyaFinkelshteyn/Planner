using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Planner.Data;
using Planner.Models.EventsModel;

namespace Planner.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Planner.Models.EventsModel.Deployment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Callsign");

                    b.Property<int?>("CyclingLevel");

                    b.Property<int?>("EventId");

                    b.Property<string>("Name");

                    b.Property<int?>("Qualification");

                    b.Property<int>("Team");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("Deployments");
                });

            modelBuilder.Entity("Planner.Models.EventsModel.Email", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<bool>("WideList");

                    b.HasKey("Id");

                    b.ToTable("Emails");
                });

            modelBuilder.Entity("Planner.Models.EventsModel.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AmbulancesAvailable");

                    b.Property<bool>("BriefingNotesSent");

                    b.Property<string>("ControlPhoneNumber");

                    b.Property<DateTime>("Created");

                    b.Property<string>("CreatedBy");

                    b.Property<bool>("CruTrackingInUse");

                    b.Property<int>("CyclistsRequested");

                    b.Property<DateTime>("Date");

                    b.Property<bool>("DateConfirmed");

                    b.Property<string>("Description");

                    b.Property<int>("DipsNumber");

                    b.Property<bool>("DoctorsPresent");

                    b.Property<TimeSpan>("EndTime");

                    b.Property<bool>("ExpectingBadWeather");

                    b.Property<string>("FallbackRadioChannel");

                    b.Property<int>("FirstAidUnitsAvailable");

                    b.Property<int>("FirstAidersAvailable");

                    b.Property<bool>("HasSeriousHistory");

                    b.Property<bool>("HighSpeedRoadsAtEvent");

                    b.Property<DateTime>("LastEmailedOut");

                    b.Property<DateTime>("LastUpdated");

                    b.Property<string>("Location");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<bool>("ParamedicsAvailable");

                    b.Property<string>("PostCode");

                    b.Property<string>("RadioChannel");

                    b.Property<bool>("SoloRespondingExpected");

                    b.Property<TimeSpan>("StartTime");

                    b.Property<int>("Status");

                    b.Property<string>("UpdatedBy");

                    b.Property<bool>("UsingAirwave");

                    b.Property<bool>("UsingSJARadio");

                    b.Property<bool>("WiderDistribution");

                    b.HasKey("Id");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Planner.Models.EventsModel.ExpectedIncident", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("EventId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("ExpectedIncidents");
                });

            modelBuilder.Entity("Planner.Models.EventsModel.NoGoArea", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("EventId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("NoGoAreas");
                });

            modelBuilder.Entity("Planner.Models.EventsModel.Note", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("EventId");

                    b.Property<int>("SortNumber");

                    b.Property<string>("Text")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("Planner.Models.EventsModel.ScheduleItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Action")
                        .IsRequired();

                    b.Property<int?>("EventId");

                    b.Property<TimeSpan>("Time");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("ScheduleItems");
                });

            modelBuilder.Entity("Planner.Models.EventsModel.Deployment", b =>
                {
                    b.HasOne("Planner.Models.EventsModel.Event")
                        .WithMany("Deployments")
                        .HasForeignKey("EventId");
                });

            modelBuilder.Entity("Planner.Models.EventsModel.ExpectedIncident", b =>
                {
                    b.HasOne("Planner.Models.EventsModel.Event")
                        .WithMany("ExpectedIncidents")
                        .HasForeignKey("EventId");
                });

            modelBuilder.Entity("Planner.Models.EventsModel.NoGoArea", b =>
                {
                    b.HasOne("Planner.Models.EventsModel.Event")
                        .WithMany("NoGoAreas")
                        .HasForeignKey("EventId");
                });

            modelBuilder.Entity("Planner.Models.EventsModel.Note", b =>
                {
                    b.HasOne("Planner.Models.EventsModel.Event")
                        .WithMany("Notes")
                        .HasForeignKey("EventId");
                });

            modelBuilder.Entity("Planner.Models.EventsModel.ScheduleItem", b =>
                {
                    b.HasOne("Planner.Models.EventsModel.Event")
                        .WithMany("Schedule")
                        .HasForeignKey("EventId");
                });
        }
    }
}
