var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var ChangeDeploymentController = (function (_super) {
    __extends(ChangeDeploymentController, _super);
    function ChangeDeploymentController($uibModalInstance, mode, team, callsign, name, cyclistData, qualification, cyclingLevel) {
        var _this = _super.call(this, $uibModalInstance) || this;
        _this.mode = mode;
        _this.team = team;
        _this.callsign = callsign;
        _this.cyclist = name;
        _this.cyclistData = cyclistData;
        _this.clinicalQualification = (qualification || "").toString();
        _this.cyclingLevel = (cyclingLevel || "").toString();
        return _this;
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
    return ChangeDeploymentController;
}(ModalController));
ChangeDeploymentController.$inject = ['$uibModalInstance', 'mode', 'team', 'callsign', 'name', 'cyclistData', 'qualification', 'cyclingLevel'];
angular.module('app').controller('ChangeDeploymentController', ChangeDeploymentController);
//# sourceMappingURL=change-deployment-controller.js.map