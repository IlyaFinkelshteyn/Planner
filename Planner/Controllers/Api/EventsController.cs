using Microsoft.AspNetCore.Mvc;
using Planner.Controllers.Api.Results;
using Planner.Models.EventsModel;
using Planner.Models.EventsViewModels;
using Planner.Services.Interfaces;
using System.Threading.Tasks;

namespace Planner.Controllers.Api
{
    public class EventsController : ItemsControllerBase<Event, EventDetails>
    {
        public EventsController(IEventService service) : base(service)
        {
        }

        protected new IEventService Service => base.Service as IEventService;

        public async Task<IActionResult> Post(EventCreate createModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var model = createModel.ToItem();

            var id = await Service.AddAsync(model);

            return CreatedAtAction("Get", new { id }, new IdResult { Id = id });
        }
    }
}