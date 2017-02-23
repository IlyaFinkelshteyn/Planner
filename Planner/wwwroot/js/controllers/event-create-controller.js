angular
    .module('app')
    .controller('EventCreateController', EventCreateController);
EventCreateController.$inject = ['$location', 'EventService'];
var EventCreateController = (function () {
    function EventCreateController($location, EventService) {
        this.data = {
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
        this.debug = function () { return angular.toJson(this.data); };
        this.submit = function () {
            this.EventService.addEvent(this.data).then(function (response) {
                this.$location.path('/Event/' + response.data.id);
            });
        };
        this.$location = $location;
        this.EventService = EventService;
    }
    return EventCreateController;
}());
