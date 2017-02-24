angular
    .module('app')
    .controller('AddItemController', AddItemController);
AddItemController.$inject = ['$uibModalInstance', 'itemName'];
var AddItemController = (function () {
    function AddItemController($uibModalInstance, itemName) {
        this.name = '';
        this.submit = function () {
            this.$uibModalInstance.close({
                name: this.name
            });
        };
        this.cancel = function () {
            this.$uibModalInstance.dismiss('cancel');
        };
        this.$uibModalInstance = $uibModalInstance;
        this.itemName = itemName;
    }
    return AddItemController;
}());
