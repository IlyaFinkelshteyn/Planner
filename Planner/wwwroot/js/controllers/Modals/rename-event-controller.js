angular
    .module('app')
    .controller('RenameEventController', RenameEventController);
RenameEventController.$inject = ['$uibModalInstance', 'dipsNumber', 'name'];
var RenameEventController = (function () {
    function RenameEventController($uibModalInstance, dipsNumber, name) {
        this.submit = function () {
            this.$uibModalInstance.close({
                dipsNumber: this.dipsNumber,
                name: this.name
            });
        };
        this.cancel = function () {
            this.$uibModalInstance.dismiss('cancel');
        };
        this.$uibModalInstance = $uibModalInstance;
        this.dipsNumber = dipsNumber;
        this.name = name;
    }
    return RenameEventController;
}());
