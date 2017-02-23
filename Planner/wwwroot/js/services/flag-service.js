angular
    .module('app')
    .factory('FlagService', FlagService);
FlagService.$inject = [];
var FlagService = (function () {
    function FlagService() {
    }
    FlagService.prototype.statusToListGroupItemClass = function (status) {
        switch (status) {
            case 0 /* Unconfirmed */:
                return "list-group-item-warning";
            case 1 /* Confirmed */:
                return "list-group-item-success";
            case 2 /* Cancelled */:
                return "list-group-item-danger";
        }
    };
    ;
    FlagService.prototype.statusToLabelClass = function (status) {
        switch (status) {
            case 0 /* Unconfirmed */:
                return "label-warning";
            case 1 /* Confirmed */:
                return "label-success";
            case 2 /* Cancelled */:
                return "label-danger";
        }
    };
    ;
    FlagService.prototype.statusToText = function (status) {
        switch (status) {
            case 0 /* Unconfirmed */:
                return "Unconfirmed";
            case 1 /* Confirmed */:
                return "Confirmed";
            case 2 /* Cancelled */:
                return "Cancelled";
        }
    };
    ;
    FlagService.prototype.flagToLabelClass = function (flag) {
        switch (flag) {
            case 1 /* UrgentCoverNeeded */:
                return "label-danger";
            case 2 /* NeedsEmailing */:
                return "label-warning";
            case 4 /* BriefingNotesReady */:
                return "label-success";
            case 8 /* BriefingNotesSent */:
                return "label-default";
        }
    };
    ;
    FlagService.prototype.flagToNames = function (flag) {
        switch (flag) {
            case 1 /* UrgentCoverNeeded */:
                return "Urgent Cover Needed";
            case 2 /* NeedsEmailing */:
                return "Needs Emailing";
            case 4 /* BriefingNotesReady */:
                return "Briefing Notes Ready";
            case 8 /* BriefingNotesSent */:
                return "Briefing Notes Sent";
        }
    };
    ;
    return FlagService;
}());
