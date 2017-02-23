angular
    .module('app')
    .factory('ScheduleItemService', ScheduleItemService);

ScheduleItemService.$inject = ['$http'];

class ScheduleItemService {
    constructor($http: angular.IHttpService) {
        this.$http = $http;
    }
    private urlBase = '/api/scheduleItems';
    private $http: angular.IHttpService;

    deleteItem(id: number) {
        return this.$http({
            method: 'DELETE',
            url: this.urlBase + "/" + id
        });
    }

    addItem(eventId: number, item: any) {
        item = $.extend({}, item);

        item.time = moment(item.time).format("hh:mm");

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