using Microsoft.AspNetCore.Mvc;
using Planner.Controllers.Api.Results;
using Planner.Models.EventsModel;
using Planner.Models.EventsViewModels;
using Planner.Services.Interfaces;
using System.Threading.Tasks;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Planner.Controllers.Api
{
    /// <summary>
    /// API Controller used to manipulate events.
    /// </summary>
    /// <seealso cref="Api.ItemsControllerBase{TModel, TDetails}" />
    public class EventsController : ItemsControllerBase<Event, EventDetails>
    {
        private IFlagService _flagService;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventsController"/> class.
        /// </summary>
        /// <param name="service">The service used to manipulate events.</param>
        /// <param name="flagService">The service used to manipulate event flags.</param>
        public EventsController(IEventService service, IFlagService flagService) : base(service)
        {
            _flagService = flagService;
        }

        /// <summary>
        /// The service used to manipulate events.
        /// </summary>
        protected new IEventService Service => base.Service as IEventService;

        /// <summary>
        /// Gets all events, including historic if <paramref name="includeHistoric"/> is true.
        /// </summary>
        /// <param name="includeHistoric">if set to <c>true</c>, include historic events.</param>
        /// <returns>OkObjectResult containing the requested objects</returns>
        /// <response code="200">The requested items.</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<EventSummary>), 200)]
        public async Task<IActionResult> GetAll(bool includeHistoric = false)
        {
            var items = await Service.GetListAsync(includeHistoric ? DateTime.MinValue : DateTime.Today);

            return Ok(items.Select(e => new EventSummary(e)
            {
                CyclistsAssigned = e.Deployments.Count(d => !string.IsNullOrWhiteSpace(d.Name)),
                Flags = _flagService.GetFlags(e, Flags.NeedsEmailing | Flags.UrgentCoverNeeded)
            }));
        }

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