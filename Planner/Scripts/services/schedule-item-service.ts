﻿class ScheduleItemService {
    constructor($http: angular.IHttpService) {
        this.$http = $http;
    }
    private urlBase = '/api/scheduleItems';
    private $http: angular.IHttpService;
    static $inject = ['$http'];

    deleteItem(id: number) {
        return this.$http({
            method: 'DELETE',
            url: this.urlBase + "/" + id
        });
    }

    addItem(eventId: number, item: any) {
        item = $.extend({}, item);

        return this.$http<IdResult>({
            method: 'POST',
            url: this.urlBase + "?eventId=" + eventId,
            data: item
        });
    }

    patchItem(id: number, patch: any) {
        return this.$http<IScheduleItemDetail>({
            method: 'PATCH',
            url: this.urlBase + "/" + id,
            data: patch,
            headers: {
                'Content-Type': 'application/json-patch+json'
            }
        });
    }
}

angular.module('app').service('ScheduleItemService', ScheduleItemService);