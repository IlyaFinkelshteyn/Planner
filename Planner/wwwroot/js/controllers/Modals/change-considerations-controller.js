angular
    .module('app')
    .controller('ChangeConsiderationsController', ChangeConsiderationsController);
ChangeConsiderationsController.$inject = ['$uibModalInstance', 'soloRespondingExpected', 'highSpeedRoadsAtEvent', 'expectingBadWeather', 'hasSeriousHistory', 'widerDistribution'];
var ChangeConsiderationsController = (function () {
    function ChangeConsiderationsController($uibModalInstance, soloRespondingExpected, highSpeedRoadsAtEvent, expectingBadWeather, hasSeriousHistory, widerDistribution) {
        this.$uibModalInstance = $uibModalInstance;
        this.soloRespondingExpected = soloRespondingExpected;
        this.highSpeedRoadsAtEvent = highSpeedRoadsAtEvent;
        this.expectingBadWeather = expectingBadWeather;
        this.hasSeriousHistory = hasSeriousHistory;
        this.widerDistribution = widerDistribution;
    }
    ChangeConsiderationsController.prototype.submit = function () {
        this.$uibModalInstance.close({
            soloRespondingExpected: this.soloRespondingExpected,
            highSpeedRoadsAtEvent: this.highSpeedRoadsAtEvent,
            expectingBadWeather: this.expectingBadWeather,
            hasSeriousHistory: this.hasSeriousHistory,
            widerDistribution: this.widerDistribution
        });
    };
    ChangeConsiderationsController.prototype.cancel = function () {
        this.$uibModalInstance.dismiss('cancel');
    };
    return ChangeConsiderationsController;
}());
