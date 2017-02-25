var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var AddItemController = (function (_super) {
    __extends(AddItemController, _super);
    function AddItemController($uibModalInstance, itemName) {
        var _this = _super.call(this, $uibModalInstance) || this;
        _this.name = '';
        _this.submit = function () {
            this.$uibModalInstance.close({
                name: this.name
            });
        };
        _this.itemName = itemName;
        return _this;
    }
    return AddItemController;
}(ModalController));
AddItemController.$inject = ['$uibModalInstance', 'itemName'];
angular.module('app').controller('AddItemController', AddItemController);
//# sourceMappingURL=add-item-controller.js.map