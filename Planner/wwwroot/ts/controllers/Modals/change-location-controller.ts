angular
    .module('app')
    .controller('ChangeLocationController', ChangeLocationController);

ChangeLocationController.$inject = ['$uibModalInstance', 'location', 'postCode'];

class ChangeLocationController {
    constructor($uibModalInstance: angular.ui.bootstrap.IModalServiceInstance,
        location: string, postCode: string) {
        /* jshint validthis:true */
        var vm = this;
        this.$uibModalInstance = $uibModalInstance;
        vm.location = location;
        vm.postCode = postCode;
    }
    $uibModalInstance: angular.ui.bootstrap.IModalServiceInstance;
    location: string;
    postCode: string;

    submit() {
        this.$uibModalInstance.close({
            location: this.location,
            postCode: this.postCode
        });
    }

    cancel() {
        this.$uibModalInstance.dismiss('cancel');
    }
}