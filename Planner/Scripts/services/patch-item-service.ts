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

    static $inject = ['$uibModal'];

    private $uibModal: angular.ui.bootstrap.IModalService;

    private static lowerFirstLetter(string: string) {
        return string.charAt(0).toLowerCase() + string.slice(1);
    }

    createController(options: PatchItemServiceOptions) {
        return function(item: any) {
            let resolveObject: ResolveObject = options.resolve || {};

            let modelFunction = options.model || function(el) { return item[el] };

            $.each(options.modelItems, function(i, el) {
                resolveObject[PatchItemService.lowerFirstLetter(el)] = function() {
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
                        'value': result[PatchItemService.lowerFirstLetter(el)]
                    });
                });

                options.service.patchItem(options.itemId || item.id, patchData).then(function() {
                    options.callback();
                });
            });
        };
    }
}

angular.module('app').service('PatchItemService', PatchItemService);
