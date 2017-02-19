using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Planner.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Emails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    WideList = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AmbulancesAvailable = table.Column<int>(nullable: false),
                    BriefingNotesSent = table.Column<bool>(nullable: false),
                    ControlPhoneNumber = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CruTrackingInUse = table.Column<bool>(nullable: false),
                    CyclistsRequested = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    DateConfirmed = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    DipsNumber = table.Column<int>(nullable: false),
                    DoctorsPresent = table.Column<bool>(nullable: false),
                    EndTime = table.Column<TimeSpan>(nullable: false),
                    ExpectingBadWeather = table.Column<bool>(nullable: false),
                    FallbackRadioChannel = table.Column<string>(nullable: true),
                    FirstAidUnitsAvailable = table.Column<int>(nullable: false),
                    FirstAidersAvailable = table.Column<int>(nullable: false),
                    HasSeriousHistory = table.Column<bool>(nullable: false),
                    HighSpeedRoadsAtEvent = table.Column<bool>(nullable: false),
                    LastEmailedOut = table.Column<DateTime>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    ParamedicsAvailable = table.Column<bool>(nullable: false),
                    PostCode = table.Column<string>(nullable: true),
                    RadioChannel = table.Column<string>(nullable: true),
                    SoloRespondingExpected = table.Column<bool>(nullable: false),
                    StartTime = table.Column<TimeSpan>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UsingAirwave = table.Column<bool>(nullable: false),
                    UsingSJARadio = table.Column<bool>(nullable: false),
                    WiderDistribution = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Deployments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Callsign = table.Column<string>(nullable: true),
                    CyclingLevel = table.Column<int>(nullable: true),
                    EventId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Qualification = table.Column<int>(nullable: true),
                    Team = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deployments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deployments_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExpectedIncidents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EventId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpectedIncidents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpectedIncidents_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NoGoAreas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EventId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoGoAreas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NoGoAreas_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EventId = table.Column<int>(nullable: true),
                    SortNumber = table.Column<int>(nullable: false),
                    Text = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notes_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Action = table.Column<string>(nullable: false),
                    EventId = table.Column<int>(nullable: true),
                    Time = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduleItems_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Deployments_EventId",
                table: "Deployments",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpectedIncidents_EventId",
                table: "ExpectedIncidents",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_NoGoAreas_EventId",
                table: "NoGoAreas",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_EventId",
                table: "Notes",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleItems_EventId",
                table: "ScheduleItems",
                column: "EventId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Deployments");

            migrationBuilder.DropTable(
                name: "Emails");

            migrationBuilder.DropTable(
                name: "ExpectedIncidents");

            migrationBuilder.DropTable(
                name: "NoGoAreas");

            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "ScheduleItems");

            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
