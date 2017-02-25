class ChangeConsiderationsController extends ModalController {
    constructor($uibModalInstance: angular.ui.bootstrap.IModalServiceInstance,
        soloRespondingExpected: boolean, highSpeedRoadsAtEvent: boolean,
        expectingBadWeather: boolean, hasSeriousHistory: boolean, widerDistribution: boolean) {
        super($uibModalInstance);
        this.soloRespondingExpected = soloRespondingExpected;
        this.highSpeedRoadsAtEvent = highSpeedRoadsAtEvent;
        this.expectingBadWeather = expectingBadWeather;
        this.hasSeriousHistory = hasSeriousHistory;
        this.widerDistribution = widerDistribution;
    }

    static $inject = ['$uibModalInstance', 'soloRespondingExpected', 'highSpeedRoadsAtEvent', 'expectingBadWeather', 'hasSeriousHistory', 'widerDistribution'];

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
}

angular.module('app').controller('ChangeConsiderationsController', ChangeConsiderationsController);