using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Planner.Data;
using Planner.Models.EventsModel;
using Planner.Services;
using Ploeh.AutoFixture;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Planner.Tests.Services
{
    public class EventServiceTests
    {
        private Fixture _fixture = new Fixture();

        [Fact]
        public async Task AddInsertsEventIntoDatabase()
        {
            var testEvent = _fixture.Build<Event>().With(e => e.Id, 0).Create();

            var dbOptions = new DbContextOptionsBuilder<ApplicationDbContext>();
            dbOptions.UseInMemoryDatabase();

            var database = new ApplicationDbContext(dbOptions.Options);

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

            var dbOptions = new DbContextOptionsBuilder<ApplicationDbContext>();
            dbOptions.UseInMemoryDatabase();

            var database = new ApplicationDbContext(dbOptions.Options);

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
    }
}