(function () {
    'use strict';

    angular
        .module('app')
        .factory('PatchItemService', PatchItemService);

    PatchItemService.$inject = ['$modal'];

    function PatchItemService($modal) {
        var service = {
            createController: createController
        };

        function lowerFirstLetter(string) {
            return string.charAt(0).toLowerCase() + string.slice(1);
        }

        function createController(options) {
            return function (item) {
                var resolveObject = options.resolve || {};

                var modelFunction = options.model || function (el) { return item[el] };

                $.each(options.modelItems, function (i, el) {
                    resolveObject[lowerFirstLetter(el)] = function () {
                        return modelFunction(el);
                    };
                });

                resolveObject.mode = function () { return options.mode || "update"; };

                var modalInstance = $modal.open({
                    animation: true,
                    ariaLabelledBy: 'modal-title',
                    ariaDescribedBy: 'modal-body',
                    templateUrl: options.template,
                    controller: options.controller,
                    controllerAs: 'vm',
                    resolve: resolveObject
                });

                modalInstance.result.then(function (result) {
                    var patchData = [];

                    $.each(options.modelItems, function (i, el) {
                        patchData.push({
                            'op': 'replace',
                            'path': '/' + el,
                            'value': result[lowerFirstLetter(el)]
                        });
                    });

                    options.service.patchItem(options.itemId || item.Id, patchData).then(function () {
                        options.callback();
                    });
                });
            };
        }

        return service;
    }
})()