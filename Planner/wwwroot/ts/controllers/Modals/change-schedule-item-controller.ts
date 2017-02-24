angular
    .module('app')
    .controller('ChangeScheduleItemController', ChangeScheduleItemController);

ChangeScheduleItemController.$inject = ['$uibModalInstance', 'mode', 'time', 'action'];

class ChangeScheduleItemController {
    constructor($uibModalInstance: angular.ui.bootstrap.IModalServiceInstance,
        mode: string, time: string, action: string) {
        this.$uibModalInstance = $uibModalInstance;
        this.mode = mode;
        this.time = moment(time, 'hh:mm').toDate();
        this.action = action;
    }
    $uibModalInstance: angular.ui.bootstrap.IModalServiceInstance;
    mode: string;
    time: Date;
    action: string;

    title() {
        switch (this.mode) {
            case "update":
                return "Update Schedule Item";
            case "add":
                return "Add Schedule Item";
            default:
                return "";
        }
    };

    submit() {
        this.$uibModalInstance.close({
            time: moment(this.time).format('hh:mm'),
            action: this.action
        });
    };

    cancel() {
        this.$uibModalInstance.dismiss('cancel');
    };
}