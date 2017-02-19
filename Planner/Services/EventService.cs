using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Planner.Data;
using Planner.Models.EventsModel;
using Planner.Services.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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

        public override async Task<Event> GetAsync(int id)
        {
            var item = await Database.Events.Include(e => e.Schedule).Include(e => e.Deployments)
                .Include(e => e.NoGoAreas).Include(e => e.ExpectedIncidents).Include(e => e.Notes).FirstOrDefaultAsync(e => e.Id == id);
            return item;
        }

        public Task<IEnumerable<Event>> GetListAsync(DateTime eventsAfter)
        {
            var date = eventsAfter.Date;

            return Task.FromResult<IEnumerable<Event>>(Database.Events.Include(e => e.Deployments).Where(e => e.Date >= date));
        }
    }
}