var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var ChangeLocationController = (function (_super) {
    __extends(ChangeLocationController, _super);
    function ChangeLocationController($uibModalInstance, location, postCode) {
        var _this = _super.call(this, $uibModalInstance) || this;
        _this.location = location;
        _this.postCode = postCode;
        return _this;
    }
    ChangeLocationController.prototype.submit = function () {
        this.$uibModalInstance.close({
            location: this.location,
            postCode: this.postCode
        });
    };
    return ChangeLocationController;
}(ModalController));
ChangeLocationController.$inject = ['$uibModalInstance', 'location', 'postCode'];
angular.module('app').controller('ChangeLocationController', ChangeLocationController);
//# sourceMappingURL=change-location-controller.js.map