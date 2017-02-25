var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var ChangeCommunicationsController = (function (_super) {
    __extends(ChangeCommunicationsController, _super);
    function ChangeCommunicationsController($uibModalInstance, usingSJARadio, usingAirwave, radioChannel, fallbackRadioChannel, controlPhoneNumber, cruTrackingInUse) {
        var _this = _super.call(this, $uibModalInstance) || this;
        _this.usingSJARadio = usingSJARadio;
        _this.usingAirwave = usingAirwave;
        _this.radioChannel = radioChannel;
        _this.fallbackRadioChannel = fallbackRadioChannel;
        _this.controlPhoneNumber = controlPhoneNumber;
        _this.cruTrackingInUse = cruTrackingInUse;
        return _this;
    }
    ChangeCommunicationsController.prototype.submit = function () {
        this.$uibModalInstance.close({
            usingSJARadio: this.usingSJARadio,
            usingAirwave: this.usingAirwave,
            radioChannel: this.radioChannel,
            fallbackRadioChannel: this.fallbackRadioChannel,
            controlPhoneNumber: this.controlPhoneNumber,
            cruTrackingInUse: this.cruTrackingInUse
        });
    };
    return ChangeCommunicationsController;
}(ModalController));
ChangeCommunicationsController.$inject = ['$uibModalInstance', 'usingSJARadio', 'usingAirwave', 'radioChannel', 'fallbackRadioChannel', 'controlPhoneNumber', 'cruTrackingInUse'];
angular.module('app').controller('ChangeCommunicationsController', ChangeCommunicationsController);
//# sourceMappingURL=change-communications-controller.js.map