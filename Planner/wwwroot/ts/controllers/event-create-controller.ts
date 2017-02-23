angular
    .module('app')
    .controller('EventCreateController', EventCreateController);

EventCreateController.$inject = ['$location', 'EventService'];

class EventCreateController {
    constructor($location: angular.ILocationService, EventService: EventService) {
        this.$location = $location;
        this.EventService = EventService;
    }

    $location: angular.ILocationService;
    EventService: EventService

    data = {
        CyclistsRequested: 2,
        Date: new Date(),
        DipsNumber: '',
        EndTime: new Date(0, 0, 0, 17),
        Location: '',
        Name: '',
        StartTime: new Date(0, 0, 0, 9),
        Status: '0',
        DateConfirmed: false,
    };

    debug = function() { return angular.toJson(this.data); }

    submit = function() {
        this.EventService.addEvent(this.data).then(
            function(response: any) {
                this.$location.path('/Event/' + response.data.id);
            }
        );
    }
}