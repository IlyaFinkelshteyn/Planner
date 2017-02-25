var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var RenameEventController = (function (_super) {
    __extends(RenameEventController, _super);
    function RenameEventController($uibModalInstance, dipsNumber, name) {
        var _this = _super.call(this, $uibModalInstance) || this;
        _this.submit = function () {
            this.$uibModalInstance.close({
                dipsNumber: this.dipsNumber,
                name: this.name
            });
        };
        _this.dipsNumber = dipsNumber;
        _this.name = name;
        return _this;
    }
    return RenameEventController;
}(ModalController));
RenameEventController.$inject = ['$uibModalInstance', 'dipsNumber', 'name'];
angular.module('app').controller('RenameEventController', RenameEventController);
//# sourceMappingURL=rename-event-controller.js.map