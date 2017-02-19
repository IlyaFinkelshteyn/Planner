(function () {
    'use strict';

    angular
        .module('app')
        .controller('AddItemController', AddItemController);

    AddItemController.$inject = ['$uibModalInstance', 'itemName'];

    function AddItemController($uibModalInstance, itemName) {
        /* jshint validthis:true */
        var vm = this;

        vm.itemName = itemName;
        vm.name = '';

        vm.submit = function () {
            $uibModalInstance.close({
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