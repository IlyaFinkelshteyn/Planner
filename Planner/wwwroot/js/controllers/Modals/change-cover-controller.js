var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var ChangeCoverController = (function (_super) {
    __extends(ChangeCoverController, _super);
    function ChangeCoverController($uibModalInstance, firstAidersAvailable, cyclistsRequested, firstAidUnitsAvailable, ambulancesAvailable, paramedicsAvailable, doctorsPresent) {
        var _this = _super.call(this, $uibModalInstance) || this;
        _this.submit = function () {
            this.$uibModalInstance.close({
                firstAidersAvailable: this.firstAiders,
                cyclistsRequested: this.cyclists,
                firstAidUnitsAvailable: this.firstAidUnits,
                ambulancesAvailable: this.ambulances,
                paramedicsAvailable: this.paramedicsAvailable,
                doctorsPresent: this.doctorsAvailable
            });
        };
        _this.firstAiders = firstAidersAvailable;
        _this.cyclists = cyclistsRequested;
        _this.firstAidUnits = firstAidUnitsAvailable;
        _this.ambulances = ambulancesAvailable;
        _this.paramedicsAvailable = paramedicsAvailable;
        _this.doctorsAvailable = doctorsPresent;
        return _this;
    }
    return ChangeCoverController;
}(ModalController));
ChangeCoverController.$inject = ['$uibModalInstance', 'firstAidersAvailable', 'cyclistsRequested', 'firstAidUnitsAvailable', 'ambulancesAvailable', 'paramedicsAvailable', 'doctorsPresent'];
angular.module('app').controller('ChangeCoverController', ChangeCoverController);
//# sourceMappingURL=change-cover-controller.js.map