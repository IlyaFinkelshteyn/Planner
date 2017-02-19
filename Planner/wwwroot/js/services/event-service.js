(function () {
    'use strict';

    angular
        .module('app')
        .factory('EventService', EventService);

    EventService.$inject = ['$http'];

    function EventService($http) {
        var urlBase = '/api/events';

        var service = {
            addEvent: addEvent,
            getEvent: getEvent,
            getEvents: getEvents,
            patchEvent: patchEvent,
            patchItem: patchEvent
        };

        return service;

        function getEvents(historic) {
            if (historic)
                return $http.get(urlBase + "?includeHistoric=true");
            return $http.get(urlBase);
        }

        function getEvent(id) {
            return $http.get(urlBase + "/" + id);
        }

        function addEvent(event) {
            event = $.extend({}, event);

            if (event.DipsNumber === '' || event.DipsNumber == null)
                event.DipsNumber = 0;

            event.EndTime = moment(event.EndTime).format("hh:mm");
            event.StartTime = moment(event.StartTime).format("hh:mm");

            return $http({
                method: 'POST',
                url: urlBase,
                data: event
            });
        }

        function patchEvent(id, patch) {
            return $http({
                method: 'PATCH',
                url: urlBase + "/" + id,
                data: patch,
                headers: {
                    'Content-Type': 'application/json-patch+json'
                }
            });
        }
    }
})();