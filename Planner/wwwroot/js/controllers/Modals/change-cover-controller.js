(function () {
    'use strict';

    angular
        .module('app')
        .controller('ChangeCoverController', ChangeCoverController);

    ChangeCoverController.$inject = ['$uibModalInstance', 'firstAidersAvailable', 'cyclistsRequested', 'firstAidUnitsAvailable',
        'ambulancesAvailable', 'paramedicsAvailable', 'doctorsPresent'];

    function ChangeCoverController($uibModalInstance, firstAidersAvailable, cyclistsRequested,
        firstAidUnitsAvailable, ambulancesAvailable, paramedicsAvailable, doctorsPresent) {
        /* jshint validthis:true */
        var vm = this;

        vm.firstAiders = firstAidersAvailable;
        vm.cyclists = cyclistsRequested;
        vm.firstAidUnits = firstAidUnitsAvailable;
        vm.ambulances = ambulancesAvailable;
        vm.paramedicsAvailable = paramedicsAvailable;
        vm.doctorsAvailable = doctorsPresent;

        vm.submit = function () {
            $uibModalInstance.close({
                firstAidersAvailable: vm.firstAiders,
                cyclistsRequested: vm.cyclists,
                firstAidUnitsAvailable: vm.firstAidUnits,
                ambulancesAvailable: vm.ambulances,
                paramedicsAvailable: vm.paramedicsAvailable,
                doctorsPresent: vm.doctorsAvailable
            });
        }

        vm.cancel = function () {
            $uibModalInstance.dismiss('cancel');
        }

        activate();

        function activate() { }
    }
})();