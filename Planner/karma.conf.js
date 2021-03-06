// Karma configuration
// Generated on Sat Feb 25 2017 21:09:22 GMT+0000 (GMT Standard Time)

module.exports = function (config) {
    config.set({
        // base path that will be used to resolve all patterns (eg. files, exclude)
        basePath: '',

        // frameworks to use
        // available frameworks: https://npmjs.org/browse/keyword/karma-adapter
        frameworks: ['jasmine', 'karma-typescript'],

        browsers: ['Chrome'],

        // list of files / patterns to load in the browser
        files: [
            'wwwroot/lib/angular/angular.js',
            'node_modules/angular-mocks/angular-mocks.js',
            'wwwroot/lib/angular-route/angular-route.js',
            'wwwroot/lib/angular-utils-pagination/dirPagination.js',
            'wwwroot/lib/moment/moment.js',
            'wwwroot/lib/angular-moment/angular-moment.js',
            'wwwroot/lib/angular-ui-bootstrap/ui-bootstrap.js',
            'wwwroot/lib/angular-ui-event/event.js',
            'Scripts/app.ts',
            'Scripts/controllers/modals/modal-controller.ts',
            'Scripts/controllers/modals/add-item-controller.ts',
            'Scripts/controllers/modals/change-communications-controller.ts',
            'Scripts/controllers/modals/change-considerations-controller.ts',

            'Scripts/tests/**/*.ts'
        ],

        // list of files to exclude
        exclude: [
        ],

        // preprocess matching files before serving them to the browser
        // available preprocessors: https://npmjs.org/browse/keyword/karma-preprocessor
        preprocessors: {
            '**/*.ts': ['karma-typescript']
        },

        // test results reporter to use
        // possible values: 'dots', 'progress'
        // available reporters: https://npmjs.org/browse/keyword/karma-reporter
        reporters: ['progress', 'junit', 'html', 'karma-typescript'],

        junitReporter: {
            outputDir: '../reports/karma-results/junit', // results will be saved as $outputDir/$browserName.xml
            useBrowserName: true, // add browser name to report and classes names
        },

        htmlReporter: {
            outputDir: '../reports/karma-results/html', // where to put the reports
            focusOnFailures: true, // reports show failures on start
        },

        karmaTypescriptConfig: {
            compilerOptions: {
                target: "ES5",
                module: "amd",
                noImplicitAny: true,
                noImplicitReturns: true,
                noFallthroughCasesInSwitch: true,
                sourceMap: true,
                suppressImplicitAnyIndexErrors: true
            },
            reports: {
                'html': '../reports/karma-typescript-results',
                'json': {
                    'directory': '../reports/karma-typescript-results',
                    'filename': 'coverage.json'
                }
            }
        },

        // web server port
        port: 9876,

        // enable / disable colors in the output (reporters and logs)
        colors: true,

        // level of logging
        // possible values: config.LOG_DISABLE || config.LOG_ERROR || config.LOG_WARN || config.LOG_INFO || config.LOG_DEBUG
        logLevel: config.LOG_INFO,

        // enable / disable watching file and executing tests whenever any file changes
        autoWatch: true,

        // Continuous Integration mode
        // if true, Karma captures browsers, runs the tests and exits
        singleRun: false,

        // Concurrency level
        // how many browser should be started simultaneous
        concurrency: Infinity
    })
}