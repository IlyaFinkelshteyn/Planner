(function () {
    'use strict';

    angular
        .module('app')
        .controller('ChangeDescriptionController', ChangeDescriptionController);

    ChangeDescriptionController.$inject = ['$uibModalInstance', 'description'];

    function ChangeDescriptionController($uibModalInstance, description) {
        /* jshint validthis:true */
        var vm = this;

        vm.description = description;

        vm.submit = function () {
            $uibModalInstance.close({
                description: vm.description
            });
        }

        vm.cancel = function () {
            $uibModalInstance.dismiss('cancel');
        }

        activate();

        function activate() { }
    }
})();