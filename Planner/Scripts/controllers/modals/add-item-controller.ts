class AddItemController extends ModalController {
    constructor($uibModalInstance: angular.ui.bootstrap.IModalServiceInstance,
        itemName: string) {
        super($uibModalInstance);
        this.itemName = itemName;
    }

    static $inject = ['$uibModalInstance', 'itemName'];

    itemName: string;
    name = '';

    submit = function () {
        this.$uibModalInstance.close({
            name: this.name
        });
    }
}

angular.module('app').controller('AddItemController', AddItemController);