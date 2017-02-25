using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Planner.Data;
using Planner.Models.EventsModel;
using Planner.Services;
using Ploeh.AutoFixture;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Planner.Tests.Services
{
    public class ScheduleItemServiceTests : SubItemServiceTests<ScheduleItem>
    {
        protected override ItemService<ScheduleItem> CreateService(ApplicationDbContext database)
        {
            return new ScheduleItemService(database);
        }

        protected override ScheduleItem CreateTestItem()
        {
            return Fixture.Create<ScheduleItem>();
        }

        protected override List<ScheduleItem> CreateTestItems()
        {
            return Fixture.CreateMany<ScheduleItem>(10).ToList();
        }

        protected override void EventContainsItem(ApplicationDbContext database, int eventId, int itemId)
        {
            var ev = database.Events.Include(e => e.Schedule).First(e => e.Id == eventId);

            ev.Schedule.Should().Contain(d => d.Id == itemId);
        }

        protected override DbSet<ScheduleItem> GetDbSet(ApplicationDbContext database)
        {
            return database.ScheduleItems;
        }
    }
}