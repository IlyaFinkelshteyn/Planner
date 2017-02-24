angular
    .module('app')
    .directive('editControl', EditControlDirective.Factory());
var EditControlDirective = (function () {
    function EditControlDirective() {
        this.scope = {
            model: '=',
            displayName: '@',
            name: '@',
            required: '=?',
            mode: '@',
            autocomplete: '=?',
            autocompleteName: '@?',
        };
        this.restrict = 'E';
        this.templateUrl = '/html/modals/edit-control.html';
        this.require = "^form";
    }
    EditControlDirective.prototype.link = function (scope, element, attrs, form) {
        scope.form = form;
    };
    EditControlDirective.Factory = function () {
        var directive = function () {
            return new EditControlDirective();
        };
        directive['$inject'] = [];
        return directive;
    };
    return EditControlDirective;
}());
