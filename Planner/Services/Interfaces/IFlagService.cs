using Planner.Models.EventsModel;
using Planner.Models.EventsViewModels;
using System.Collections.Generic;

namespace Planner.Services.Interfaces
{
    public interface IFlagService
    {
        IEnumerable<Flags> GetFlags(Event e, Flags desiredFlags);
    }
}