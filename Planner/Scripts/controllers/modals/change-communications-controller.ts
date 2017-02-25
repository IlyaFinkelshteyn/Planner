class ChangeCommunicationsController extends ModalController {
    constructor($uibModalInstance: angular.ui.bootstrap.IModalServiceInstance,
        usingSJARadio: boolean, usingAirwave: boolean, radioChannel: string,
        fallbackRadioChannel: string, controlPhoneNumber: string, cruTrackingInUse: boolean) {
        super($uibModalInstance);

        this.usingSJARadio = usingSJARadio;
        this.usingAirwave = usingAirwave;
        this.radioChannel = radioChannel;
        this.fallbackRadioChannel = fallbackRadioChannel;
        this.controlPhoneNumber = controlPhoneNumber;
        this.cruTrackingInUse = cruTrackingInUse;
    }

    usingSJARadio: boolean;
    usingAirwave: boolean;
    radioChannel: string;
    fallbackRadioChannel: string;
    controlPhoneNumber: string;
    cruTrackingInUse: boolean;

    static $inject = ['$uibModalInstance', 'usingSJARadio', 'usingAirwave', 'radioChannel', 'fallbackRadioChannel', 'controlPhoneNumber', 'cruTrackingInUse'];

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
}

angular.module('app').controller('ChangeCommunicationsController', ChangeCommunicationsController);
