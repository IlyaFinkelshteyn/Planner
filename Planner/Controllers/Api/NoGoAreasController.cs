using Planner.Models.EventsModel;
using Planner.Models.EventsViewModels;
using Planner.Services.Interfaces;

namespace Planner.Controllers.Api
{
    /// <summary>
    /// API Controller used to manipulate no-go areas.
    /// </summary>
    /// <seealso cref="Api.SubItemControllerBase{TModel, TCreate, TDetail}" />
    public class NoGoAreasController : SubItemControllerBase<NoGoArea, NoGoAreaCreate, NoGoAreaDetails>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NoGoAreasController"/> class.
        /// </summary>
        /// <param name="service">The service used to manipulate no-go areas.</param>
        public NoGoAreasController(ISubItemService<NoGoArea> service) : base(service)
        {
        }
    }
}