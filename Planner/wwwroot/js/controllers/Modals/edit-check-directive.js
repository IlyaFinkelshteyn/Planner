angular
    .module('app')
    .directive('editCheck', EditCheckDirective.Factory());
var EditCheckDirective = (function () {
    function EditCheckDirective() {
        this.scope = {
            model: '=',
            displayName: '@',
            checkName: '@',
            name: '@'
        };
        this.restrict = 'E';
        this.templateUrl = '/html/modals/edit-check-control.html';
    }
    EditCheckDirective.prototype.link = function (scope, element, attrs) { };
    EditCheckDirective.Factory = function () {
        var directive = function () {
            return new EditCheckDirective();
        };
        directive['$inject'] = [];
        return directive;
    };
    return EditCheckDirective;
}());
