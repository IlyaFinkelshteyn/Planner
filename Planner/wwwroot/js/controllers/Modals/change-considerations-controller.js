(function () {
    'use strict';

    angular
        .module('app')
        .controller('ChangeConsiderationsController', ChangeConsiderationsController);

    ChangeConsiderationsController.$inject = ['$uibModalInstance', 'soloRespondingExpected', 'highSpeedRoadsAtEvent', 'expectingBadWeather', 'hasSeriousHistory', 'widerDistribution'];

    function ChangeConsiderationsController($uibModalInstance, soloRespondingExpected, highSpeedRoadsAtEvent, expectingBadWeather, hasSeriousHistory, widerDistribution) {
        /* jshint validthis:true */
        var vm = this;

        vm.soloRespondingExpected = soloRespondingExpected;
        vm.highSpeedRoadsAtEvent = highSpeedRoadsAtEvent;
        vm.expectingBadWeather = expectingBadWeather;
        vm.hasSeriousHistory = hasSeriousHistory;
        vm.widerDistribution = widerDistribution;

        vm.submit = function () {
            $uibModalInstance.close({
                soloRespondingExpected: vm.soloRespondingExpected,
                highSpeedRoadsAtEvent: vm.highSpeedRoadsAtEvent,
                expectingBadWeather: vm.expectingBadWeather,
                hasSeriousHistory: vm.hasSeriousHistory,
                widerDistribution: vm.widerDistribution
            });
        }

        vm.cancel = function () {
            $uibModalInstance.dismiss('cancel');
        }

        activate();

        function activate() { }
    }
})();