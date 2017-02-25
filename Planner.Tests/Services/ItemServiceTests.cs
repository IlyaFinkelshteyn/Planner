using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Planner.Data;
using Planner.Models.EventsModel.Interfaces;
using Planner.Services;
using Planner.Services.Exceptions;
using Ploeh.AutoFixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Planner.Tests.Services
{
    public abstract class ItemServiceTests<T>
        where T : class, IIdentifiable
    {
        protected Fixture Fixture { get; } = new Fixture();

        [Fact]
        public async Task DeleteRemovesItemFromDatabase()
        {
            var items = CreateTestItems();
            var database = CreateDatabase();
            var dataset = GetDbSet(database);

            database.AddRange(items);
            database.SaveChanges();

            var testId = items.First().Id;

            dataset.Should().Contain(i => i.Id == testId);

            var service = CreateService(database);

            await service.DeleteAsync(testId);

            dataset.Should().NotContain(i => i.Id == testId);
        }

        [Fact]
        public async Task DeleteWithInvalidIdDoesNotThrowError()
        {
            var items = CreateTestItems();
            var database = CreateDatabase();
            var dataset = GetDbSet(database);

            database.AddRange(items);
            database.SaveChanges();

            var testId = items.Max(i => i.Id) + Fixture.Create<int>();

            dataset.Should().NotContain(i => i.Id == testId);

            var service = CreateService(database);

            await service.DeleteAsync(testId);

            dataset.Should().NotContain(i => i.Id == testId);
        }

        [Fact]
        public async Task GetReturnsItemFromDatabase()
        {
            var items = CreateTestItems();
            var database = CreateDatabase();
            var dataset = GetDbSet(database);

            database.AddRange(items);
            database.SaveChanges();

            var testId = items.First().Id;

            var testItem = dataset.First(i => i.Id == testId);

            var service = CreateService(database);

            var res = await service.GetAsync(testId);

            res.Should().Be(testItem);
        }

        [Fact]
        public async Task GetWithInvalidIdReturnsNullDatabase()
        {
            var items = CreateTestItems();
            var database = CreateDatabase();
            var dataset = GetDbSet(database);

            database.AddRange(items);
            database.SaveChanges();

            var testId = items.Max(i => i.Id) + Fixture.Create<int>();

            var service = CreateService(database);

            var res = await service.GetAsync(testId);

            res.Should().BeNull();
        }

        [Fact]
        public async Task UpdateInvalidIdThrowsInvalidKey()
        {
            var items = CreateTestItems();
            var database = CreateDatabase();
            var dataset = GetDbSet(database);

            database.AddRange(items);
            database.SaveChanges();

            var testId = items.Max(i => i.Id) + Fixture.Create<int>();

            foreach (var i in items)
            {
                database.Entry(i).State = EntityState.Detached;
            }

            var testItem = CreateTestItem();
            testItem.Id = testId;

            var service = CreateService(database);

            try
            {
                await service.UpdateAsync(testItem);
                Assert.True(false, "The update operation should have thrown.");
            }
            catch (Exception ex)
            {
                ex.Should().BeOfType<IdNotFoundException>();
            }
        }

        [Fact]
        public async Task UpdatePassesChangeIntoDatbase()
        {
            var items = CreateTestItems();
            var database = CreateDatabase();
            var dataset = GetDbSet(database);

            database.AddRange(items);
            database.SaveChanges();

            var testId = items.First().Id;

            foreach (var i in items)
            {
                database.Entry(i).State = EntityState.Detached;
            }

            var testItem = CreateTestItem();
            testItem.Id = testId;

            var service = CreateService(database);

            await service.UpdateAsync(testItem);

            var updatedItem = dataset.First(i => i.Id == testId);

            updatedItem.Should().Be(testItem);
        }

        [Fact]
        public async Task UpdateWithNullThrowsArgumentNullException()
        {
            var database = CreateDatabase();
            var service = CreateService(database);

            try
            {
                await service.UpdateAsync(null);
                Assert.True(false, "The update operation should have thrown.");
            }
            catch (Exception ex)
            {
                ex.Should().BeOfType<ArgumentNullException>().Which.ParamName.Should().Be("item");
            }
        }

        protected ApplicationDbContext CreateDatabase()
        {
            var dbOptions = new DbContextOptionsBuilder<ApplicationDbContext>();
            dbOptions.UseInMemoryDatabase(Fixture.Create<string>());

            var database = new ApplicationDbContext(dbOptions.Options);
            database.Database.EnsureDeleted();
            database.Database.EnsureCreated();

            return database;
        }

        protected abstract ItemService<T> CreateService(ApplicationDbContext database);

        protected abstract T CreateTestItem();

        protected abstract List<T> CreateTestItems();

        protected abstract DbSet<T> GetDbSet(ApplicationDbContext database);
    }
}