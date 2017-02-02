using Planner.Models.EventsModel;
using Planner.Models.EventsViewModels;
using Planner.Services.Interfaces;

namespace Planner.Controllers.Api
{
    public class ExpectedIncidentsController : SubItemControllerBase<ExpectedIncident, ExpectedIncidentCreate, ExpectedIncidentDetails>
    {
        public ExpectedIncidentsController(ISubItemService<ExpectedIncident> service) : base(service)
        {
        }
    }
}