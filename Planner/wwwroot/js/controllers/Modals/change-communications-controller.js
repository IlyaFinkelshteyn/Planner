(function () {
    'use strict';

    angular
        .module('app')
        .controller('ChangeCommunicationsController', ChangeCommunicationsController);

    ChangeCommunicationsController.$inject = ['$uibModalInstance', 'usingSJARadio', 'usingAirwave', 'radioChannel', 'fallbackRadioChannel', 'controlPhoneNumber', 'cruTrackingInUse'];

    function ChangeCommunicationsController($uibModalInstance, usingSJARadio, usingAirwave, radioChannel, fallbackRadioChannel, controlPhoneNumber, cruTrackingInUse) {
        /* jshint validthis:true */
        var vm = this;

        vm.usingSJARadio = usingSJARadio;
        vm.usingAirwave = usingAirwave;
        vm.radioChannel = radioChannel;
        vm.fallbackRadioChannel = fallbackRadioChannel;
        vm.controlPhoneNumber = controlPhoneNumber;
        vm.cruTrackingInUse = cruTrackingInUse;

        vm.submit = function () {
            $uibModalInstance.close({
                usingSJARadio: vm.usingSJARadio,
                usingAirwave: vm.usingAirwave,
                radioChannel: vm.radioChannel,
                fallbackRadioChannel: vm.fallbackRadioChannel,
                controlPhoneNumber: vm.controlPhoneNumber,
                cruTrackingInUse: vm.cruTrackingInUse
            });
        }

        vm.cancel = function () {
            $uibModalInstance.dismiss('cancel');
        }

        activate();

        function activate() { }
    }
})();