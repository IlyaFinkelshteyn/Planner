using Planner.Data;
using Planner.Models.EventsModel;
using Planner.Models.EventsModel.Interfaces;
using Planner.Services.Exceptions;
using Planner.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace Planner.Services
{
    public abstract class SubItemService<T> : ItemService<T>, ISubItemService<T>
        where T : class, IIdentifiable
    {
        public SubItemService(ApplicationDbContext database) : base(database)
        {
        }

        public async Task<int> AddAsync(int eventId, T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            var ev = Database.Events.Find(eventId);
            if (ev == null)
                throw new IdNotFoundException();

            AddItem(ev, item);

            await Database.SaveChangesAsync();

            return item.Id;
        }

        public abstract void AddItem(Event ev, T item);
    }
}