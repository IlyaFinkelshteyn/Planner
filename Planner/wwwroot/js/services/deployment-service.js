var DeploymentService = (function () {
    function DeploymentService($http) {
        this.urlBase = '/api/deployments';
        this.$http = $http;
    }
    DeploymentService.prototype.deleteItem = function (id) {
        return this.$http({
            method: 'DELETE',
            url: this.urlBase + "/" + id
        });
    };
    DeploymentService.prototype.getCyclistSummaries = function () {
        return this.$http({
            method: 'GET',
            url: this.urlBase + '/cyclistSummaries'
        });
    };
    DeploymentService.prototype.addItem = function (eventId, item) {
        item = $.extend({}, item);
        return this.$http({
            method: 'POST',
            url: this.urlBase + "?eventId=" + eventId,
            data: item
        });
    };
    DeploymentService.prototype.patchItem = function (id, patch) {
        return this.$http({
            method: 'PATCH',
            url: this.urlBase + "/" + id,
            data: patch,
            headers: {
                'Content-Type': 'application/json-patch+json'
            }
        });
    };
    return DeploymentService;
}());
DeploymentService.$inject = ['$http'];
angular.module('app').service('DeploymentService', DeploymentService);
//# sourceMappingURL=deployment-service.js.map