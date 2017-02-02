using Planner.Models.EventsModel;
using Planner.Models.EventsViewModels;
using Planner.Services.Interfaces;

namespace Planner.Controllers.Api
{
    public class NoGoAreasController : SubItemControllerBase<NoGoArea, NoGoAreaCreate, NoGoAreaDetails>
    {
        public NoGoAreasController(ISubItemService<NoGoArea> service) : base(service)
        {
        }
    }
}