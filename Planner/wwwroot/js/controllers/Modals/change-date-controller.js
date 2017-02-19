(function () {
    'use strict';

    angular
        .module('app')
        .controller('ChangeDateController', ChangeDateController);

    ChangeDateController.$inject = ['$uibModalInstance', 'date', 'startTime', 'endTime','dateConfirmed'];

    function ChangeDateController($uibModalInstance, date, startTime, endTime, dateConfirmed) {
        /* jshint validthis:true */
        var vm = this;

        vm.date = moment(date).toDate();
        vm.startTime =  moment(startTime, 'hh:mm').toDate();
        vm.endTime = moment(endTime, 'hh:mm').toDate();
        vm.dateConfirmed = dateConfirmed;

        vm.submit = function () {
            $uibModalInstance.close({
                date: moment(vm.date).format(),
                startTime: moment(vm.startTime).format('hh:mm'),
                endTime: moment(vm.endTime).format('hh:mm'),
                dateConfirmed: vm.dateConfirmed
            });
        }

        vm.cancel = function () {
            $uibModalInstance.dismiss('cancel');
        }

        activate();

        function activate() { }
    }
})();