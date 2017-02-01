using System.ComponentModel.DataAnnotations;

namespace Planner.Models.EventsModel
{
    public enum CyclingLevel
    {
        [Display(Name = "Entry Level")]
        EntryLevel = 1,

        Advanced = 2
    }
}