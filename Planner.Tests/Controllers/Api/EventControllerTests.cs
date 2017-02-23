using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Planner.Controllers.Api;
using Planner.Controllers.Api.Results;
using Planner.Models.EventsModel;
using Planner.Models.EventsViewModels;
using Planner.Services.Interfaces;
using Planner.Tests.Helpers;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Xunit2;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using System;
using System.Linq;

namespace Planner.Tests.Controllers.Api
{
    public class EventControllerTests : ItemsControllerTestsBase<EventsController, Event, EventDetails>
    {
        [Theory, AutoData]
        public async Task GetAllIncludingHistoricReturnsEventSummaries(IEnumerable<Event> events)
        {
            var service = new Mock<IEventService>(MockBehavior.Strict);

            service.Setup(e => e.GetListAsync(DateTime.MinValue)).ReturnsAsync(events);

            var controller = GetController(service.Object);

            var result = await controller.GetAll(includeHistoric: true);

            var expected = events.Select(e => new EventSummary(e));

            result.Should().NotBeNull().And.BeOfType<OkObjectResult>()
                .Which.Value.Should().BeAssignableTo<IEnumerable<EventSummary>>()
                .Which.Should().BeEquivalentTo(expected);

            service.VerifyAll();
        }

        [Theory, AutoData]
        public async Task GetAllReturnsEventSummaries(IEnumerable<Event> events)
        {
            var service = new Mock<IEventService>(MockBehavior.Strict);

            service.Setup(e => e.GetListAsync(DateTime.Today)).ReturnsAsync(events);

            var controller = GetController(service.Object);

            var result = await controller.GetAll();

            var expected = events.Select(e => new EventSummary(e));

            result.Should().NotBeNull().And.BeOfType<OkObjectResult>()
                .Which.Value.Should().BeAssignableTo<IEnumerable<EventSummary>>()
                .Which.Should().BeEquivalentTo(expected);

            service.VerifyAll();
        }

        [Theory, AutoData]
        public async Task PostInvalidItemDoesNotCallServiceAndReturnsBadRequest(EventCreate createModel)
        {
            var controller = GetController(null);

            controller.ModelState.AddModelError("", "Model is invalid");

            var result = await controller.Post(createModel);

            result.Should().NotBeNull().And.BeOfType<BadRequestObjectResult>();
        }

        [Theory, AutoData]
        public async Task PostValidModelCallsServiceAndReturnsCreated(EventCreate createModel, int newId)
        {
            var service = new Mock<IEventService>(MockBehavior.Strict);

            var model = createModel.ToItem();

            service.Setup(s => s.AddAsync(It.Is<Event>(m => model.Equals(m)))).ReturnsAsync(newId);

            var controller = GetController(service.Object);

            var helper = new Mock<IUrlHelper>(MockBehavior.Strict);

            controller.Url = helper.Object;

            var result = await controller.Post(createModel);

            result.Should().NotBeNull().And.BeOfType<CreatedAtActionResult>();

            var res = (CreatedAtActionResult)result;

            res.ControllerName.Should().BeNullOrEmpty();
            res.ActionName.Should().Be("Get");
            res.RouteValues.Should().NotBeNull().And.Contain(new[] { new KeyValuePair<string, object>("id", newId) });
            res.Value.Should().NotBeNull().And.BeOfType<IdResult>().Which.Id.Should().Be(newId);

            service.VerifyAll();
        }

        protected override EventsController GetController(IItemService<Event> service)
        {
            return new EventsController(service as IEventService, null);
        }

        protected override JsonPatchDocument<Event> GetPatch()
        {
            var patch = new JsonPatchDocument<Event>();

            var testName = Fixture.Create<string>();

            patch.Replace(e => e.Name, testName);

            return patch;
        }

        protected override void SetupService(Mock<IItemService<Event>> mock)
        {
            mock.As<IEventService>();
        }
    }
}