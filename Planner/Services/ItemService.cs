using Planner.Data;
using Planner.Services.Interfaces;
using System.Threading.Tasks;

namespace Planner.Services
{
    public class ItemService<T> : IItemService<T>
        where T : class
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
            Database.Remove(item);
            await Database.SaveChangesAsync();
        }

        public async Task<T> GetAsync(int id)
        {
            return await Database.FindAsync<T>(id);
        }

        public async Task UpdateAsync(T item)
        {
            Database.Update(item);
            await Database.SaveChangesAsync();
        }
    }
}