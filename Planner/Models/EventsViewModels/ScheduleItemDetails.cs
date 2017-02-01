using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Planner.Models.EventsViewModels
{
    public partial class ScheduleItemDetails
    {
        public string TimeString => Time.ToString(@"hh\:mm\:ss");
    }
}