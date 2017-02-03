using Planner.Models.EventsModel;
using Planner.Models.EventsViewModels;
using Planner.Services.Interfaces;

namespace Planner.Controllers.Api
{
    /// <summary>
    /// API Controller used to manipulate deployments.
    /// </summary>
    /// <seealso cref="Api.SubItemControllerBase{TModel, TCreate, TDetail}" />
    public class ExpectedIncidentsController : SubItemControllerBase<ExpectedIncident, ExpectedIncidentCreate, ExpectedIncidentDetails>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExpectedIncidentsController"/> class.
        /// </summary>
        /// <param name="service">The service used to manipulate expected incidents.</param>
        public ExpectedIncidentsController(ISubItemService<ExpectedIncident> service) : base(service)
        {
        }
    }
}