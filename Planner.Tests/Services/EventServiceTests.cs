using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Planner.Data;
using Planner.Models.EventsModel;
using Planner.Services;
using Ploeh.AutoFixture;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using System.Collections.Generic;

namespace Planner.Tests.Services
{
    public class EventServiceTests : ItemServiceTests<Event>
    {
        [Fact]
        public async Task AddInsertsEventIntoDatabase()
        {
            var testEvent = Fixture.Build<Event>().With(e => e.Id, 0).Create();

            var database = CreateDatabase();

            var service = new EventService(database);

            var res = await service.AddAsync(testEvent);

            var insertedItem = await database.Events.FirstOrDefaultAsync(e => e.Name == testEvent.Name);

            insertedItem.Should().Be(testEvent);
            res.Should().Be(insertedItem.Id);
        }

        [Fact]
        public async Task AddNullEventThrowsException()
        {
            Event testEvent = null;

            var database = CreateDatabase();

            var service = new EventService(database);

            try
            {
                await service.AddAsync(testEvent);
                Assert.True(false, "This function should throw.");
            }
            catch (Exception ex)
            {
                ex.Should().BeOfType<ArgumentNullException>();
            }
        }

        [Fact]
        public async Task GetListAfterDateReturnsEvents()
        {
            var events = CreateTestItems();

            var minDate = events.Min(e => e.Date);
            var maxDate = events.Max(e => e.Date);

            var timespan = maxDate - minDate;
            var midDate = minDate.AddMinutes(timespan.TotalMinutes / 2);

            var expectedList = events.Where(e => e.Date >= midDate.Date);

            var database = CreateDatabase();

            database.AddRange(events);
            database.SaveChanges();

            var service = new EventService(database);

            var actualList = await service.GetListAsync(midDate);

            actualList.Should().BeEquivalentTo(expectedList);
        }

        protected override ItemService<Event> CreateService(ApplicationDbContext database)
        {
            return new EventService(database);
        }

        protected override Event CreateTestItem()
        {
            return Fixture.Build<Event>().Without(e => e.Deployments).Without(e => e.ExpectedIncidents).Without(e => e.NoGoAreas)
                .Without(e => e.Notes).Without(e => e.Schedule).Create();
        }

        protected override List<Event> CreateTestItems()
        {
            return Fixture.Build<Event>().Without(e => e.Deployments).Without(e => e.ExpectedIncidents).Without(e => e.NoGoAreas)
                .Without(e => e.Notes).Without(e => e.Schedule).CreateMany(10).ToList();
        }

        protected override DbSet<Event> GetDbSet(ApplicationDbContext database)
        {
            return database.Events;
        }
    }
}