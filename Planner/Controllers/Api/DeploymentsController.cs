using Planner.Models.EventsModel;
using Planner.Models.EventsViewModels;
using Planner.Services.Interfaces;

namespace Planner.Controllers.Api
{
    /// <summary>
    /// API Controller used to manipulate deployments.
    /// </summary>
    /// <seealso cref="Api.SubItemControllerBase{TModel, TCreate, TDetail}" />
    public class DeploymentsController : SubItemControllerBase<Deployment, DeploymentCreate, DeploymentDetails>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeploymentsController"/> class.
        /// </summary>
        /// <param name="service">The service used to manipulate deployments.</param>
        public DeploymentsController(ISubItemService<Deployment> service) : base(service)
        {
        }
    }
}