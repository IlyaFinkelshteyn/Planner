using System.Threading.Tasks;

namespace Planner.Services.Interfaces
{
    public interface ISubItemService<TModel>
    {
        Task<int> AddAsync(int eventId, TModel item);

        Task DeleteAsync(int id);

        Task<TModel> GetAsync(int id);

        Task UpdateAsync(TModel item);
    }
}