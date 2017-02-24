angular
    .module('app')
    .controller('ChangeDescriptionController', ChangeDescriptionController);
ChangeDescriptionController.$inject = ['$uibModalInstance', 'description'];
var ChangeDescriptionController = (function () {
    function ChangeDescriptionController($uibModalInstance, description) {
        this.description = description;
        this.$uibModalInstance = $uibModalInstance;
    }
    ChangeDescriptionController.prototype.submit = function () {
        this.$uibModalInstance.close({
            description: this.description
        });
    };
    ChangeDescriptionController.prototype.cancel = function () {
        this.$uibModalInstance.dismiss('cancel');
    };
    return ChangeDescriptionController;
}());
