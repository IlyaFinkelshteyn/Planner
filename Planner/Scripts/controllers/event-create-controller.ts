class EventCreateController {
    constructor($location: angular.ILocationService, EventService: EventService) {
        this.$location = $location;
        this.EventService = EventService;
    }

    static $inject = ['$location', 'EventService'];
    $location: angular.ILocationService;
    EventService: EventService

    data: IEventCreate = {
        cyclistsRequested: 2,
        date: new Date(),
        dipsNumber: null,
        endTime: new Date(0, 0, 0, 17),
        location: '',
        name: '',
        startTime: new Date(0, 0, 0, 9),
        status: EventStatus.Unconfirmed,
        dateConfirmed: false,
    };

    submit = function () {
        this.EventService.addEvent(this.data).then(
            function (response: angular.IHttpPromiseCallbackArg<IdResult>) {
                this.$location.path('/Event/' + response.data.id);
            }
        );
    }
}

angular.module('app').controller('EventCreateController', EventCreateController);