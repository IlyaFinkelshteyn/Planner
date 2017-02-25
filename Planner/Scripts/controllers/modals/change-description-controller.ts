class ChangeDescriptionController extends ModalController {
    constructor($uibModalInstance: angular.ui.bootstrap.IModalServiceInstance, description: string) {
        super($uibModalInstance);
        this.description = description;
    }

    static $inject = ['$uibModalInstance', 'description'];

    description: string;

    submit() {
        this.$uibModalInstance.close({
            description: this.description
        });
    }
}

angular.module('app').controller('ChangeDescriptionController', ChangeDescriptionController);