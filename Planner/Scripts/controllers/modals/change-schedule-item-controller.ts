class ChangeScheduleItemController extends ModalController {
    constructor($uibModalInstance: angular.ui.bootstrap.IModalServiceInstance,
        mode: string, time: string, action: string) {
        super($uibModalInstance);
        this.mode = mode;
        this.time = moment(time, 'HH:mm').toDate();
        this.action = action;
    }

    static $inject = ['$uibModalInstance', 'mode', 'time', 'action'];
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
            time: moment(this.time).format('HH:mm'),
            action: this.action
        });
    };
}

angular.module('app').controller('ChangeScheduleItemController', ChangeScheduleItemController);