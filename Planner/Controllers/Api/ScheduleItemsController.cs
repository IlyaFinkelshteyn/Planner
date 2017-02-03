using Planner.Models.EventsModel;
using Planner.Models.EventsViewModels;
using Planner.Services.Interfaces;

namespace Planner.Controllers.Api
{
    /// <summary>
    /// API Controller used to manipulate schedule items.
    /// </summary>
    /// <seealso cref="Api.SubItemControllerBase{TModel, TCreate, TDetail}" />
    public class ScheduleItemsController : SubItemControllerBase<ScheduleItem, ScheduleItemCreate, ScheduleItemDetails>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ScheduleItemsController"/> class.
        /// </summary>
        /// <param name="service">The service used to manipulate schedule items.</param>
        public ScheduleItemsController(ISubItemService<ScheduleItem> service) : base(service)
        {
        }
    }
}