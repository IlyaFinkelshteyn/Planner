using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Planner.Models.EventsViewModels
{
    [ExcludeFromCodeCoverage]
    public class CreateUpdateForm
    {
        public bool CreateMode { get; set; }
        public IEnumerable<CyclistSummary> Cyclists { get; set; }
        public int ReturnId { get; set; }
    }
}