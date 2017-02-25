class RenameEventController extends ModalController {
    constructor($uibModalInstance: angular.ui.bootstrap.IModalServiceInstance,
        dipsNumber: number, name: string) {
        super($uibModalInstance);
        this.dipsNumber = dipsNumber;
        this.name = name;
    }

    static $inject = ['$uibModalInstance', 'dipsNumber', 'name'];
    dipsNumber: number;
    name: string;

    submit = function () {
        this.$uibModalInstance.close({
            dipsNumber: this.dipsNumber,
            name: this.name
        });
    }
}

angular.module('app').controller('RenameEventController', RenameEventController);