(function () {
    'use strict';

    angular
        .module('app')
        .factory('ScheduleItemService', ScheduleItemService);

    ScheduleItemService.$inject = ['$http'];

    function ScheduleItemService($http) {
        var urlBase = '/api/scheduleItems';

        var service = {
            addItem: addItem,
            deleteItem: deleteItem,
            patchItem: patchItem
        };

        return service;

        function deleteItem(id) {
            return $http({
                method: 'DELETE',
                url: urlBase + "/" + id
            });
        }

        function addItem(eventId, item) {
            item = $.extend({}, item);

            item.time = moment(item.time).format("hh:mm");

            return $http({
                method: 'POST',
                url: urlBase + "?eventId=" + eventId,
                data: item
            });
        }

        function patchItem(id, patch) {
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