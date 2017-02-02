using Microsoft.AspNetCore.JsonPatch;
using Planner.Controllers.Api;
using Planner.Models.EventsModel;
using Planner.Models.EventsViewModels;
using Planner.Services.Interfaces;
using Ploeh.AutoFixture;

namespace Planner.Tests.Controllers.Api
{
    public class DeploymentsControllerTests : SubItemControllerTestsBase<DeploymentsController, Deployment, DeploymentCreate, DeploymentDetails>
    {
        protected override DeploymentsController GetController(IItemService<Deployment> service)
        {
            return new DeploymentsController(service as ISubItemService<Deployment>);
        }

        protected override JsonPatchDocument<Deployment> GetPatch()
        {
            var patch = new JsonPatchDocument<Deployment>();

            var newCallsign = Fixture.Create<string>();

            patch.Replace(d => d.Callsign, newCallsign);

            return patch;
        }
    }
}