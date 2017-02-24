/// <reference path="./moment.d.ts" />
angular
    .module('app')
    .factory('EventService', EventService);
EventService.$inject = ['$http'];
var EventService = (function () {
    function EventService($http) {
        this.urlBase = '/api/events';
        this.$http = $http;
    }
    EventService.prototype.getEvents = function (historic) {
        if (historic)
            return this.$http.get(this.urlBase + "?includeHistoric=true");
        return this.$http.get(this.urlBase);
    };
    EventService.prototype.getEvent = function (id) {
        return this.$http.get(this.urlBase + "/" + id);
    };
    EventService.prototype.addEvent = function (event) {
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
    };
    EventService.prototype.patchEvent = function (id, patch) {
        return this.$http({
            method: 'PATCH',
            url: this.urlBase + "/" + id,
            data: patch,
            headers: {
                'Content-Type': 'application/json-patch+json'
            }
        });
    };
    return EventService;
}());