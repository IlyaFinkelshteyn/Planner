angular
    .module('app')
    .controller('ChangeCoverController', ChangeCoverController);

ChangeCoverController.$inject = ['$uibModalInstance', 'firstAidersAvailable', 'cyclistsRequested', 'firstAidUnitsAvailable',
    'ambulancesAvailable', 'paramedicsAvailable', 'doctorsPresent'];

class ChangeCoverController {
    constructor($uibModalInstance: angular.ui.bootstrap.IModalServiceInstance,
        firstAidersAvailable: number, cyclistsRequested: number,
        firstAidUnitsAvailable: number, ambulancesAvailable: number,
        paramedicsAvailable: boolean, doctorsPresent: boolean) {
        this.$uibModalInstance = $uibModalInstance;
        this.firstAiders = firstAidersAvailable;
        this.cyclists = cyclistsRequested;
        this.firstAidUnits = firstAidUnitsAvailable;
        this.ambulances = ambulancesAvailable;
        this.paramedicsAvailable = paramedicsAvailable;
        this.doctorsAvailable = doctorsPresent;
    }

    $uibModalInstance: angular.ui.bootstrap.IModalServiceInstance;
    firstAiders: number;
    cyclists: number;
    firstAidUnits: number;
    ambulances: number;
    paramedicsAvailable: boolean;
    doctorsAvailable: boolean;

    submit = function() {
        this.$uibModalInstance.close({
            firstAidersAvailable: this.firstAiders,
            cyclistsRequested: this.cyclists,
            firstAidUnitsAvailable: this.firstAidUnits,
            ambulancesAvailable: this.ambulances,
            paramedicsAvailable: this.paramedicsAvailable,
            doctorsPresent: this.doctorsAvailable
        });
    }

    cancel = function() {
        this.$uibModalInstance.dismiss('cancel');
    }
}