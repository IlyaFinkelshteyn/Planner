using Planner.Models.EventsModel;
using Planner.Models.EventsViewModels;
using Planner.Services.Interfaces;

namespace Planner.Controllers.Api
{
    public class ScheduleItemsController : SubItemControllerBase<ScheduleItem, ScheduleItemCreate, ScheduleItemDetails>
    {
        public ScheduleItemsController(ISubItemService<ScheduleItem> service) : base(service)
        {
        }
    }
}