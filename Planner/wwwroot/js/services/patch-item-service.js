var PatchItemService = (function () {
    function PatchItemService($uibModal) {
        this.$uibModal = $uibModal;
    }
    PatchItemService.lowerFirstLetter = function (string) {
        return string.charAt(0).toLowerCase() + string.slice(1);
    };
    PatchItemService.prototype.createController = function (options) {
        return function (item) {
            var resolveObject = options.resolve || {};
            var modelFunction = options.model || function (el) { return item[el]; };
            $.each(options.modelItems, function (i, el) {
                resolveObject[PatchItemService.lowerFirstLetter(el)] = function () {
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
                        'value': result[PatchItemService.lowerFirstLetter(el)]
                    });
                });
                options.service.patchItem(options.itemId || item.id, patchData).then(function () {
                    options.callback();
                });
            });
        };
    };
    return PatchItemService;
}());
PatchItemService.$inject = ['$uibModal'];
angular.module('app').service('PatchItemService', PatchItemService);
//# sourceMappingURL=patch-item-service.js.map