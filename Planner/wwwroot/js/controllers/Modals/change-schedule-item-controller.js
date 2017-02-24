angular
    .module('app')
    .controller('ChangeScheduleItemController', ChangeScheduleItemController);
ChangeScheduleItemController.$inject = ['$uibModalInstance', 'mode', 'time', 'action'];
var ChangeScheduleItemController = (function () {
    function ChangeScheduleItemController($uibModalInstance, mode, time, action) {
        this.$uibModalInstance = $uibModalInstance;
        this.mode = mode;
        this.time = moment(time, 'hh:mm').toDate();
        this.action = action;
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
            time: moment(this.time).format('hh:mm'),
            action: this.action
        });
    };
    ;
    ChangeScheduleItemController.prototype.cancel = function () {
        this.$uibModalInstance.dismiss('cancel');
    };
    ;
    return ChangeScheduleItemController;
}());
