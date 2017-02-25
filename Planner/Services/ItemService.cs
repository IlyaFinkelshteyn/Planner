using Microsoft.EntityFrameworkCore;
using Planner.Data;
using Planner.Models.EventsModel.Interfaces;
using Planner.Services.Exceptions;
using Planner.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace Planner.Services
{
    public class ItemService<T> : IItemService<T>
        where T : class, IIdentifiable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ItemService{T}"/> class.
        /// </summary>
        /// <param name="database">The database.</param>
        public ItemService(ApplicationDbContext database)
        {
            Database = database;
        }

        protected ApplicationDbContext Database { get; }

        public async Task DeleteAsync(int id)
        {
            var item = await Database.FindAsync<T>(id);
            if (item != null)
            {
                Database.Remove(item);
                await Database.SaveChangesAsync();
            }
        }

        public virtual async Task<T> GetAsync(int id)
        {
            return await Database.FindAsync<T>(id);
        }

        public async Task UpdateAsync(T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            try
            {
                Database.Update(item);
                await Database.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new IdNotFoundException("No entity found to update.", ex);
            }
        }
    }
}