(function () {
    'use strict';

    angular.module('app', [
        // Angular modules
        'ngRoute',
        // Custom modules

        // 3rd Party Modules
        'angularUtils.directives.dirPagination',
        'angularMoment',
        'ui.bootstrap',
        'ui.event'
    ]).config(['$locationProvider', function ($locationProvider) {
        $locationProvider.html5Mode(false);
        $locationProvider.hashPrefix('!');
    }])
    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/event/new', {
            templateUrl: 'static/event/create.html',
            controller: 'EventCreateController',
            controllerAs: 'vm'
        }).when('/event/:id', {
            templateUrl: 'html/detail.html',
            controller: 'EventDetailController',
            controllerAs: 'vm'
        }).when('/', {
            templateUrl: 'html/events.html',
            controller: 'HomeController',
            controllerAs: 'vm'
        }).otherwise('/');
    }]).run([
        '$rootScope',
        function ($rootScope) {
            // see what's going on when the route tries to change
            $rootScope.$on('$routeChangeStart', function (event, next, current) {
                // next is an object that is the route that we are starting to go to
                // current is an object that is the route where we are currently
                var currentPath = current.originalPath;
                var nextPath = next.originalPath;

                console.log('Starting to leave %s to go to %s', currentPath, nextPath);
            });
        }
    ]);
})();