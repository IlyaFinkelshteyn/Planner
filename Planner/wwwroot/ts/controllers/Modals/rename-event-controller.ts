angular
    .module('app')
    .controller('RenameEventController', RenameEventController);

RenameEventController.$inject = ['$uibModalInstance', 'dipsNumber', 'name'];

class RenameEventController {
    constructor($uibModalInstance: angular.ui.bootstrap.IModalServiceInstance,
        dipsNumber: number, name: string) {
        this.$uibModalInstance = $uibModalInstance;
        this.dipsNumber = dipsNumber;
        this.name = name;
    }

    private $uibModalInstance: angular.ui.bootstrap.IModalServiceInstance;
    dipsNumber: number;
    name: string;

    submit = function () {
        this.$uibModalInstance.close({
            dipsNumber: this.dipsNumber,
            name: this.name
        });
    }

    cancel = function () {
        this.$uibModalInstance.dismiss('cancel');
    }
}