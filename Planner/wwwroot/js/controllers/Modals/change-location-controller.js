angular
    .module('app')
    .controller('ChangeLocationController', ChangeLocationController);
ChangeLocationController.$inject = ['$uibModalInstance', 'location', 'postCode'];
var ChangeLocationController = (function () {
    function ChangeLocationController($uibModalInstance, location, postCode) {
        /* jshint validthis:true */
        var vm = this;
        this.$uibModalInstance = $uibModalInstance;
        vm.location = location;
        vm.postCode = postCode;
    }
    ChangeLocationController.prototype.submit = function () {
        this.$uibModalInstance.close({
            location: this.location,
            postCode: this.postCode
        });
    };
    ChangeLocationController.prototype.cancel = function () {
        this.$uibModalInstance.dismiss('cancel');
    };
    return ChangeLocationController;
}());
