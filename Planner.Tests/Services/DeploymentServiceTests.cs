using Microsoft.EntityFrameworkCore;
using Planner.Data;
using Planner.Models.EventsModel;
using Planner.Services;
using System;
using System.Collections.Generic;
using Ploeh.AutoFixture;
using System.Linq;
using FluentAssertions;

namespace Planner.Tests.Services
{
    public class DeploymentServiceTests : SubItemServiceTests<Deployment>
    {
        protected override ItemService<Deployment> CreateService(ApplicationDbContext database)
        {
            return new DeploymentService(database);
        }

        protected override Deployment CreateTestItem()
        {
            return Fixture.Create<Deployment>();
        }

        protected override List<Deployment> CreateTestItems()
        {
            return Fixture.CreateMany<Deployment>(10).ToList();
        }

        protected override void EventContainsItem(ApplicationDbContext database, int eventId, int itemId)
        {
            var ev = database.Events.Include(e => e.Deployments).First(e => e.Id == eventId);

            ev.Deployments.Should().Contain(d => d.Id == itemId);
        }

        protected override DbSet<Deployment> GetDbSet(ApplicationDbContext database)
        {
            return database.Deployments;
        }
    }
}