/// <reference path="./moment.d.ts" />

interface IdResult {
    id: number;
}

class EventService implements IItemService<IEventDetail> {
    constructor($http: angular.IHttpService) {
        this.$http = $http;
    }

    private urlBase: string = '/api/events';
    private $http: angular.IHttpService;
    static $inject = ['$http'];

    getEvents(historic: boolean) {
        if (historic)
            return this.$http.get<IEventSummary[]>(this.urlBase + "?includeHistoric=true");
        return this.$http.get<IEventSummary[]>(this.urlBase);
    }

    getEvent(id: number) {
        return this.$http.get<IEventDetail>(this.urlBase + "/" + id);
    }

    addEvent(event: IEventCreate) {
        event = $.extend({}, event);

        if (!event.dipsNumber)
            event.dipsNumber = 0;

        event.endTime = moment(event.endTime).format("hh:mm");
        event.startTime = moment(event.startTime).format("hh:mm");

        return this.$http<IdResult>({
            method: 'POST',
            url: this.urlBase,
            data: event
        });
    }

    patchItem(id: number, patch: any) {
        return this.$http<IEventDetail>({
            method: 'PATCH',
            url: this.urlBase + "/" + id,
            data: patch,
            headers: {
                'Content-Type': 'application/json-patch+json'
            }
        });
    }
}

angular.module('app').service('EventService', EventService);