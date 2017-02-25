using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Planner.Data;
using Planner.Models.EventsModel;
using Planner.Models.EventsModel.Interfaces;
using Planner.Services;
using Planner.Services.Exceptions;
using Ploeh.AutoFixture;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Planner.Tests.Services
{
    public abstract class SubItemServiceTests<T> : ItemServiceTests<T>
          where T : class, IIdentifiable
    {
        [Fact]
        public async Task AddBadEventIdThrowsException()
        {
            var testItem = CreateTestItem();

            var database = CreateDatabase();

            var service = CreateService(database) as SubItemService<T>;

            try
            {
                await service.AddAsync(Fixture.Create<int>(), testItem);
                Assert.True(false, "This function should throw.");
            }
            catch (Exception ex)
            {
                ex.Should().BeOfType<IdNotFoundException>();
            }
        }

        [Fact]
        public async Task AddInsertsItemIntoDatabase()
        {
            var database = CreateDatabase();
            var dataset = GetDbSet(database);

            var testEvent = Fixture.Build<Event>().With(e => e.Id, 0)
                .Without(e => e.Deployments).Without(e => e.ExpectedIncidents)
                .Without(e => e.NoGoAreas).Without(e => e.Notes)
                .Without(e => e.Schedule).Create();

            database.Events.Add(testEvent);
            database.SaveChanges();

            var testItem = CreateTestItem();
            testItem.Id = 0;

            var service = CreateService(database) as SubItemService<T>;

            var res = await service.AddAsync(testEvent.Id, testItem);

            var insertedItem = await dataset.FirstOrDefaultAsync(e => e.Id == res);

            insertedItem.Should().Be(testItem);

            EventContainsItem(database, testEvent.Id, res);
        }

        [Fact]
        public async Task AddNullItemThrowsException()
        {
            T testItem = null;

            var database = CreateDatabase();

            var testEvent = Fixture.Build<Event>().With(e => e.Id, 0)
                .Without(e => e.Deployments).Without(e => e.ExpectedIncidents)
                .Without(e => e.NoGoAreas).Without(e => e.Notes)
                .Without(e => e.Schedule).Create();

            database.Events.Add(testEvent);
            database.SaveChanges();

            var service = CreateService(database) as SubItemService<T>;

            try
            {
                await service.AddAsync(testEvent.Id, testItem);
                Assert.True(false, "This function should throw.");
            }
            catch (Exception ex)
            {
                ex.Should().BeOfType<ArgumentNullException>().Which.ParamName.Should().Be("item");
            }
        }

        protected abstract void EventContainsItem(ApplicationDbContext database, int eventId, int itemId);
    }
}