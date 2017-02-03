using Microsoft.AspNetCore.Mvc;
using Planner.Controllers.Api.Results;
using Planner.Models.EventsModel.Interfaces;
using Planner.Models.EventsViewModels.Interfaces;
using Planner.Services.Exceptions;
using Planner.Services.Interfaces;
using System.Threading.Tasks;

namespace Planner.Controllers.Api
{
    /// <summary>
    /// Base class used to perform basic item controller operations on event sub-items.
    /// </summary>
    /// <typeparam name="TModel">The model type</typeparam>
    /// <typeparam name="TCreate">The create class associated with <typeparamref name="TModel"/></typeparam>
    /// <typeparam name="TDetail">The detail class associated with <typeparamref name="TModel"/></typeparam>
    /// <seealso cref="Planner.Controllers.Api.ItemsControllerBase{TModel, TDetail}" />
    public class SubItemControllerBase<TModel, TCreate, TDetail> : ItemsControllerBase<TModel, TDetail>
        where TModel : class, IDetailable<TDetail>
        where TCreate : ICreateViewModel<TModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubItemControllerBase{TModel, TCreate, TDetail}"/> class.
        /// </summary>
        /// <param name="service">The service used to manipulate TModels.</param>
        public SubItemControllerBase(ISubItemService<TModel> service) : base(service)
        {
        }

        /// <summary>
        /// The service used to manipulate the TModels.
        /// </summary>
        protected new ISubItemService<TModel> Service => base.Service as ISubItemService<TModel>;

        /// <summary>
        /// Creates a new item based on the provided model, attached to the event with ID <paramref name="eventId"/>.
        /// </summary>
        /// <param name="eventId">The ID of the event to add the item to.</param>
        /// <param name="createModel">The model to create the item with.</param>
        /// <returns>BadRequestObjectResult if the model is invalid, otherwise CreatedAtActionResult.</returns>
        /// <response code="400">Model is invalid.</response>
        /// <response code="201">Item has been created.</response>
        [HttpPost]
        [ProducesResponseType(typeof(IdResult), 201)]
        public virtual async Task<IActionResult> Post([FromQuery]int eventId, [FromBody]TCreate createModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var model = createModel.ToItem();

            try
            {
                var id = await Service.AddAsync(eventId, model);

                return CreatedAtAction("Get", new { id }, new IdResult { Id = id });
            }
            catch (EventNotFoundException)
            {
                ModelState.AddModelError("eventId", "Event does not exist.");
                return BadRequest(ModelState);
            }
        }
    }
}