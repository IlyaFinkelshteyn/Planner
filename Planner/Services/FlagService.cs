using Microsoft.Extensions.Options;
using Planner.Models.EventsModel;
using Planner.Models.EventsViewModels;
using Planner.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Planner.Services
{
    public class FlagService : IFlagService
    {
        private readonly FlagServiceOptions _options;

        public FlagService(IOptions<FlagServiceOptions> options)
        {
            _options = options.Value;
        }

        public IEnumerable<Flags> GetFlags(Event e, Flags desiredFlags)
        {
            var flags = new List<Flags>();

            var daysFromNow = (e.Date - DateTime.Today).TotalDays;

            if (desiredFlags.HasFlag(Flags.UrgentCoverNeeded))
            {
                var cyclistsAssigned = e.Deployments.Count(d => !string.IsNullOrWhiteSpace(d.Name));
                if (daysFromNow <= _options.UrgentCoverThreshold && cyclistsAssigned < e.CyclistsRequested && e.DateConfirmed)
                    flags.Add(Flags.UrgentCoverNeeded);
            }

            if (desiredFlags.HasFlag(Flags.NeedsEmailing))
            {
                var daysSinceEmail = (DateTime.Now.Date - e.LastEmailedOut).TotalDays;
                if (daysFromNow <= _options.SendEmailThreshold && daysSinceEmail > _options.EmailCautionThreshold)
                    flags.Add(Flags.NeedsEmailing);
            }

            if (desiredFlags.HasFlag(Flags.BriefingNotesReady))
            {
                var briefingNotesValid = !string.IsNullOrWhiteSpace(e.Description) && e.Schedule.Any() && e.Deployments.Any() && e.ExpectedIncidents.Any();
                if (daysFromNow < _options.SendBriefingNotesThreshold && briefingNotesValid && !e.BriefingNotesSent)
                    flags.Add(Flags.BriefingNotesReady);
            }

            if (desiredFlags.HasFlag(Flags.BriefingNotesSent))
            {
                if (e.BriefingNotesSent)
                    flags.Add(Flags.BriefingNotesSent);
            }

            return flags;
        }
    }

    public class FlagServiceOptions
    {
        public int EmailCautionThreshold { get; set; }
        public int SendBriefingNotesThreshold { get; set; }
        public int SendEmailThreshold { get; set; }
        public int UrgentCoverThreshold { get; set; }
    }
}