using System.Threading.Tasks;

namespace Planner.Services.Interfaces
{
    public interface IItemService<TModel>
    {
        Task DeleteAsync(int id);

        Task<TModel> GetAsync(int id);

        Task UpdateAsync(TModel item);
    }
}