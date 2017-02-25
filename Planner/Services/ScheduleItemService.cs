using Planner.Data;
using Planner.Models.EventsModel;

namespace Planner.Services
{
    public class ScheduleItemService : SubItemService<ScheduleItem>
    {
        public ScheduleItemService(ApplicationDbContext database) : base(database)
        {
        }

        public override void AddItem(Event ev, ScheduleItem item)
        {
            ev.Schedule.Add(item);
        }
    }
}