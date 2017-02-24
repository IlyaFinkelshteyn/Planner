angular
    .module('app')
    .controller('ChangeDescriptionController', ChangeDescriptionController);

ChangeDescriptionController.$inject = ['$uibModalInstance', 'description'];

class ChangeDescriptionController {
    constructor($uibModalInstance: angular.ui.bootstrap.IModalServiceInstance, description: string) {
        this.description = description;
        this.$uibModalInstance = $uibModalInstance;
    }

    $uibModalInstance: angular.ui.bootstrap.IModalServiceInstance;
    description: string;

    submit() {
        this.$uibModalInstance.close({
            description: this.description
        });
    }

    cancel() {
        this.$uibModalInstance.dismiss('cancel');
    }
}