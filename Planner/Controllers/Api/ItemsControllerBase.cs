using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Planner.Models.EventsModel.Interfaces;
using Planner.Services.Filters;
using Planner.Services.Interfaces;
using System.Threading.Tasks;

namespace Planner.Controllers.Api
{
    /// <summary>
    /// Base class used to perform basic item controller operations.
    /// </summary>
    /// <typeparam name="TModel">The model type</typeparam>
    /// <typeparam name="TDetails">The detail class associated with <typeparamref name="TModel"/></typeparam>
    [Authorize, Route("api/[controller]")]
    public abstract class ItemsControllerBase<TModel, TDetails> : Controller
        where TModel : class, IDetailable<TDetails>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ItemsControllerBase{TModel, TDetails}"/> class.
        /// </summary>
        /// <param name="service">The service used to manipulate TModels.</param>
        public ItemsControllerBase(IItemService<TModel> service)
        {
            Service = service;
        }

        /// <summary>
        /// The service used to manipulate TModels.
        /// </summary>
        protected IItemService<TModel> Service { get; }

        /// <summary>
        /// Deletes the item with the provided ID.
        /// </summary>
        /// <param name="id">The ID of the item to delete.</param>
        /// <returns>Always returns NoContentResult.</returns>
        /// <response code="204">Always returned.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        public virtual async Task<IActionResult> Delete(int id)
        {
            await Service.DeleteAsync(id);
            return NoContent();
        }

        /// <summary>
        /// Gets the item with the provided ID.
        /// </summary>
        /// <param name="id">The ID of the item to get.</param>
        /// <returns>OkObjectResult if found, otherwise NotFoundResult</returns>
        /// <response code="404">If the requested item does not exist.</response>
        /// <response code="200">Returns the requested item.</response>
        [HttpGet("{id}")]
        [DetailResponse(200)]
        public virtual async Task<IActionResult> Get(int id)
        {
            var item = await Service.GetAsync(id);

            if (item == null)
                return NotFound();

            return Ok(item.ToDetail());
        }

        /// <summary>
        /// Patches the item with the given ID, using the given patch.
        /// </summary>
        /// <param name="id">The ID of the item to patch.</param>
        /// <param name="patch">The patch (is Json Patch format) used to update the item</param>
        /// <returns>OkObjectResult if successful, NotFoundResult if the ID doesn't exist or BadRequestObjectResult if the request is invalid.</returns>
        /// <response code="404">If the requested item does not exist.</response>
        /// <response code="400">If the patch is not valid.</response>
        /// <response code="200">Returns the updated item.</response>
        [HttpPatch("{id}")]
        [DetailResponse(200)]
        public virtual async Task<IActionResult> Patch(int id, [FromBody]JsonPatchDocument<TModel> patch)
        {
            var item = await Service.GetAsync(id);

            if (item == null)
                return NotFound();

            patch.ApplyTo(item, ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await Service.UpdateAsync(item);

            return Ok(item.ToDetail());
        }
    }
}