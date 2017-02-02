using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Planner.Controllers.Api;
using Planner.Models.EventsModel.Interfaces;
using Planner.Services.Interfaces;
using Planner.Tests.Helpers;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Xunit2;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Planner.Tests.Controllers.Api
{
    public abstract class ItemsControllerTestsBase<TController, TModel, TDetails>
        where TController : ItemsControllerBase<TModel, TDetails>
        where TModel : class, IDetailable<TDetails>, ICloneable
    {
        protected Fixture Fixture { get; } = new Fixture();

        [Theory, AutoData]
        public async Task DeleteItemReturnsNoContent(int id)
        {
            var service = new Mock<IItemService<TModel>>(MockBehavior.Strict);
            SetupService(service);
            service.Setup(s => s.DeleteAsync(id)).ReturnsEmptyTask();

            var controller = GetController(service.Object);

            var result = await controller.Delete(id);

            result.Should().NotBeNull().And.BeOfType<NoContentResult>();

            service.VerifyAll();
        }

        [Theory, AutoData]
        public async Task GetItemInvalidIdReturnsNotFound(int id)
        {
            var service = new Mock<IItemService<TModel>>(MockBehavior.Strict);
            SetupService(service);
            service.Setup(s => s.GetAsync(id)).ReturnsAsync(null);

            var controller = GetController(service.Object);

            var result = await controller.Get(id);

            result.Should().NotBeNull().And.BeOfType<NotFoundResult>();

            service.VerifyAll();
        }

        [Theory, AutoData]
        public async Task GetItemValidIdReturnsOk(int id, TModel item)
        {
            var service = new Mock<IItemService<TModel>>(MockBehavior.Strict);
            SetupService(service);
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
            var service = new Mock<IItemService<TModel>>(MockBehavior.Strict);
            SetupService(service);

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
            var service = new Mock<IItemService<TModel>>(MockBehavior.Strict);
            SetupService(service);

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
            var service = new Mock<IItemService<TModel>>(MockBehavior.Strict);
            SetupService(service);

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

        protected abstract TController GetController(IItemService<TModel> service);

        protected abstract JsonPatchDocument<TModel> GetPatch();

        protected abstract void SetupService(Mock<IItemService<TModel>> mock);
    }
}