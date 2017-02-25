var ModalController = (function () {
    function ModalController($uibModalInstance) {
        this.cancel = function () {
            this.$uibModalInstance.dismiss('cancel');
        };
        this.$uibModalInstance = $uibModalInstance;
    }
    return ModalController;
}());
//# sourceMappingURL=modal-controller.js.map