angular
    .module('app')
    .controller('HomeController', HomeController);

HomeController.$inject = ['$location', 'EventService', 'FlagService'];

class HomeController {
    constructor($location: angular.ILocationService, EventService: EventService, FlagService: FlagService) {
        this.$location = $location;
        this.EventService = EventService;
        this.FlagService = FlagService;
        this.historic = $location.search().historic === 'true';
        this.title = this.historic ? 'All Events' : 'Upcoming Events';
        this.activate();
    }

    $location: angular.ILocationService;
    EventService: EventService;
    FlagService: FlagService;

    historic: boolean;
    title: string;
    loading = true;
    page = 0;
    pageCount = 0;
    pageSize = 10;
    filter = "";

    pages() {
        return Array.apply(null, { length: this.pageCount }).map(Number.call, Number);
    };

    setPage(page: number) {
        if (page < this.pageCount)
            this.page = page;
    };

    statusToLabelClass(status: EventStatus) {
        return this.FlagService.statusToLabelClass(status);
    };

    statusToListGroupItemClass = function(status: EventStatus) {
        return this.FlagService.statusToListGroupItemClass(status);
    };

    statusToText = function(status: EventStatus) {
        return this.FlagService.statusToText(status);
    };

    flagToLabelClass = function(flag: Flags) {
        return this.FlagService.flagToLabelClass(flag);
    };

    flagToNames = function(flag: Flags) {
        return this.FlagService.flagToNames(flag);
    };

    activate() {
        this.EventService.getEvents(this.historic).then(function(response) {
            this.data = response.data;

            this.pageCount = Math.ceil(this.data.length / this.pageSize);

            this.loading = false;

            this.needsEmail = !this.historic && $.grep(this.data, function(event: any, n) {
                return $.inArray(this.FlagService.flags.NeedsEmailing, event.Flags) !== -1;
            });
        });
    }
}