using Planner.Models.EventsModel;
using Planner.Models.EventsViewModels;
using Planner.Services.Interfaces;

namespace Planner.Controllers.Api
{
    public class DeploymentsController : SubItemControllerBase<Deployment, DeploymentCreate, DeploymentDetails>
    {
        public DeploymentsController(ISubItemService<Deployment> service) : base(service)
        {
        }
    }
}