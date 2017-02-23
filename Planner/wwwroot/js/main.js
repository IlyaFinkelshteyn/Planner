requirejs.config({
    //By default load any module IDs from js/lib
    baseUrl: 'lib',
    //except, if the module ID starts with "app",
    //load it from the js/app directory. paths
    //config is relative to the baseUrl, and
    //never includes a ".js" extension since
    //the paths config could be for a directory.
    paths: {
        'angular': '/lib/angular/angular'
    }
});
// Start the main app logic.
require(['angular', 'app'], function (angular) {
    var elem = document.getElementsByName("html")[0];
    angular.bootstrap(elem, ['appModule']);
});
