(function () {
    'use strict';

    angular
        .module('app')
        .factory('FlagService', FlagService);

    FlagService.$inject = [];

    var flags = {
        UrgentCoverNeeded: 1,
        NeedsEmailing: 2,
        BriefingNotesReady: 4,
        BriefingNotesSent: 8
    };

    function FlagService() {
        var service = {
            statusToListGroupItemClass: statusToListGroupItemClass,
            statusToLabelClass: statusToLabelClass,
            statusToText: statusToText,
            flagToLabelClass: flagToLabelClass,
            flagToNames: flagToNames,
            flags: flags
        };

        return service;

        function statusToListGroupItemClass(status) {
            switch (status) {
                case 0:
                    return "list-group-item-warning";
                case 1:
                    return "list-group-item-success";
                case 2:
                    return "list-group-item-danger";
            }
        };

        function statusToLabelClass(status) {
            switch (status) {
                case 0:
                    return "label-warning";
                case 1:
                    return "label-success";
                case 2:
                    return "label-danger";
            }
        };

        function statusToText(status) {
            switch (status) {
                case 0:
                    return "Unconfirmed";
                case 1:
                    return "Confirmed";
                case 2:
                    return "Cancelled";
            }
        };

        function flagToLabelClass(flag) {
            switch (flag) {
                case flags.UrgentCoverNeeded:
                    return "label-danger";
                case flags.NeedsEmailing:
                    return "label-warning";
                case flags.BriefingNotesReady:
                    return "label-success";
                case flags.BriefingNotesSent:
                    return "label-default";
            }
        };

        function flagToNames(flag) {
            switch (flag) {
                case flags.UrgentCoverNeeded:
                    return "Urgent Cover Needed";
                case flags.NeedsEmailing:
                    return "Needs Emailing";
                case flags.BriefingNotesReady:
                    return "Briefing Notes Ready";
                case flags.BriefingNotesSent:
                    return "Briefing Notes Sent";
            }
        };
    }
})();