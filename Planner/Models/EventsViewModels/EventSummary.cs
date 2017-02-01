using System.Collections.Generic;

namespace Planner.Models.EventsViewModels
{
    public partial class EventSummary
    {
        public int CyclistsAssigned { get; set; }
        public IEnumerable<Flags> Flags { get; set; }
    }
}