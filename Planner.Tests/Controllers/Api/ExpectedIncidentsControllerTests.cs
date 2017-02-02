using Microsoft.AspNetCore.JsonPatch;
using Planner.Controllers.Api;
using Planner.Models.EventsModel;
using Planner.Models.EventsViewModels;
using Planner.Services.Interfaces;
using Ploeh.AutoFixture;

namespace Planner.Tests.Controllers.Api
{
    public class ExpectedIncidentsControllerTests : SubItemControllerTestsBase<ExpectedIncidentsController, ExpectedIncident, ExpectedIncidentCreate, ExpectedIncidentDetails>
    {
        protected override ExpectedIncidentsController GetController(IItemService<ExpectedIncident> service)
        {
            return new ExpectedIncidentsController(service as ISubItemService<ExpectedIncident>);
        }

        protected override JsonPatchDocument<ExpectedIncident> GetPatch()
        {
            var patch = new JsonPatchDocument<ExpectedIncident>();

            var newName = Fixture.Create<string>();

            patch.Replace(d => d.Name, newName);

            return patch;
        }
    }
}