describe("Add Item Modal Controller", function () {
    let $controller: angular.IControllerService;
    let $uibModalInstance: angular.ui.bootstrap.IModalServiceInstance;
    let controller: AddItemController;

    beforeEach(angular.mock.module('app'));

    beforeEach(inject(function (_$controller_: angular.IControllerService) {
        $controller = _$controller_;

        $uibModalInstance = jasmine.createSpyObj('$uibModalInstance', ['close', 'dismiss']);

        controller = $controller<AddItemController>('AddItemController', {
            $uibModalInstance: $uibModalInstance,
            itemName: 'testItemName'
        });
    }));

    it('should exist', function () {
        expect(controller).toBeDefined();
    });

    it('should have functions submit and cancel', function () {
        expect(controller.submit).toBeDefined();
        expect(controller.cancel).toBeDefined();
    });

    it('should have properties itemName and name', function () {
        expect(controller.itemName).toBeDefined();
        expect(controller.name).toBeDefined();
    });

    it('should call uibModalInstance close on submit', function () {
        let testName = 'test-name';

        controller.name = testName;

        controller.submit();

        expect($uibModalInstance.close).toHaveBeenCalledWith({
            name: testName
        });
    });

    it('should call uibModalInstance dismiss on cancel', function () {
        let testName = 'test-name';

        controller.cancel();

        expect($uibModalInstance.dismiss).toHaveBeenCalledWith('cancel');
    });
});