using Planner.Models.EventsModel;
using System.Diagnostics.CodeAnalysis;

namespace Planner.Models.EventsViewModels
{
    [ExcludeFromCodeCoverage]
    public class CyclistSummary
    {
        public int Count { get; set; }
        public Qualification? LatestClinicalQualification { get; set; }
        public CyclingLevel? LatestCyclingLevel { get; set; }
        public string Name { get; set; }
    }
}