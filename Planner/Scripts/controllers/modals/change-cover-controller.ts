class ChangeCoverController extends ModalController {
    constructor($uibModalInstance: angular.ui.bootstrap.IModalServiceInstance,
        firstAidersAvailable: number, cyclistsRequested: number,
        firstAidUnitsAvailable: number, ambulancesAvailable: number,
        paramedicsAvailable: boolean, doctorsPresent: boolean) {
        super($uibModalInstance);
        this.firstAiders = firstAidersAvailable;
        this.cyclists = cyclistsRequested;
        this.firstAidUnits = firstAidUnitsAvailable;
        this.ambulances = ambulancesAvailable;
        this.paramedicsAvailable = paramedicsAvailable;
        this.doctorsAvailable = doctorsPresent;
    }

    static $inject = ['$uibModalInstance', 'firstAidersAvailable', 'cyclistsRequested', 'firstAidUnitsAvailable', 'ambulancesAvailable', 'paramedicsAvailable', 'doctorsPresent'];
    firstAiders: number;
    cyclists: number;
    firstAidUnits: number;
    ambulances: number;
    paramedicsAvailable: boolean;
    doctorsAvailable: boolean;

    submit = function () {
        this.$uibModalInstance.close({
            firstAidersAvailable: this.firstAiders,
            cyclistsRequested: this.cyclists,
            firstAidUnitsAvailable: this.firstAidUnits,
            ambulancesAvailable: this.ambulances,
            paramedicsAvailable: this.paramedicsAvailable,
            doctorsPresent: this.doctorsAvailable
        });
    }
}

angular.module('app').controller('ChangeCoverController', ChangeCoverController);