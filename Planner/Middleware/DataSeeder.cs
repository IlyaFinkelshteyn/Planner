using LoremNET;
using Planner.Data;
using Planner.Models.EventsModel;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Planner.Middleware
{
    [ExcludeFromCodeCoverage]
    public static class DataSeeder
    {
        public static void EnsureSeedData(this ApplicationDbContext context)
        {
            if (!context.Events.Any())
            {
                var testData = Enumerable.Range(0, 25).Select(id => new Event
                {
                    Date = DateTime.Today.AddDays(id),
                    Name = $"Test Event {id}",
                    DipsNumber = 1000 + id,
                    StartTime = TimeSpan.FromHours(id % 24),
                    EndTime = TimeSpan.FromHours((id + 5) % 24),
                    Location = $"Test Location {id}",
                    PostCode = $"BS{id % 31 + 1} {id % 5}AB",
                    Description = Lorem.Paragraph(5, 10, 2, 8),
                    Schedule = Enumerable.Range(0, 5).Select(i => new ScheduleItem { Time = TimeSpan.FromHours(i), Action = Lorem.Words(1, 4, includePunctuation: true) }).ToList(),
                    AmbulancesAvailable = id,
                    FirstAidersAvailable = id * 3,
                    FirstAidUnitsAvailable = id / 3,
                    CyclistsRequested = id % 6,
                    ParamedicsAvailable = id % 2 == 0,
                    DoctorsPresent = id % 6 == 0,
                    SoloRespondingExpected = (id % 5 == 0),
                    HighSpeedRoadsAtEvent = (id % 11 == 0),
                    ExpectingBadWeather = (id % 14 == 0),
                    HasSeriousHistory = (id % 8 == 0),
                    Notes = Enumerable.Range(0, id % 5).Select(i => new Note { Text = Lorem.Paragraph(5, 10, 2, 8), SortNumber = i }).ToList(),
                    NoGoAreas = Enumerable.Range(0, id % 5).Select(i => new NoGoArea { Name = Lorem.Words(2) }).ToList(),
                    Deployments = Enumerable.Range(1, 3).SelectMany(i => Enumerable.Range(0, i).Select(j => new Deployment
                    {
                        Callsign = $"WR{920 + i * 5 + j}",
                        CyclingLevel = Lorem.Enum<CyclingLevel>(),
                        Name = $"{Lorem.Words(1)} {char.ToUpper(Lorem.Letter())}",
                        Qualification = Lorem.Enum<Qualification>(),
                        Team = i
                    })).ToList(),
                    ExpectedIncidents = Enumerable.Range(0, id % 10).Select(i => new ExpectedIncident { Name = Lorem.Words(1, 4) }).ToList(),
                    ControlPhoneNumber = "023 92 123 456",
                    CruTrackingInUse = (id % 6 == 0),
                    FallbackRadioChannel = (id % 7 == 0) ? $"NSJ{id % 31 + 1}" : "",
                    RadioChannel = $"SJA{id % 6 + 1}",
                    UsingAirwave = (id % 13 == 0),
                    UsingSJARadio = (id % 7 == 0),
                    Status = Lorem.Enum<EventStatus>(),
                    BriefingNotesSent = Lorem.Chance(1, 5),
                    Created = DateTime.Today.AddDays(-id),
                    CreatedBy = Lorem.Email(),
                    DateConfirmed = Lorem.Chance(9, 10),
                    LastEmailedOut = DateTime.Today.AddDays(-id * 3),
                    LastUpdated = DateTime.Today.AddDays(-id + 2),
                    UpdatedBy = Lorem.Email(),
                    WiderDistribution = Lorem.Chance(1, 10)
                });

                context.Events.AddRange(testData);
                context.SaveChanges();
            }
        }
    }
}