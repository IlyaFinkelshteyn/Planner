using Microsoft.AspNetCore.Mvc;
using Planner.Controllers.Api.Results;
using Planner.Models.EventsModel;
using Planner.Models.EventsViewModels;
using Planner.Services.Interfaces;
using System.Threading.Tasks;

namespace Planner.Controllers.Api
{
    /// <summary>
    /// API Controller used to manipulate events.
    /// </summary>
    /// <seealso cref="Api.ItemsControllerBase{TModel, TDetails}" />
    public class EventsController : ItemsControllerBase<Event, EventDetails>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventsController"/> class.
        /// </summary>
        /// <param name="service">The service used to manipulate events.</param>
        public EventsController(IEventService service) : base(service)
        {
        }

        /// <summary>
        /// The service used to manipulate events.
        /// </summary>
        protected new IEventService Service => base.Service as IEventService;

        /// <summary>
        /// Creates a new Event based on the provided model.
        /// </summary>
        /// <param name="createModel">The model to create the list with.</param>
        /// <returns>BadRequestObjectResult if the model is invalid, otherwise CreatedAtActionResult.</returns>
        /// <response code="400">Model is invalid.</response>
        /// <response code="201">Item has been created.</response>
        [HttpPost]
        [ProducesResponseType(typeof(IdResult), 201)]
        public async Task<IActionResult> Post([FromBody]EventCreate createModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var model = createModel.ToItem();

            var id = await Service.AddAsync(model);

            return CreatedAtAction("Get", new { id }, new IdResult { Id = id });
        }
    }
}