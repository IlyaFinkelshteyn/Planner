angular
    .module('app')
    .controller('EventDetailController', EventDetailController);
EventDetailController.$inject = ['$location', '$routeParams', '$uibModal', 'EventService', 'FlagService',
    'ScheduleItemService', 'DeploymentService', 'PatchItemService'];
var Qualification;
(function (Qualification) {
    Qualification[Qualification["AFA"] = 1] = "AFA";
    Qualification[Qualification["ETA"] = 2] = "ETA";
    Qualification[Qualification["EMT"] = 3] = "EMT";
    Qualification[Qualification["Paramedic"] = 4] = "Paramedic";
    Qualification[Qualification["Technician"] = 5] = "Technician";
    Qualification[Qualification["Doctor"] = 6] = "Doctor";
    Qualification[Qualification["Nurse"] = 7] = "Nurse";
})(Qualification || (Qualification = {}));
var CyclingLevel;
(function (CyclingLevel) {
    CyclingLevel[CyclingLevel["EntryLevel"] = 1] = "EntryLevel";
    CyclingLevel[CyclingLevel["Advanced"] = 2] = "Advanced";
})(CyclingLevel || (CyclingLevel = {}));
var EventDetailController = (function () {
    function EventDetailController($location, $routeParams, $uibModal, EventService, FlagService, ScheduleItemService, DeploymentService, PatchItemService) {
        this.id = this.$routeParams.id;
        this.loading = true;
        this.showScheduleEdit = false;
        this.showDeploymentEdit = false;
        this.renameEvent = this.PatchItemService.createController({
            template: '/html/modals/rename-modal.html',
            controller: 'RenameEventController',
            service: this.EventService,
            itemId: this.id,
            model: function (el) { return this.data[el]; },
            callback: this.activate,
            modelItems: ['name', 'dipsNumber']
        });
        this.$location = $location;
        this.$routeParams = $routeParams;
        this.$uibModal = $uibModal;
        this.EventService = EventService;
        this.FlagService = FlagService;
        this.ScheduleItemService = ScheduleItemService;
        this.DeploymentService = DeploymentService;
        this.PatchItemService = PatchItemService;
        this.changeConsiderations = this.PatchItemService.createController({
            template: '/html/modals/change-considerations-modal.html',
            controller: 'ChangeConsiderationsController',
            service: this.EventService,
            itemId: this.id,
            model: function (el) { return this.data[el]; },
            callback: this.activate,
            modelItems: ['soloRespondingExpected', 'highSpeedRoadsAtEvent', 'expectingBadWeather',
                'hasSeriousHistory', 'widerDistribution']
        });
        this.changeCommunications = this.PatchItemService.createController({
            template: '/html/modals/change-communications-modal.html',
            controller: 'ChangeCommunicationsController',
            service: this.EventService,
            itemId: this.id,
            model: function (el) { return this.data[el]; },
            callback: this.activate,
            modelItems: ['usingSJARadio', 'usingAirwave', 'radioChannel',
                'fallbackRadioChannel', 'controlPhoneNumber', 'cruTrackingInUse']
        });
        this.changeCover = this.PatchItemService.createController({
            template: '/html/modals/change-cover-modal.html',
            controller: 'ChangeCoverController',
            service: this.EventService,
            itemId: this.id,
            model: function (el) { return this.data[el]; },
            callback: this.activate,
            modelItems: ['firstAidersAvailable', 'cyclistsRequested', 'firstAidUnitsAvailable',
                'ambulancesAvailable', 'paramedicsAvailable', 'doctorsPresent']
        });
        this.changeDate = this.PatchItemService.createController({
            template: '/html/modals/change-date-modal.html',
            controller: 'ChangeDateController',
            service: this.EventService,
            itemId: this.id,
            model: function (el) { return this.data[el]; },
            callback: this.activate,
            modelItems: ['date', 'startTime', 'endTime', 'dateConfirmed']
        });
        this.changeDeployment = this.PatchItemService.createController({
            template: '/html/modals/change-deployment-modal.html',
            controller: 'ChangeDeploymentController',
            service: this.DeploymentService,
            callback: this.activate,
            modelItems: ['team', 'callsign', 'name', 'qualification', 'cyclingLevel'],
            resolve: {
                cyclistData: function () { return this.DeploymentService.getCyclistSummaries(); },
            }
        });
        this.changeDescription = this.PatchItemService.createController({
            template: '/html/modals/change-description-modal.html',
            controller: 'ChangeDescriptionController',
            service: this.EventService,
            itemId: this.id,
            model: function (el) { return this.data[el]; },
            callback: this.activate,
            modelItems: ['description']
        });
        this.changeLocation = this.PatchItemService.createController({
            template: '/html/modals/change-location-modal.html',
            controller: 'ChangeLocationController',
            service: this.EventService,
            itemId: this.id,
            model: function (el) { return this.data[el]; },
            callback: this.activate,
            modelItems: ['location', 'postCode']
        });
        this.changeScheduleItem = this.PatchItemService.createController({
            template: '/html/modals/change-schedule-item-modal.html',
            controller: 'ChangeScheduleItemController',
            service: this.ScheduleItemService,
            callback: this.activate,
            modelItems: ['time', 'action']
        });
        this.activate();
    }
    EventDetailController.prototype.addDeployment = function (item) {
        var modalInstance = this.$uibModal.open({
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
                cyclistData: function () { return this.DeploymentService.getCyclistSummaries(); },
                clinicalQualification: function () { return ""; },
                cyclingLevel: function () { return ""; }
            }
        });
        modalInstance.result.then(function (result) {
            result.name = result.cyclist;
            result.qualification = result.clinicalQualification;
            this.DeploymentService.addItem(this.id, result).then(function () {
                this.activate();
            });
        });
    };
    EventDetailController.prototype.addScheduleItem = function () {
        var modalInstance = this.$uibModal.open({
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
            this.ScheduleItemService.addItem(this.id, result).then(function () {
                this.activate();
            });
        });
    };
    EventDetailController.prototype.deleteDeployment = function (id) {
        this.DeploymentService.deleteItem(id).then(function () {
            this.activate();
        });
    };
    EventDetailController.prototype.deleteScheduleItem = function (id) {
        this.ScheduleItemService.deleteItem(id).then(function () {
            this.activate();
        });
    };
    EventDetailController.prototype.setStatus = function (status) {
        var patchData = [{ 'op': 'replace', 'path': '/Status', 'value': status }];
        this.EventService.patchEvent(this.id, patchData).then(function () {
            this.activate();
        });
    };
    ;
    EventDetailController.prototype.statusToLabelClass = function (status) {
        return this.FlagService.statusToLabelClass(status);
    };
    ;
    EventDetailController.prototype.statusToText = function (status) {
        return this.FlagService.statusToText(status);
    };
    ;
    EventDetailController.prototype.toggleDeploymentEdit = function () {
        this.showDeploymentEdit = !this.showDeploymentEdit;
    };
    EventDetailController.prototype.toggleScheduleEdit = function () {
        this.showScheduleEdit = !this.showScheduleEdit;
    };
    EventDetailController.prototype.qualificationToText = function (qualification) {
        switch (qualification) {
            case Qualification.AFA:
                return "Advanced First Aider";
            case Qualification.ETA:
                return "Emergency Transport Attendant";
            case Qualification.EMT:
                return "Emergency Medical Technician";
            case Qualification.Paramedic:
                return "Paramedic";
            case Qualification.Technician:
                return "Technician";
            case Qualification.Doctor:
                return "Doctor";
            case Qualification.Nurse:
                return "Nurse";
            default:
                return "Other";
        }
    };
    ;
    EventDetailController.prototype.activate = function () {
        this.EventService.getEvent(this.id).then(function (response) {
            this.data = response.data;
            this.loading = false;
        });
    };
    return EventDetailController;
}());
