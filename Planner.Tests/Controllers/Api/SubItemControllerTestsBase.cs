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
using Ploeh.AutoFixture.Xunit2;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Planner.Tests.Controllers.Api
{
    public abstract class SubItemControllerTestsBase<TController, TModel, TCreate, TDetail> : ItemsControllerTestsBase<TController, TModel, TDetail>
        where TController : SubItemControllerBase<TModel, TCreate, TDetail>
        where TModel : class, IIdentifiable, ICloneable, IDetailable<TDetail>
        where TCreate : ICreateViewModel<TModel>
    {
        [Theory, AutoData]
        public async Task PostInvalidEventIdCallsServiceAndReturnsBadRequest(int eventId, TCreate createModel)
        {
            var service = new Mock<ISubItemService<TModel>>(MockBehavior.Strict);
            service.Setup(s => s.AddAsync(eventId, It.IsAny<TModel>())).Throws<IdNotFoundException>();

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

        protected override void SetupService(Mock<IItemService<TModel>> mock)
        {
            mock.As<ISubItemService<TModel>>();
        }
    }
}