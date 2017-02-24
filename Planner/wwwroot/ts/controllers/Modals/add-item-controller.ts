angular
    .module('app')
    .controller('AddItemController', AddItemController);

AddItemController.$inject = ['$uibModalInstance', 'itemName'];

class AddItemController {
    constructor($uibModalInstance: angular.ui.bootstrap.IModalServiceInstance, itemName: string) {
        this.$uibModalInstance = $uibModalInstance;
        this.itemName = itemName;
    }
    /* jshint validthis:true */
    $uibModalInstance: angular.ui.bootstrap.IModalServiceInstance;
    itemName: string;
    name = '';

    submit = function() {
        this.$uibModalInstance.close({
            name: this.name
        });
    }

    cancel = function() {
        this.$uibModalInstance.dismiss('cancel');
    }
}