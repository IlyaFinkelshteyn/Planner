angular
    .module('app')
    .controller('ChangeCommunicationsController', ChangeCommunicationsController);
ChangeCommunicationsController.$inject = ['$uibModalInstance', 'usingSJARadio', 'usingAirwave', 'radioChannel', 'fallbackRadioChannel', 'controlPhoneNumber', 'cruTrackingInUse'];
var ChangeCommunicationsController = (function () {
    function ChangeCommunicationsController($uibModalInstance, usingSJARadio, usingAirwave, radioChannel, fallbackRadioChannel, controlPhoneNumber, cruTrackingInUse) {
        this.$uibModalInstance = $uibModalInstance;
        this.usingSJARadio = usingSJARadio;
        this.usingAirwave = usingAirwave;
        this.radioChannel = radioChannel;
        this.fallbackRadioChannel = fallbackRadioChannel;
        this.controlPhoneNumber = controlPhoneNumber;
        this.cruTrackingInUse = cruTrackingInUse;
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
    ChangeCommunicationsController.prototype.cancel = function () {
        this.$uibModalInstance.dismiss('cancel');
    };
    return ChangeCommunicationsController;
}());
