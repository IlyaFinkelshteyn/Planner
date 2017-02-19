(function () {
    'use strict';

    angular
        .module('app')
        .directive('editCheck', EditCheckDirective);

    EditCheckDirective.$inject = [];

    function EditCheckDirective() {
        var directive = {
            scope: {
                model: '=',
                displayName: '@',
                checkName: '@',
                name: '@'
            },
            link: link,
            restrict: 'E',
            templateUrl: '/static/event/modals/edit-check-control.html'
        };
        return directive;

        function link(scope, element, attrs) {
        }
    }
})();