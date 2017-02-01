using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Planner.Controllers.Api;
using Planner.Controllers.Api.Results;
using Planner.Models.EventsModel.Interfaces;
using Planner.Models.EventsViewModels.Interfaces;
using Planner.Services.Exceptions;
using Planner.Services.Interfaces;
using Planner.Tests.Helpers;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Xunit2;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Planner.Tests.Controllers.Api
{
    public abstract class SubItemControllerTestsBase<TController, TModel, TCreate, TDetail>
        where TController : SubItemControllerBase<TModel, TCreate, TDetail>
        where TModel : class, IIdentifiable, ICloneable, IDetailable<TDetail>
        where TCreate : ICreateViewModel<TModel>
    {
        protected Fixture Fixture { get; } = new Fixture();

        [Theory, AutoData]
        public async Task DeleteItemReturnsNoContent(int id)
        {
            var service = new Mock<ISubItemService<TModel>>(MockBehavior.Strict);
            service.Setup(s => s.DeleteAsync(id)).ReturnsEmptyTask();

            var controller = GetController(service.Object);

            var result = await controller.Delete(id);

            result.Should().NotBeNull().And.BeOfType<NoContentResult>();

            service.VerifyAll();
        }

        [Theory, AutoData]
        public async Task GetItemInvalidIdReturnsNotFound(int id)
        {
            var service = new Mock<ISubItemService<TModel>>(MockBehavior.Strict);
            service.Setup(s => s.GetAsync(id)).ReturnsAsync(null);

            var controller = GetController(service.Object);

            var result = await controller.Get(id);

            result.Should().NotBeNull().And.BeOfType<NotFoundResult>();

            service.VerifyAll();
        }

        [Theory, AutoData]
        public async Task GetItemValidIdReturnsOk(int id, TModel item)
        {
            var service = new Mock<ISubItemService<TModel>>(MockBehavior.Strict);
            service.Setup(s => s.GetAsync(id)).ReturnsAsync(item);

            var expected = item.ToDetail();

            var controller = GetController(service.Object);

            var result = await controller.Get(id);

            result.Should().NotBeNull().And.BeOfType<OkObjectResult>().Which.Value.Should().Be(expected);

            service.VerifyAll();
        }

        [Theory, AutoData]
        public async Task PatchInvalidItemIdReturnsNotFound(int id)
        {
            var service = new Mock<ISubItemService<TModel>>(MockBehavior.Strict);

            var patch = GetPatch();

            service.Setup(s => s.GetAsync(id)).ReturnsAsync(null);

            var controller = GetController(service.Object);

            var result = await controller.Patch(id, patch);

            result.Should().NotBeNull().And.BeOfType<NotFoundResult>();

            service.VerifyAll();
        }

        [Theory, AutoData]
        public async Task PatchInvalidItemReturnsNoContent(int id, TModel model)
        {
            var service = new Mock<ISubItemService<TModel>>(MockBehavior.Strict);

            var patch = GetPatch();

            service.Setup(s => s.GetAsync(id)).ReturnsAsync(model);

            var controller = GetController(service.Object);

            controller.ModelState.AddModelError("", "Invalid Patch");

            var result = await controller.Patch(id, patch);

            result.Should().NotBeNull().And.BeOfType<BadRequestObjectResult>();

            service.VerifyAll();
        }

        [Theory, AutoData]
        public async Task PatchValidItemReturnsNoContent(int id, TModel model)
        {
            var service = new Mock<ISubItemService<TModel>>(MockBehavior.Strict);

            var patch = GetPatch();
            var originalModel = (TModel)model.Clone();
            patch.ApplyTo(model);

            service.Setup(s => s.GetAsync(id)).ReturnsAsync(originalModel);
            service.Setup(s => s.UpdateAsync(It.Is<TModel>(m => m.Equals(model)))).ReturnsEmptyTask();

            var controller = GetController(service.Object);

            var result = await controller.Patch(id, patch);

            result.Should().NotBeNull().And.BeOfType<OkObjectResult>();

            var res = (OkObjectResult)result;

            res.Value.Should().Be(model);

            service.VerifyAll();
        }

        [Theory, AutoData]
        public async Task PostInvalidEventIdCallsServiceAndReturnsBadRequest(int eventId, TCreate createModel)
        {
            var service = new Mock<ISubItemService<TModel>>(MockBehavior.Strict);
            service.Setup(s => s.AddAsync(eventId, It.IsAny<TModel>())).Throws<EventNotFoundException>();

            var controller = GetController(service.Object);

            var result = await controller.Post(eventId, createModel);

            result.Should().NotBeNull().And.BeOfType<BadRequestObjectResult>();

            service.VerifyAll();
        }

        [Theory, AutoData]
        public async Task PostInvalidItemDoesNotCallServiceAndReturnsBadRequest(int eventId, TCreate createModel)
        {
            var controller = GetController(null);

            controller.ModelState.AddModelError("", "Model is invalid");

            var result = await controller.Post(eventId, createModel);

            result.Should().NotBeNull().And.BeOfType<BadRequestObjectResult>();
        }

        [Theory, AutoData]
        public async Task PostValidEventIdCallsServiceAndReturnsCreated(int eventId, TCreate createModel, int newId)
        {
            var service = new Mock<ISubItemService<TModel>>(MockBehavior.Strict);

            var model = createModel.ToItem();

            service.Setup(s => s.AddAsync(eventId, It.Is<TModel>(m => model.Equals(m)))).ReturnsAsync(newId);

            var controller = GetController(service.Object);

            var helper = new Mock<IUrlHelper>(MockBehavior.Strict);

            controller.Url = helper.Object;

            var result = await controller.Post(eventId, createModel);

            result.Should().NotBeNull().And.BeOfType<CreatedAtActionResult>();

            var res = (CreatedAtActionResult)result;

            res.ControllerName.Should().BeNullOrEmpty();
            res.ActionName.Should().Be("Get");
            res.RouteValues.Should().NotBeNull().And.Contain(new[] { new KeyValuePair<string, object>("id", newId) });
            res.Value.Should().NotBeNull().And.BeOfType<IdResult>().Which.Id.Should().Be(newId);

            service.VerifyAll();
        }

        protected abstract TController GetController(ISubItemService<TModel> service);

        protected abstract JsonPatchDocument<TModel> GetPatch();
    }
}