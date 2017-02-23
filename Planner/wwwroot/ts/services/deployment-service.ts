angular
    .module('app')
    .factory('DeploymentService', DeploymentService);

DeploymentService.$inject = ['$http'];

class DeploymentService {
    constructor($http: angular.IHttpService) {
        this.$http = $http;
    }

    private urlBase: string = '/api/deployments';
    private $http: angular.IHttpService;

    deleteItem(id: number) {
        return this.$http({
            method: 'DELETE',
            url: this.urlBase + "/" + id
        });
    }

    getCyclistSummaries() {
        return this.$http({
            method: 'GET',
            url: this.urlBase + '/cyclistSummaries'
        });
    }

    addItem(eventId: number, item: any) {
        item = $.extend({}, item);

        return this.$http({
            method: 'POST',
            url: this.urlBase + "?eventId=" + eventId,
            data: item
        });
    }

    patchItem(id: number, patch: any) {
        return this.$http({
            method: 'PATCH',
            url: this.urlBase + "/" + id,
            data: patch,
            headers: {
                'Content-Type': 'application/json-patch+json'
            }
        });
    }
}