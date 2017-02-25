var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var ChangeConsiderationsController = (function (_super) {
    __extends(ChangeConsiderationsController, _super);
    function ChangeConsiderationsController($uibModalInstance, soloRespondingExpected, highSpeedRoadsAtEvent, expectingBadWeather, hasSeriousHistory, widerDistribution) {
        var _this = _super.call(this, $uibModalInstance) || this;
        _this.soloRespondingExpected = soloRespondingExpected;
        _this.highSpeedRoadsAtEvent = highSpeedRoadsAtEvent;
        _this.expectingBadWeather = expectingBadWeather;
        _this.hasSeriousHistory = hasSeriousHistory;
        _this.widerDistribution = widerDistribution;
        return _this;
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
    return ChangeConsiderationsController;
}(ModalController));
ChangeConsiderationsController.$inject = ['$uibModalInstance', 'soloRespondingExpected', 'highSpeedRoadsAtEvent', 'expectingBadWeather', 'hasSeriousHistory', 'widerDistribution'];
angular.module('app').controller('ChangeConsiderationsController', ChangeConsiderationsController);
//# sourceMappingURL=change-considerations-controller.js.map