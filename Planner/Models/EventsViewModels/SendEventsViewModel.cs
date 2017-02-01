using System.Diagnostics.CodeAnalysis;

namespace Planner.Models.EventsViewModels
{
    [ExcludeFromCodeCoverage]
    public class SendEventsViewModel
    {
        public EventSummary Event { get; set; }
        public bool SendEmail { get; set; }
        public bool SendToWiderList { get; set; }
    }
}