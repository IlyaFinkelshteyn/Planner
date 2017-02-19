using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Planner.Data;
using Planner.Models.EventsModel;
using Planner.Services.Interfaces;
using System.Linq;

namespace Planner.Services
{
    public class EventService : ItemService<Event>, IEventService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventService"/> class.
        /// </summary>
        /// <param name="database">The database.</param>
        public EventService(ApplicationDbContext database) : base(database)
        {
        }

        public async Task<int> AddAsync(Event ev)
        {
            if (ev == null)
                throw new ArgumentNullException(nameof(ev));

            Database.Events.Add(ev);
            await Database.SaveChangesAsync();

            return ev.Id;
        }

        public Task<IEnumerable<Event>> GetListAsync(DateTime eventsAfter)
        {
            var date = eventsAfter.Date;

            return Task.FromResult<IEnumerable<Event>>(Database.Events.Where(e => e.Date >= date));
        }
    }
}