angular
    .module('app')
    .controller('ChangeConsiderationsController', ChangeConsiderationsController);

ChangeConsiderationsController.$inject = ['$uibModalInstance', 'soloRespondingExpected', 'highSpeedRoadsAtEvent', 'expectingBadWeather', 'hasSeriousHistory', 'widerDistribution'];

class ChangeConsiderationsController {
    constructor($uibModalInstance: angular.ui.bootstrap.IModalServiceInstance,
        soloRespondingExpected: boolean, highSpeedRoadsAtEvent: boolean,
        expectingBadWeather: boolean, hasSeriousHistory: boolean, widerDistribution: boolean) {
        this.$uibModalInstance = $uibModalInstance;
        this.soloRespondingExpected = soloRespondingExpected;
        this.highSpeedRoadsAtEvent = highSpeedRoadsAtEvent;
        this.expectingBadWeather = expectingBadWeather;
        this.hasSeriousHistory = hasSeriousHistory;
        this.widerDistribution = widerDistribution;
    }
    private $uibModalInstance: angular.ui.bootstrap.IModalServiceInstance;

    soloRespondingExpected: boolean;
    highSpeedRoadsAtEvent: boolean;
    expectingBadWeather: boolean;
    hasSeriousHistory: boolean;
    widerDistribution: boolean;

    submit() {
        this.$uibModalInstance.close({
            soloRespondingExpected: this.soloRespondingExpected,
            highSpeedRoadsAtEvent: this.highSpeedRoadsAtEvent,
            expectingBadWeather: this.expectingBadWeather,
            hasSeriousHistory: this.hasSeriousHistory,
            widerDistribution: this.widerDistribution
        });
    }

    cancel() {
        this.$uibModalInstance.dismiss('cancel');
    }
}