angular
    .module('app')
    .controller('ChangeDateController', ChangeDateController);

ChangeDateController.$inject = ['$uibModalInstance', 'date', 'startTime', 'endTime', 'dateConfirmed'];

class ChangeDateController {
    constructor($uibModalInstance: angular.ui.bootstrap.IModalServiceInstance,
        date: string, startTime: string, endTime: string, dateConfirmed: boolean) {
        this.$uibModalInstance = $uibModalInstance;
        this.date = moment(date).toDate();
        this.startTime = moment(startTime, 'hh:mm').toDate();
        this.endTime = moment(endTime, 'hh:mm').toDate();
        this.dateConfirmed = dateConfirmed;
    }

    $uibModalInstance: angular.ui.bootstrap.IModalServiceInstance;
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

    cancel() {
        this.$uibModalInstance.dismiss('cancel');
    }
}