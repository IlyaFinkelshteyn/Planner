angular
    .module('app')
    .controller('ChangeDeploymentController', ChangeDeploymentController);

ChangeDeploymentController.$inject = ['$uibModalInstance', 'mode', 'team', 'callsign', 'name', 'cyclistData', 'qualification', 'cyclingLevel'];

class ChangeDeploymentController {
    constructor($uibModalInstance: angular.ui.bootstrap.IModalServiceInstance,
        mode: string, team: number, callsign: string, name: string, cyclistData: any,
        qualification: Qualification, cyclingLevel: CyclingLevel) {
        this.$uibModalInstance = $uibModalInstance;
        this.mode = mode;
        this.team = team;
        this.callsign = callsign;
        this.cyclist = name;
        this.cyclistData = cyclistData;
        this.clinicalQualification = (qualification || "").toString();
        this.cyclingLevel = (cyclingLevel || "").toString();
    }

    private $uibModalInstance: angular.ui.bootstrap.IModalServiceInstance;
    mode: string;
    team: number;
    callsign: string;
    cyclist: string;
    cyclistData: any;
    clinicalQualification: string;
    cyclingLevel: string;

    submit() {
        this.$uibModalInstance.close({
            team: this.team,
            callsign: this.callsign,
            name: this.cyclist,
            qualification: parseInt(this.clinicalQualification),
            cyclingLevel: parseInt(this.cyclingLevel)
        });
    }

    title() {
        switch (this.mode) {
            case "update":
                return "Update Deployment";
            case "add":
                return "Add Deployment";
            default:
                return "";
        }
    };

    cancel() {
        this.$uibModalInstance.dismiss('cancel');
    }
}