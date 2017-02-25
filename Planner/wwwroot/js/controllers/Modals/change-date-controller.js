var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var ChangeDateController = (function (_super) {
    __extends(ChangeDateController, _super);
    function ChangeDateController($uibModalInstance, date, startTime, endTime, dateConfirmed) {
        var _this = _super.call(this, $uibModalInstance) || this;
        _this.date = moment(date).toDate();
        _this.startTime = moment(startTime, 'hh:mm').toDate();
        _this.endTime = moment(endTime, 'hh:mm').toDate();
        _this.dateConfirmed = dateConfirmed;
        return _this;
    }
    ChangeDateController.prototype.submit = function () {
        this.$uibModalInstance.close({
            date: moment(this.date).format(),
            startTime: moment(this.startTime).format('hh:mm'),
            endTime: moment(this.endTime).format('hh:mm'),
            dateConfirmed: this.dateConfirmed
        });
    };
    return ChangeDateController;
}(ModalController));
ChangeDateController.$inject = ['$uibModalInstance', 'date', 'startTime', 'endTime', 'dateConfirmed'];
angular.module('app').controller('ChangeDateController', ChangeDateController);
//# sourceMappingURL=change-date-controller.js.map