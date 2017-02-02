using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Planner.Models.EventsModel.Interfaces;
using Planner.Services.Interfaces;
using System.Threading.Tasks;

namespace Planner.Controllers.Api
{
    [Authorize]
    public abstract class ItemsControllerBase<TModel, TDetails> : Controller
        where TModel : class, IDetailable<TDetails>
    {
        public ItemsControllerBase(IItemService<TModel> service)
        {
            Service = service;
        }

        protected IItemService<TModel> Service { get; }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await Service.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var item = await Service.GetAsync(id);

            if (item == null)
                return NotFound();

            return Ok(item.ToDetail());
        }

        [HttpPatch]
        public async Task<IActionResult> Patch(int id, JsonPatchDocument<TModel> patch)
        {
            var item = await Service.GetAsync(id);

            if (item == null)
                return NotFound();

            patch.ApplyTo(item, ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await Service.UpdateAsync(item);

            return Ok(item);
        }
    }
}