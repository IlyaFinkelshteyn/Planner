angular
    .module('app')
    .directive('editCheck', EditCheckDirective.Factory());

class EditCheckDirective {
    scope = {
        model: '=',
        displayName: '@',
        checkName: '@',
        name: '@'
    };
    link(scope: angular.IScope, element: angular.IAugmentedJQuery,
        attrs: angular.IAttributes) { }
    restrict = 'E';
    templateUrl = '/html/modals/edit-check-control.html';

    public static Factory() {
        var directive = () => {
            return new EditCheckDirective();
        };

        directive['$inject'] = [];

        return directive;
    }
}