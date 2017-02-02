using Microsoft.AspNetCore.JsonPatch;
using Planner.Controllers.Api;
using Planner.Models.EventsModel;
using Planner.Models.EventsViewModels;
using Planner.Services.Interfaces;
using Ploeh.AutoFixture;

namespace Planner.Tests.Controllers.Api
{
    public class NoGoAreasControllerTests : SubItemControllerTestsBase<NoGoAreasController, NoGoArea, NoGoAreaCreate, NoGoAreaDetails>
    {
        protected override NoGoAreasController GetController(ISubItemService<NoGoArea> service)
        {
            return new NoGoAreasController(service);
        }

        protected override JsonPatchDocument<NoGoArea> GetPatch()
        {
            var patch = new JsonPatchDocument<NoGoArea>();

            var newName = Fixture.Create<string>();

            patch.Replace(d => d.Name, newName);

            return patch;
        }
    }
}