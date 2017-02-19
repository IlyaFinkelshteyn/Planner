(function () {
    'use strict';

    angular
        .module('app')
        .controller('EventCreateController', EventCreateController);

    EventCreateController.$inject = ['$location', 'EventService'];

    function EventCreateController($location, EventService) {
        /* jshint validthis:true */
        var vm = this;

        vm.data = {
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

        vm.debug = function () { return angular.toJson(vm.data); }

        vm.submit = function () {
            EventService.addEvent(vm.data).then(
                function (response) {
                    $location.path('/Event/' + response.data.id);
                }
            );
        }

        activate();

        function activate() { }
    }
})();