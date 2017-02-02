using Planner.Models.EventsModel;
using System.Threading.Tasks;

namespace Planner.Services.Interfaces
{
    public interface IEventService : IItemService<Event>
    {
        Task<int> AddAsync(Event ev);
    }
}