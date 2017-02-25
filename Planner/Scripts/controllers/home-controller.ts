class HomeController {
    constructor($location: angular.ILocationService, EventService: EventService, FlagService: FlagService) {
        this.$location = $location;
        this.EventService = EventService;
        this.FlagService = FlagService;
        this.historic = $location.search().historic === 'true';
        this.title = this.historic ? 'All Events' : 'Upcoming Events';
        this.activate();
    }

    static $inject = ['$location', 'EventService', 'FlagService'];
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
    needsEmail = false;
    data: IEventSummary[];


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
        let vm = this;
        this.EventService.getEvents(this.historic).then(function(response) {
            vm.data = response.data;

            vm.pageCount = Math.ceil(vm.data.length / vm.pageSize);

            vm.loading = false;

            vm.needsEmail = !vm.historic && $.grep(vm.data, function(event: any, n) {
                return $.inArray(Flags.NeedsEmailing, event.Flags) !== -1;
            }).length > 0;
        });
    }
}

angular.module('app').controller('HomeController', HomeController);