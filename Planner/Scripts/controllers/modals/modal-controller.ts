class ModalController {
    constructor($uibModalInstance: angular.ui.bootstrap.IModalServiceInstance) {
        this.$uibModalInstance = $uibModalInstance;
    }

    $uibModalInstance: angular.ui.bootstrap.IModalServiceInstance;

    cancel() {
        this.$uibModalInstance.dismiss('cancel');
    }
}