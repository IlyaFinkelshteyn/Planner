var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var ChangeDescriptionController = (function (_super) {
    __extends(ChangeDescriptionController, _super);
    function ChangeDescriptionController($uibModalInstance, description) {
        var _this = _super.call(this, $uibModalInstance) || this;
        _this.description = description;
        return _this;
    }
    ChangeDescriptionController.prototype.submit = function () {
        this.$uibModalInstance.close({
            description: this.description
        });
    };
    return ChangeDescriptionController;
}(ModalController));
ChangeDescriptionController.$inject = ['$uibModalInstance', 'description'];
angular.module('app').controller('ChangeDescriptionController', ChangeDescriptionController);
//# sourceMappingURL=change-description-controller.js.map