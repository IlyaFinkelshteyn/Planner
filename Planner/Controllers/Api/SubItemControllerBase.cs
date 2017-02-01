using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Planner.Controllers.Api.Results;
using Planner.Models.EventsModel.Interfaces;
using Planner.Models.EventsViewModels.Interfaces;
using Planner.Services.Exceptions;
using Planner.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace Planner.Controllers.Api
{
    public class SubItemControllerBase<TModel, TCreate, TDetail> : Controller
        where TModel : class, IDetailable<TDetail>
        where TCreate : ICreateViewModel<TModel>
    {
        public SubItemControllerBase(ISubItemService<TModel> service)
        {
            Service = service;
        }

        protected ISubItemService<TModel> Service { get; }

        public async Task<IActionResult> Delete(int id)
        {
            await Service.DeleteAsync(id);
            return NoContent();
        }

        public async Task<IActionResult> Get(int id)
        {
            var item = await Service.GetAsync(id);

            if (item == null)
                return NotFound();

            return Ok(item.ToDetail());
        }

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

        public async Task<IActionResult> Post(int eventId, TCreate createModel)
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