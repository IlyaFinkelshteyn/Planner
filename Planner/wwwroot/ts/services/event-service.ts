/// <reference path="./moment.d.ts" />

angular
    .module('app')
    .factory('EventService', EventService);

EventService.$inject = ['$http'];

class EventService {
    constructor($http: angular.IHttpService) {
        this.$http = $http;
    }

    private urlBase: string = '/api/events';
    private $http: angular.IHttpService;

    getEvents(historic: boolean) {
        if (historic)
            return this.$http.get(this.urlBase + "?includeHistoric=true");
        return this.$http.get(this.urlBase);
    }

    getEvent(id: number) {
        return this.$http.get(this.urlBase + "/" + id);
    }

    addEvent(event: any) {
        event = $.extend({}, event);

        if (event.DipsNumber === '' || event.DipsNumber == null)
            event.DipsNumber = 0;

        event.EndTime = moment(event.EndTime).format("hh:mm");
        event.StartTime = moment(event.StartTime).format("hh:mm");

        return this.$http({
            method: 'POST',
            url: this.urlBase,
            data: event
        });
    }

    patchEvent(id: number, patch: any) {
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