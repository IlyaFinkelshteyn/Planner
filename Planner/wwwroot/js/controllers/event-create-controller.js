var EventCreateController = (function () {
    function EventCreateController($location, EventService) {
        this.data = {
            cyclistsRequested: 2,
            date: new Date(),
            dipsNumber: null,
            endTime: new Date(0, 0, 0, 17),
            location: '',
            name: '',
            startTime: new Date(0, 0, 0, 9),
            status: 0 /* Unconfirmed */,
            dateConfirmed: false,
        };
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
EventCreateController.$inject = ['$location', 'EventService'];
angular.module('app').controller('EventCreateController', EventCreateController);
//# sourceMappingURL=event-create-controller.js.map