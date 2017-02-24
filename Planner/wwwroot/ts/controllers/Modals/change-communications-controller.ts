angular
    .module('app')
    .controller('ChangeCommunicationsController', ChangeCommunicationsController);

ChangeCommunicationsController.$inject = ['$uibModalInstance', 'usingSJARadio', 'usingAirwave', 'radioChannel', 'fallbackRadioChannel', 'controlPhoneNumber', 'cruTrackingInUse'];

class ChangeCommunicationsController {
    constructor($uibModalInstance: angular.ui.bootstrap.IModalServiceInstance,
        usingSJARadio: boolean, usingAirwave: boolean, radioChannel: string,
        fallbackRadioChannel: string, controlPhoneNumber: string, cruTrackingInUse: boolean) {
        this.$uibModalInstance = $uibModalInstance;
        this.usingSJARadio = usingSJARadio;
        this.usingAirwave = usingAirwave;
        this.radioChannel = radioChannel;
        this.fallbackRadioChannel = fallbackRadioChannel;
        this.controlPhoneNumber = controlPhoneNumber;
        this.cruTrackingInUse = cruTrackingInUse;
    }

    private $uibModalInstance: angular.ui.bootstrap.IModalServiceInstance;
    usingSJARadio: boolean;
    usingAirwave: boolean;
    radioChannel: string;
    fallbackRadioChannel: string;
    controlPhoneNumber: string;
    cruTrackingInUse: boolean;

    submit() {
        this.$uibModalInstance.close({
            usingSJARadio: this.usingSJARadio,
            usingAirwave: this.usingAirwave,
            radioChannel: this.radioChannel,
            fallbackRadioChannel: this.fallbackRadioChannel,
            controlPhoneNumber: this.controlPhoneNumber,
            cruTrackingInUse: this.cruTrackingInUse
        });
    }

    cancel() {
        this.$uibModalInstance.dismiss('cancel');
    }
}