(function () {
    'use strict';

    angular
        .module('app')
        .controller('ChangeScheduleItemController', ChangeScheduleItemController);

    ChangeScheduleItemController.$inject = ['$uibModalInstance', 'mode', 'time', 'action'];

    function ChangeScheduleItemController($uibModalInstance, mode, time, action) {
        /* jshint validthis:true */
        var vm = this;

        vm.mode = mode;
        vm.time = moment(time, 'hh:mm').toDate();
        vm.action = action;

        vm.title = function () {
            switch (mode) {
                case "update":
                    return "Update Schedule Item";
                case "add":
                    return "Add Schedule Item";
                default:
                    return "";
            }
        };

        vm.submit = function () {
            $uibModalInstance.close({
                time: moment(vm.time).format('hh:mm'),
                action: vm.action
            });
        };

        vm.cancel = function () {
            $uibModalInstance.dismiss('cancel');
        };

        activate();

        function activate() { }
    }
})();