using Planner.Models.EventsModel;

namespace Planner.Models.EventsViewModels
{
    public class CyclistSummary
    {
        public int Count { get; set; }
        public Qualification? LatestClinicalQualification { get; set; }
        public CyclingLevel? LatestCyclingLevel { get; set; }
        public string Name { get; set; }
    }
}