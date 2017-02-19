(function () {
    'use strict';

    angular
        .module('app')
        .controller('ChangeLocationController', ChangeLocationController);

    ChangeLocationController.$inject = ['$uibModalInstance', 'location', 'postCode'];

    function ChangeLocationController($uibModalInstance, location, postCode) {
        /* jshint validthis:true */
        var vm = this;

        vm.location = location;
        vm.postCode = postCode;

        vm.submit = function () {
            $uibModalInstance.close({
                location: vm.location,
                postCode: vm.postCode
            });
        }

        vm.cancel = function () {
            $uibModalInstance.dismiss('cancel');
        }

        activate();

        function activate() { }
    }
})();