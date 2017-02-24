angular
    .module('app')
    .controller('ChangeCoverController', ChangeCoverController);
ChangeCoverController.$inject = ['$uibModalInstance', 'firstAidersAvailable', 'cyclistsRequested', 'firstAidUnitsAvailable',
    'ambulancesAvailable', 'paramedicsAvailable', 'doctorsPresent'];
var ChangeCoverController = (function () {
    function ChangeCoverController($uibModalInstance, firstAidersAvailable, cyclistsRequested, firstAidUnitsAvailable, ambulancesAvailable, paramedicsAvailable, doctorsPresent) {
        this.submit = function () {
            this.$uibModalInstance.close({
                firstAidersAvailable: this.firstAiders,
                cyclistsRequested: this.cyclists,
                firstAidUnitsAvailable: this.firstAidUnits,
                ambulancesAvailable: this.ambulances,
                paramedicsAvailable: this.paramedicsAvailable,
                doctorsPresent: this.doctorsAvailable
            });
        };
        this.cancel = function () {
            this.$uibModalInstance.dismiss('cancel');
        };
        this.$uibModalInstance = $uibModalInstance;
        this.firstAiders = firstAidersAvailable;
        this.cyclists = cyclistsRequested;
        this.firstAidUnits = firstAidUnitsAvailable;
        this.ambulances = ambulancesAvailable;
        this.paramedicsAvailable = paramedicsAvailable;
        this.doctorsAvailable = doctorsPresent;
    }
    return ChangeCoverController;
}());
