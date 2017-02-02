using System.Threading.Tasks;

namespace Planner.Services.Interfaces
{
    public interface ISubItemService<TModel> : IItemService<TModel>
    {
        Task<int> AddAsync(int eventId, TModel item);
    }
}