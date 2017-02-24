angular
    .module('app')
    .directive('editControl', EditControlDirective.Factory());

interface IEditControlScope extends angular.IScope {
    form: any;
}

class EditControlDirective {
    scope = {
        model: '=',
        displayName: '@',
        name: '@',
        required: '=?',
        mode: '@',
        autocomplete: '=?',
        autocompleteName: '@?',
    };

    link(scope: IEditControlScope, element: angular.IAugmentedJQuery,
        attrs: angular.IAttributes, form: any) {
        scope.form = form;
    }
    restrict = 'E';
    templateUrl = '/html/modals/edit-control.html';
    require = "^form";

    public static Factory() {
        var directive = () => {
            return new EditControlDirective();
        };

        directive['$inject'] = [];

        return directive;
    }
}