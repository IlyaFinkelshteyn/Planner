var ScheduleItemService = (function () {
    function ScheduleItemService($http) {
        this.urlBase = '/api/scheduleItems';
        this.$http = $http;
    }
    ScheduleItemService.prototype.deleteItem = function (id) {
        return this.$http({
            method: 'DELETE',
            url: this.urlBase + "/" + id
        });
    };
    ScheduleItemService.prototype.addItem = function (eventId, item) {
        item = $.extend({}, item);
        return this.$http({
            method: 'POST',
            url: this.urlBase + "?eventId=" + eventId,
            data: item
        });
    };
    ScheduleItemService.prototype.patchItem = function (id, patch) {
        return this.$http({
            method: 'PATCH',
            url: this.urlBase + "/" + id,
            data: patch,
            headers: {
                'Content-Type': 'application/json-patch+json'
            }
        });
    };
    return ScheduleItemService;
}());
ScheduleItemService.$inject = ['$http'];
angular.module('app').service('ScheduleItemService', ScheduleItemService);
//# sourceMappingURL=schedule-item-service.js.map