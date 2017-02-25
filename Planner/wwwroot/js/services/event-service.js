/// <reference path="./moment.d.ts" />
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
        if (!event.dipsNumber)
            event.dipsNumber = 0;
        event.endTime = moment(event.endTime).format("hh:mm");
        event.startTime = moment(event.startTime).format("hh:mm");
        return this.$http({
            method: 'POST',
            url: this.urlBase,
            data: event
        });
    };
    EventService.prototype.patchItem = function (id, patch) {
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
EventService.$inject = ['$http'];
angular.module('app').service('EventService', EventService);
//# sourceMappingURL=event-service.js.map