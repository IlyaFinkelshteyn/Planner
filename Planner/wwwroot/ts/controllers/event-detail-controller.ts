interface EventDetailRouteParams extends angular.route.IRouteParamsService {
    id: number;
}

enum Qualification {
    AFA = 1,
    ETA = 2,
    EMT = 3,
    Paramedic = 4,
    Technician = 5,
    Doctor = 6,
    Nurse = 7
}

enum CyclingLevel {
    EntryLevel = 1,
    Advanced = 2
}

class EventDetailController {
    static $inject = ['$location', '$routeParams', '$uibModal', 'EventService', 'FlagService', 'ScheduleItemService', 'DeploymentService', 'PatchItemService'];

    constructor($location: angular.ILocationService, $routeParams: EventDetailRouteParams,
        $uibModal: angular.ui.bootstrap.IModalService, EventService: EventService,
        FlagService: FlagService, ScheduleItemService: ScheduleItemService,
        DeploymentService: DeploymentService, PatchItemService: PatchItemService) {
        this.$location = $location;
        this.$routeParams = $routeParams;
        this.id = $routeParams.id;

        this.$uibModal = $uibModal;
        this.EventService = EventService;
        this.FlagService = FlagService;
        this.ScheduleItemService = ScheduleItemService;
        this.DeploymentService = DeploymentService;
        this.PatchItemService = PatchItemService;

        let vm = this;

        this.changeConsiderations = this.PatchItemService.createController({
            template: '/html/modals/change-considerations-modal.html',
            controller: 'ChangeConsiderationsController',
            service: this.EventService,
            itemId: this.id,
            model: function (el) { return vm.data[el]; },
            callback: function () { vm.activate() },
            modelItems: ['soloRespondingExpected', 'highSpeedRoadsAtEvent', 'expectingBadWeather',
                'hasSeriousHistory', 'widerDistribution']
        });

        this.changeCommunications = this.PatchItemService.createController({
            template: '/html/modals/change-communications-modal.html',
            controller: 'ChangeCommunicationsController',
            service: this.EventService,
            itemId: this.id,
            model: function (el) { return vm.data[el]; },
            callback: function () { vm.activate() },
            modelItems: ['usingSJARadio', 'usingAirwave', 'radioChannel',
                'fallbackRadioChannel', 'controlPhoneNumber', 'cruTrackingInUse']
        });

        this.changeCover = this.PatchItemService.createController({
            template: '/html/modals/change-cover-modal.html',
            controller: 'ChangeCoverController',
            service: this.EventService,
            itemId: this.id,
            model: function (el) { return vm.data[el]; },
            callback: function () { vm.activate() },
            modelItems: ['firstAidersAvailable', 'cyclistsRequested', 'firstAidUnitsAvailable',
                'ambulancesAvailable', 'paramedicsAvailable', 'doctorsPresent']
        });

        this.changeDate = this.PatchItemService.createController({
            template: '/html/modals/change-date-modal.html',
            controller: 'ChangeDateController',
            service: this.EventService,
            itemId: this.id,
            model: function (el) { return vm.data[el]; },
            callback: function () { vm.activate() },
            modelItems: ['date', 'startTime', 'endTime', 'dateConfirmed']
        });

        this.changeDeployment = this.PatchItemService.createController({
            template: '/html/modals/change-deployment-modal.html',
            controller: 'ChangeDeploymentController',
            service: this.DeploymentService,
            callback: function () { vm.activate() },
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
            model: function (el) { return vm.data[el]; },
            callback: function () { vm.activate() },
            modelItems: ['description']
        });

        this.changeLocation = this.PatchItemService.createController({
            template: '/html/modals/change-location-modal.html',
            controller: 'ChangeLocationController',
            service: this.EventService,
            itemId: this.id,
            model: function (el) { return vm.data[el]; },
            callback: function () { vm.activate() },
            modelItems: ['location', 'postCode']
        });

        this.changeScheduleItem = this.PatchItemService.createController({
            template: '/html/modals/change-schedule-item-modal.html',
            controller: 'ChangeScheduleItemController',
            service: this.ScheduleItemService,
            callback: function () { vm.activate() },
            modelItems: ['time', 'action']
        });

        this.renameEvent = this.PatchItemService.createController({
            template: '/html/modals/rename-modal.html',
            controller: 'RenameEventController',
            service: this.EventService,
            itemId: this.id,
            model: function (el) { return vm.data[el]; },
            callback: function () { vm.activate() },
            modelItems: ['name', 'dipsNumber']
        });

        this.activate();
    }

    $location: angular.ILocationService;
    $routeParams: EventDetailRouteParams;
    $uibModal: angular.ui.bootstrap.IModalService;
    EventService: EventService;
    FlagService: FlagService;
    ScheduleItemService: ScheduleItemService;
    DeploymentService: DeploymentService;
    PatchItemService: PatchItemService;
    id: number;
    data: IEventDetail;

    loading: boolean = true;
    showScheduleEdit: boolean = false;
    showDeploymentEdit: boolean = false;

    addDeployment(item: any) {
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

            let vm = this;

            this.DeploymentService.addItem(this.id, result).then(function () {
                vm.activate();
            });
        });
    }

    addScheduleItem() {
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
            let vm = this;
            this.ScheduleItemService.addItem(this.id, result).then(function () {
                vm.activate();
            });
        });
    }

    changeConsiderations: ((item: any) => void);

    changeCommunications: ((item: any) => void);

    changeCover: ((item: any) => void);

    changeDate: ((item: any) => void);

    changeDeployment: ((item: any) => void);

    changeDescription: ((item: any) => void);

    changeLocation: ((item: any) => void);

    changeScheduleItem: ((item: any) => void);

    renameEvent: ((item: any) => void);

    deleteDeployment(id: number) {
        let vm = this;
        this.DeploymentService.deleteItem(id).then(function () {
            vm.activate();
        });
    }

    deleteScheduleItem(id: number) {
        let vm = this;
        this.ScheduleItemService.deleteItem(id).then(function () {
            vm.activate();
        });
    }

    setStatus(status: EventStatus) {
        var patchData = [{ 'op': 'replace', 'path': '/Status', 'value': status }];

        let vm = this;

        this.EventService.patchItem(this.id, patchData).then(function () {
            vm.activate();
        });
    };

    statusToLabelClass(status: EventStatus) {
        return this.FlagService.statusToLabelClass(status);
    };

    statusToText(status: EventStatus) {
        return this.FlagService.statusToText(status);
    };

    toggleDeploymentEdit() {
        this.showDeploymentEdit = !this.showDeploymentEdit;
    }

    toggleScheduleEdit() {
        this.showScheduleEdit = !this.showScheduleEdit;
    }

    qualificationToText(qualification: Qualification) {
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

    activate() {
        let vm = this;

        this.EventService.getEvent(this.id).then(function (response) {
            vm.data = response.data;
            vm.loading = false;
        });
    }
}

angular.module('app').controller('EventDetailController', EventDetailController);