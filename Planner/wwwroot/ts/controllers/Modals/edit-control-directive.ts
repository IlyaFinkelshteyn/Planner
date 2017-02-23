(function () {
    'use strict';

    angular
        .module('app')
        .directive('editControl', EditControlDirective);

    EditControlDirective.$inject = [];

    function EditControlDirective() {
        var directive = {
            scope: {
                model: '=',
                displayName: '@',
                name: '@',
                required: '=?',
                mode: '@',
                autocomplete: '=?',
                autocompleteName: '@?'
            },
            link: link,
            restrict: 'E',
            templateUrl: '/html/modals/edit-control.html',
            require: "^form"
        };
        return directive;

        function link(scope, element, attrs, form) {
            scope.form = form;
        }
    }
})();