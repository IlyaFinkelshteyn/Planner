using Planner.Models.EventsModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.Services.Interfaces
{
    public interface IEventService : IItemService<Event>
    {
        Task<int> AddAsync(Event ev);

        Task<IEnumerable<Event>> GetListAsync(DateTime eventsAfter);
    }
}