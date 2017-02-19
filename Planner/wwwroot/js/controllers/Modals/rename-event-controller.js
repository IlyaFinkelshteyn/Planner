(function () {
    'use strict';

    angular
        .module('app')
        .controller('RenameEventController', RenameEventController);

    RenameEventController.$inject = ['$uibModalInstance', 'dipsNumber', 'name'];

    function RenameEventController($uibModalInstance, dipsNumber, name) {
        /* jshint validthis:true */
        var vm = this;

        vm.dipsNumber = dipsNumber;
        vm.name = name;

        vm.submit = function () {
            $uibModalInstance.close({
                dipsNumber: vm.dipsNumber,
                name: vm.name
            });
        }

        vm.cancel = function () {
            $uibModalInstance.dismiss('cancel');
        }

        activate();

        function activate() { }
    }
})();