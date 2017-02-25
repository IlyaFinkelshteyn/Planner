var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var ChangeScheduleItemController = (function (_super) {
    __extends(ChangeScheduleItemController, _super);
    function ChangeScheduleItemController($uibModalInstance, mode, time, action) {
        var _this = _super.call(this, $uibModalInstance) || this;
        _this.mode = mode;
        _this.time = moment(time, 'HH:mm').toDate();
        _this.action = action;
        return _this;
    }
    ChangeScheduleItemController.prototype.title = function () {
        switch (this.mode) {
            case "update":
                return "Update Schedule Item";
            case "add":
                return "Add Schedule Item";
            default:
                return "";
        }
    };
    ;
    ChangeScheduleItemController.prototype.submit = function () {
        this.$uibModalInstance.close({
            time: moment(this.time).format('HH:mm'),
            action: this.action
        });
    };
    ;
    return ChangeScheduleItemController;
}(ModalController));
ChangeScheduleItemController.$inject = ['$uibModalInstance', 'mode', 'time', 'action'];
angular.module('app').controller('ChangeScheduleItemController', ChangeScheduleItemController);
//# sourceMappingURL=change-schedule-item-controller.js.map