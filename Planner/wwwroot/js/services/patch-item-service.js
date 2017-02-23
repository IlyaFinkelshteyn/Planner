angular
    .module('app')
    .factory('PatchItemService', PatchItemService);
PatchItemService.$inject = ['$uibModal'];
var PatchItemService = (function () {
    function PatchItemService($uibModal) {
        this.$uibModal = $uibModal;
    }
    PatchItemService.prototype.lowerFirstLetter = function (string) {
        return string.charAt(0).toLowerCase() + string.slice(1);
    };
    PatchItemService.prototype.createController = function (options) {
        return function (item) {
            var resolveObject = options.resolve || {};
            var modelFunction = options.model || function (el) { return item[el]; };
            $.each(options.modelItems, function (i, el) {
                resolveObject[this.lowerFirstLetter(el)] = function () {
                    return modelFunction(el);
                };
            });
            resolveObject.mode = function () { return options.mode || "update"; };
            var modalInstance = this.$uibModal.open({
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
                        'value': result[this.lowerFirstLetter(el)]
                    });
                });
                options.service.patchItem(options.itemId || item.Id, patchData).then(function () {
                    options.callback();
                });
            });
        };
    };
    return PatchItemService;
}());
