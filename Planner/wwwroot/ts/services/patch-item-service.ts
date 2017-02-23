angular
    .module('app')
    .factory('PatchItemService', PatchItemService);

PatchItemService.$inject = ['$uibModal'];

interface PatchItemServiceOptions {
    resolve?: ResolveObject;
    model?: (el: any) => any;
    modelItems: string[];
    mode?: string;
    template: string;
    controller: string;
    service: any;
    itemId?: number;
    callback: () => void;
}

interface ResolveObject {
    [index: string]: Object;
    mode?: () => string;
}

class PatchItemService {
    constructor($uibModal: angular.ui.bootstrap.IModalService) {
        this.$uibModal = $uibModal;
    }

    private $uibModal: angular.ui.bootstrap.IModalService;

    private lowerFirstLetter(string: string) {
        return string.charAt(0).toLowerCase() + string.slice(1);
    }

    createController(options: PatchItemServiceOptions) {
        return function(item: any) {
            let resolveObject: ResolveObject = options.resolve || {};

            let modelFunction = options.model || function(el) { return item[el] };

            $.each(options.modelItems, function(i, el) {
                resolveObject[this.lowerFirstLetter(el)] = function() {
                    return modelFunction(el);
                };
            });

            resolveObject.mode = function() { return options.mode || "update"; };

            var modalInstance = this.$uibModal.open({
                animation: true,
                ariaLabelledBy: 'modal-title',
                ariaDescribedBy: 'modal-body',
                templateUrl: options.template,
                controller: options.controller,
                controllerAs: 'vm',
                resolve: resolveObject
            });

            modalInstance.result.then(function(result: any) {
                var patchData: any = [];

                $.each(options.modelItems, function(i, el) {
                    patchData.push({
                        'op': 'replace',
                        'path': '/' + el,
                        'value': result[this.lowerFirstLetter(el)]
                    });
                });

                options.service.patchItem(options.itemId || item.Id, patchData).then(function() {
                    options.callback();
                });
            });
        };
    }
}