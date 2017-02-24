angular
    .module('app')
    .controller('ChangeDeploymentController', ChangeDeploymentController);
ChangeDeploymentController.$inject = ['$uibModalInstance', 'mode', 'team', 'callsign', 'name', 'cyclistData', 'qualification', 'cyclingLevel'];
var ChangeDeploymentController = (function () {
    function ChangeDeploymentController($uibModalInstance, mode, team, callsign, name, cyclistData, qualification, cyclingLevel) {
        this.$uibModalInstance = $uibModalInstance;
        this.mode = mode;
        this.team = team;
        this.callsign = callsign;
        this.cyclist = name;
        this.cyclistData = cyclistData;
        this.clinicalQualification = (qualification || "").toString();
        this.cyclingLevel = (cyclingLevel || "").toString();
    }
    ChangeDeploymentController.prototype.submit = function () {
        this.$uibModalInstance.close({
            team: this.team,
            callsign: this.callsign,
            name: this.cyclist,
            qualification: parseInt(this.clinicalQualification),
            cyclingLevel: parseInt(this.cyclingLevel)
        });
    };
    ChangeDeploymentController.prototype.title = function () {
        switch (this.mode) {
            case "update":
                return "Update Deployment";
            case "add":
                return "Add Deployment";
            default:
                return "";
        }
    };
    ;
    ChangeDeploymentController.prototype.cancel = function () {
        this.$uibModalInstance.dismiss('cancel');
    };
    return ChangeDeploymentController;
}());
