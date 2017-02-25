const enum Flags {
    UrgentCoverNeeded = 1,
    NeedsEmailing = 2,
    BriefingNotesReady = 4,
    BriefingNotesSent = 8
}

const enum EventStatus {
    Unconfirmed = 0,
    Confirmed = 1,
    Cancelled = 2
}

class FlagService {
    statusToListGroupItemClass(status: EventStatus) {
        switch (status) {
            case EventStatus.Unconfirmed:
                return "list-group-item-warning";
            case EventStatus.Confirmed:
                return "list-group-item-success";
            case EventStatus.Cancelled:
                return "list-group-item-danger";
        }
    };

    statusToLabelClass(status: EventStatus) {
        switch (status) {
            case EventStatus.Unconfirmed:
                return "label-warning";
            case EventStatus.Confirmed:
                return "label-success";
            case EventStatus.Cancelled:
                return "label-danger";
        }
    };

    statusToText(status: EventStatus) {
        switch (status) {
            case EventStatus.Unconfirmed:
                return "Unconfirmed";
            case EventStatus.Confirmed:
                return "Confirmed";
            case EventStatus.Cancelled:
                return "Cancelled";
        }
    };

    flagToLabelClass(flag: Flags) {
        switch (flag) {
            case Flags.UrgentCoverNeeded:
                return "label-danger";
            case Flags.NeedsEmailing:
                return "label-warning";
            case Flags.BriefingNotesReady:
                return "label-success";
            case Flags.BriefingNotesSent:
                return "label-default";
        }
    };

    flagToNames(flag: Flags) {
        switch (flag) {
            case Flags.UrgentCoverNeeded:
                return "Urgent Cover Needed";
            case Flags.NeedsEmailing:
                return "Needs Emailing";
            case Flags.BriefingNotesReady:
                return "Briefing Notes Ready";
            case Flags.BriefingNotesSent:
                return "Briefing Notes Sent";
        }
    };
}

angular.module('app').service('FlagService', FlagService);