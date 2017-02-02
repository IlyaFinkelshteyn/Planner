using Microsoft.AspNetCore.JsonPatch;
using Planner.Controllers.Api;
using Planner.Models.EventsModel;
using Planner.Models.EventsViewModels;
using Planner.Services.Interfaces;
using Ploeh.AutoFixture;

namespace Planner.Tests.Controllers.Api
{
    public class ScheduleItemsControllerTests : SubItemControllerTestsBase<ScheduleItemsController, ScheduleItem, ScheduleItemCreate, ScheduleItemDetails>
    {
        protected override ScheduleItemsController GetController(ISubItemService<ScheduleItem> service)
        {
            return new ScheduleItemsController(service);
        }

        protected override JsonPatchDocument<ScheduleItem> GetPatch()
        {
            var patch = new JsonPatchDocument<ScheduleItem>();

            var newAction = Fixture.Create<string>();

            patch.Replace(d => d.Action, newAction);

            return patch;
        }
    }
}