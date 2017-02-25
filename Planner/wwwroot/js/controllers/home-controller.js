var HomeController = (function () {
    function HomeController($location, EventService, FlagService) {
        this.loading = true;
        this.page = 0;
        this.pageCount = 0;
        this.pageSize = 10;
        this.filter = "";
        this.needsEmail = false;
        this.statusToListGroupItemClass = function (status) {
            return this.FlagService.statusToListGroupItemClass(status);
        };
        this.statusToText = function (status) {
            return this.FlagService.statusToText(status);
        };
        this.flagToLabelClass = function (flag) {
            return this.FlagService.flagToLabelClass(flag);
        };
        this.flagToNames = function (flag) {
            return this.FlagService.flagToNames(flag);
        };
        this.$location = $location;
        this.EventService = EventService;
        this.FlagService = FlagService;
        this.historic = $location.search().historic === 'true';
        this.title = this.historic ? 'All Events' : 'Upcoming Events';
        this.activate();
    }
    HomeController.prototype.pages = function () {
        return Array.apply(null, { length: this.pageCount }).map(Number.call, Number);
    };
    ;
    HomeController.prototype.setPage = function (page) {
        if (page < this.pageCount)
            this.page = page;
    };
    ;
    HomeController.prototype.statusToLabelClass = function (status) {
        return this.FlagService.statusToLabelClass(status);
    };
    ;
    HomeController.prototype.activate = function () {
        var vm = this;
        this.EventService.getEvents(this.historic).then(function (response) {
            vm.data = response.data;
            vm.pageCount = Math.ceil(vm.data.length / vm.pageSize);
            vm.loading = false;
            vm.needsEmail = !vm.historic && $.grep(vm.data, function (event, n) {
                return $.inArray(2 /* NeedsEmailing */, event.Flags) !== -1;
            }).length > 0;
        });
    };
    return HomeController;
}());
HomeController.$inject = ['$location', 'EventService', 'FlagService'];
angular.module('app').controller('HomeController', HomeController);
//# sourceMappingURL=home-controller.js.map