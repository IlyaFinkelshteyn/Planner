using Microsoft.AspNetCore.Mvc;
using Planner.Controllers.Api.Results;
using Planner.Models.EventsModel.Interfaces;
using Planner.Models.EventsViewModels.Interfaces;
using Planner.Services.Exceptions;
using Planner.Services.Interfaces;
using System.Threading.Tasks;

namespace Planner.Controllers.Api
{
    public class SubItemControllerBase<TModel, TCreate, TDetail> : ItemsControllerBase<TModel, TDetail>
        where TModel : class, IDetailable<TDetail>
        where TCreate : ICreateViewModel<TModel>
    {
        public SubItemControllerBase(ISubItemService<TModel> service) : base(service)
        {
        }

        protected new ISubItemService<TModel> Service => base.Service as ISubItemService<TModel>;

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