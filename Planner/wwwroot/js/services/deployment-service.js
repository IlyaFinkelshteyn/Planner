(function () {
    'use strict';

    angular
        .module('app')
        .factory('DeploymentService', DeploymentService);

    DeploymentService.$inject = ['$http'];

    function DeploymentService($http) {
        var urlBase = '/api/deployments';

        var service = {
            addItem: addItem,
            deleteItem: deleteItem,
            patchItem: patchItem,
            getCyclistSummaries: getCyclistSummaries
        };

        return service;

        function deleteItem(id) {
            return $http({
                method: 'DELETE',
                url: urlBase + "/" + id
            });
        }

        function getCyclistSummaries() {
            return $http({
                method: 'GET',
                url: urlBase + '/cyclistSummaries'
            });
        }

        function addItem(eventId, item) {
            item = $.extend({}, item);

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