class ChangeLocationController extends ModalController {
    constructor($uibModalInstance: angular.ui.bootstrap.IModalServiceInstance,
        location: string, postCode: string) {
        super($uibModalInstance);
        this.location = location;
        this.postCode = postCode;
    }

    static $inject = ['$uibModalInstance', 'location', 'postCode'];
    location: string;
    postCode: string;

    submit() {
        this.$uibModalInstance.close({
            location: this.location,
            postCode: this.postCode
        });
    }
}

angular.module('app').controller('ChangeLocationController', ChangeLocationController);