angular
    .module('app')
    .controller('ChangeDateController', ChangeDateController);
ChangeDateController.$inject = ['$uibModalInstance', 'date', 'startTime', 'endTime', 'dateConfirmed'];
var ChangeDateController = (function () {
    function ChangeDateController($uibModalInstance, date, startTime, endTime, dateConfirmed) {
        this.$uibModalInstance = $uibModalInstance;
        this.date = moment(date).toDate();
        this.startTime = moment(startTime, 'hh:mm').toDate();
        this.endTime = moment(endTime, 'hh:mm').toDate();
        this.dateConfirmed = dateConfirmed;
    }
    ChangeDateController.prototype.submit = function () {
        this.$uibModalInstance.close({
            date: moment(this.date).format(),
            startTime: moment(this.startTime).format('hh:mm'),
            endTime: moment(this.endTime).format('hh:mm'),
            dateConfirmed: this.dateConfirmed
        });
    };
    ChangeDateController.prototype.cancel = function () {
        this.$uibModalInstance.dismiss('cancel');
    };
    return ChangeDateController;
}());
