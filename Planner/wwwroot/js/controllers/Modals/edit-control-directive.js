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
        return directive;
    };
    return EditControlDirective;
}());
angular.module('app').directive('editControl', EditControlDirective.Factory());
//# sourceMappingURL=edit-control-directive.js.map