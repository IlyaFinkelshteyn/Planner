(function () {
    'use strict';

    angular
        .module('app')
        .controller('HomeController', HomeController);

    HomeController.$inject = ['$location', 'EventService', 'FlagService'];

    function HomeController($location, EventService, FlagService) {
        /* jshint validthis:true */
        var vm = this;

        vm.historic = $location.search().historic === 'true';
        vm.title = vm.historic ? 'All Events' : 'Upcoming Events';
        vm.loading = true;
        vm.page = 0;
        vm.pageCount = 0;
        vm.pageSize = 10;
        vm.filter = "";

        vm.pages = function () {
            return Array.apply(null, { length: vm.pageCount }).map(Number.call, Number);
        };

        vm.setPage = function (page) {
            if (page < vm.pageCount)
                vm.page = page;
        };

        vm.statusToLabelClass = function (status) {
            return FlagService.statusToLabelClass(status);
        };

        vm.statusToListGroupItemClass = function (status) {
            return FlagService.statusToListGroupItemClass(status);
        };

        vm.statusToText = function (status) {
            return FlagService.statusToText(status);
        };

        vm.flagToLabelClass = function (flag) {
            return FlagService.flagToLabelClass(flag);
        };

        vm.flagToNames = function (flag) {
            return FlagService.flagToNames(flag);
        };

        activate();

        function activate() {
            EventService.getEvents(vm.historic).then(function (response) {
                vm.data = response.data;

                vm.pageCount = Math.ceil(vm.data.length / vm.pageSize);

                vm.loading = false;

                vm.needsEmail = !vm.historic && $.grep(vm.data, function (n, event) {
                    return $.inArray(FlagService.flags.NeedsEmailing, event.Flags) !== -1;
                });
            });
        }
    }
})();