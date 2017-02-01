using System;

namespace Planner.Models.EventsViewModels
{
    [Flags]
    public enum Flags
    {
        UrgentCoverNeeded = 1,
        NeedsEmailing = 2,
        BriefingNotesReady = 4,
        BriefingNotesSent = 8
    }
}