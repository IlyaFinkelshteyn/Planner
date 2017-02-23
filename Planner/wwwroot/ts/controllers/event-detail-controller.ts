(function () {
    'use strict';

    angular
        .module('app')
        .controller('EventDetailController', EventDetailController);

    EventDetailController.$inject = ['$location', '$routeParams', '$uibModal', 'EventService', 'FlagService',
        'ScheduleItemService', 'DeploymentService', 'PatchItemService'];

    function EventDetailController($location, $routeParams, $uibModal, EventService, FlagService,
        ScheduleItemService, DeploymentService, PatchItemService) {
        /* jshint validthis:true */
        var vm = this;

        vm.id = $routeParams.id
        vm.loading = true;
        vm.showScheduleEdit = false;
        vm.showDeploymentEdit = false;

        vm.addDeployment = function (item) {
            var modalInstance = $uibModal.open({
                animation: true,
                ariaLabelledBy: 'modal-title',
                ariaDescribedBy: 'modal-body',
                templateUrl: '/html/modals/change-deployment-modal.html',
                controller: 'ChangeDeploymentController',
                controllerAs: 'vm',
                resolve: {
                    mode: function () { return "add"; },
                    team: function () { return 1; },
                    callsign: function () { return ""; },
                    cyclist: function () { return ""; },
                    cyclistData: function () { return DeploymentService.getCyclistSummaries(); },
                    clinicalQualification: function () { return ""; },
                    cyclingLevel: function () { return ""; }
                }
            });

            modalInstance.result.then(function (result) {
                result.name = result.cyclist;
                result.qualification = result.clinicalQualification;

                DeploymentService.addItem(vm.id, result).then(function () {
                    activate();
                });
            });
        }

        vm.addScheduleItem = function () {
            var modalInstance = $uibModal.open({
                animation: true,
                ariaLabelledBy: 'modal-title',
                ariaDescribedBy: 'modal-body',
                templateUrl: '/html/modals/change-schedule-item-modal.html',
                controller: 'ChangeScheduleItemController',
                controllerAs: 'vm',
                resolve: {
                    mode: function () { return "add"; },
                    time: function () { return ""; },
                    action: function () { return ""; }
                }
            });

            modalInstance.result.then(function (result) {
                ScheduleItemService.addItem(vm.id, result).then(function () {
                    activate();
                });
            });
        }

        vm.changeConsiderations = PatchItemService.createController({
            template: '/html/modals/change-considerations-modal.html',
            controller: 'ChangeConsiderationsController',
            service: EventService,
            itemId: vm.id,
            model: function (el) { return vm.data[el]; },
            callback: activate,
            modelItems: ['soloRespondingExpected', 'highSpeedRoadsAtEvent', 'expectingBadWeather',
                'hasSeriousHistory', 'widerDistribution']
        });

        vm.changeCommunications = PatchItemService.createController({
            template: '/html/modals/change-communications-modal.html',
            controller: 'ChangeCommunicationsController',
            service: EventService,
            itemId: vm.id,
            model: function (el) { return vm.data[el]; },
            callback: activate,
            modelItems: ['usingSJARadio', 'usingAirwave', 'radioChannel',
                'fallbackRadioChannel', 'controlPhoneNumber', 'cruTrackingInUse']
        });

        vm.changeCover = PatchItemService.createController({
            template: '/html/modals/change-cover-modal.html',
            controller: 'ChangeCoverController',
            service: EventService,
            itemId: vm.id,
            model: function (el) { return vm.data[el]; },
            callback: activate,
            modelItems: ['firstAidersAvailable', 'cyclistsRequested', 'firstAidUnitsAvailable',
                'ambulancesAvailable', 'paramedicsAvailable', 'doctorsPresent']
        });

        vm.changeDate = PatchItemService.createController({
            template: '/html/modals/change-date-modal.html',
            controller: 'ChangeDateController',
            service: EventService,
            itemId: vm.id,
            model: function (el) { return vm.data[el]; },
            callback: activate,
            modelItems: ['date', 'startTime', 'endTime', 'dateConfirmed']
        });

        vm.changeDeployment = PatchItemService.createController({
            template: '/html/modals/change-deployment-modal.html',
            controller: 'ChangeDeploymentController',
            service: DeploymentService,
            callback: activate,
            modelItems: ['team', 'callsign', 'name', 'qualification', 'cyclingLevel'],
            resolve: {
                cyclistData: function () { return DeploymentService.getCyclistSummaries(); },
            }
        });

        vm.changeDescription = PatchItemService.createController({
            template: '/html/modals/change-description-modal.html',
            controller: 'ChangeDescriptionController',
            service: EventService,
            itemId: vm.id,
            model: function (el) { return vm.data[el]; },
            callback: activate,
            modelItems: ['description']
        });

        vm.changeLocation = PatchItemService.createController({
            template: '/html/modals/change-location-modal.html',
            controller: 'ChangeLocationController',
            service: EventService,
            itemId: vm.id,
            model: function (el) { return vm.data[el]; },
            callback: activate,
            modelItems: ['location', 'postCode']
        });

        vm.changeScheduleItem = PatchItemService.createController({
            template: '/html/modals/change-schedule-item-modal.html',
            controller: 'ChangeScheduleItemController',
            service: ScheduleItemService,
            callback: activate,
            modelItems: ['time', 'action']
        });

        vm.deleteDeployment = function (id) {
            DeploymentService.deleteItem(id).then(function () {
                activate();
            });
        }

        vm.deleteScheduleItem = function (id) {
            ScheduleItemService.deleteItem(id).then(function () {
                activate();
            });
        }

        vm.setStatus = function (status) {
            var patchData = [{ 'op': 'replace', 'path': '/Status', 'value': status }];

            EventService.patchEvent(vm.id, patchData).then(function () {
                activate();
            });
        };

        vm.statusToLabelClass = function (status) {
            return FlagService.statusToLabelClass(status);
        };

        vm.statusToText = function (status) {
            return FlagService.statusToText(status);
        };

        vm.toggleDeploymentEdit = function () {
            vm.showDeploymentEdit = !vm.showDeploymentEdit;
        }

        vm.toggleScheduleEdit = function () {
            vm.showScheduleEdit = !vm.showScheduleEdit;
        }

        vm.renameEvent = PatchItemService.createController({
            template: '/html/modals/rename-modal.html',
            controller: 'RenameEventController',
            service: EventService,
            itemId: vm.id,
            model: function (el) { return vm.data[el]; },
            callback: activate,
            modelItems: ['name', 'dipsNumber']
        });

        vm.qualificationToText = function (qualification) {
            switch (qualification) {
                case 1:
                    return "Advanced First Aider";
                case 2:
                    return "Emergency Transport Attendant";
                case 3:
                    return "Emergency Medical Technician";
                case 4:
                    return "Paramedic";
                case 5:
                    return "Technician";
                case 6:
                    return "Doctor";
                case 7:
                    return "Nurse";
                default:
                    return "Other";
            }
        };

        activate();

        function activate() {
            EventService.getEvent(vm.id).then(function (response) {
                vm.data = response.data;
                vm.loading = false;
            });
        }
    }
})();