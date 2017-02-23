(function () {
    'use strict';

    angular
        .module('app')
        .controller('ChangeDeploymentController', ChangeDeploymentController);

    ChangeDeploymentController.$inject = ['$uibModalInstance', 'mode', 'team', 'callsign', 'name', 'cyclistData', 'qualification', 'cyclingLevel'];

    function ChangeDeploymentController($uibModalInstance, mode, team, callsign, name, cyclistData, qualification, cyclingLevel) {
        /* jshint validthis:true */
        var vm = this;

        vm.mode = mode;
        vm.team = team;
        vm.callsign = callsign;
        vm.cyclist = name;
        vm.cyclistData = cyclistData;
        vm.clinicalQualification = (qualification || "").toString();
        vm.cyclingLevel = (cyclingLevel || "").toString();

        vm.submit = function () {
            $uibModalInstance.close({
                team: vm.team,
                callsign: vm.callsign,
                name: vm.cyclist,
                qualification: parseInt(vm.clinicalQualification),
                cyclingLevel: parseInt(vm.cyclingLevel)
            });
        }

        vm.title = function () {
            switch (mode) {
                case "update":
                    return "Update Deployment";
                case "add":
                    return "Add Deployment";
                default:
                    return "";
            }
        };

        vm.autoSelectComplete = function (event) {
            alert('hi');
        };

        vm.cancel = function () {
            $uibModalInstance.dismiss('cancel');
        }

        activate();

        function activate() { }
    }
})();