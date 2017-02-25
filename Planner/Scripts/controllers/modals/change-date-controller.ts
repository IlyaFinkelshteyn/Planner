class ChangeDateController extends ModalController {
    constructor($uibModalInstance: angular.ui.bootstrap.IModalServiceInstance,
        date: string, startTime: string, endTime: string, dateConfirmed: boolean) {
        super($uibModalInstance);
        this.date = moment(date).toDate();
        this.startTime = moment(startTime, 'hh:mm').toDate();
        this.endTime = moment(endTime, 'hh:mm').toDate();
        this.dateConfirmed = dateConfirmed;
    }

    static $inject = ['$uibModalInstance', 'date', 'startTime', 'endTime', 'dateConfirmed'];
    date: Date;
    startTime: Date;
    endTime: Date;
    dateConfirmed: boolean;

    submit() {
        this.$uibModalInstance.close({
            date: moment(this.date).format(),
            startTime: moment(this.startTime).format('hh:mm'),
            endTime: moment(this.endTime).format('hh:mm'),
            dateConfirmed: this.dateConfirmed
        });
    }
}

angular.module('app').controller('ChangeDateController', ChangeDateController);