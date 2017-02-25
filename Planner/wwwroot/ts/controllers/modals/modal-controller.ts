class ModalController {
    constructor($uibModalInstance: angular.ui.bootstrap.IModalServiceInstance) {
        this.$uibModalInstance = $uibModalInstance;
    }

    $uibModalInstance: angular.ui.bootstrap.IModalServiceInstance;

    cancel = function () {
        this.$uibModalInstance.dismiss('cancel');
    }
}