describe("Change Special Considerations Modal Controller", function () {
    let $controller: angular.IControllerService;
    let $uibModalInstance: angular.ui.bootstrap.IModalServiceInstance;
    let controller: ChangeConsiderationsController;

    beforeEach(angular.mock.module('app'));

    beforeEach(inject(function (_$controller_: angular.IControllerService) {
        $controller = _$controller_;

        $uibModalInstance = jasmine.createSpyObj('$uibModalInstance', ['close', 'dismiss']);

        controller = $controller<ChangeConsiderationsController>('ChangeConsiderationsController', {
            $uibModalInstance: $uibModalInstance,
            soloRespondingExpected: true,
            highSpeedRoadsAtEvent: false,
            expectingBadWeather: true,
            hasSeriousHistory: false,
            widerDistribution: true
        });
    }));

    it('should exist', function () {
        expect(controller).toBeDefined();
    });

    it('should have functions submit and cancel', function () {
        expect(controller.submit).toBeDefined();
        expect(controller.cancel).toBeDefined();
    });

    it('should populate data with injected values', function () {
        expect(controller.soloRespondingExpected).toBe(true);
        expect(controller.highSpeedRoadsAtEvent).toBe(false);
        expect(controller.expectingBadWeather).toBe(true);
        expect(controller.hasSeriousHistory).toBe(false);
        expect(controller.widerDistribution).toBe(true);
    });

    it('should have properties usingSJARadio, usingAirwave, radioChannel, fallbackRadioChannel, controlPhoneNumber and cruTrackingInUse', function () {
        expect(controller.soloRespondingExpected).toBeDefined();
        expect(controller.highSpeedRoadsAtEvent).toBeDefined();
        expect(controller.expectingBadWeather).toBeDefined();
        expect(controller.hasSeriousHistory).toBeDefined();
        expect(controller.widerDistribution).toBeDefined();
    });

    it('should call uibModalInstance close on submit', function () {
        let testName = 'test-name';

        controller.soloRespondingExpected = false;
        controller.highSpeedRoadsAtEvent = true;
        controller.expectingBadWeather = false;
        controller.hasSeriousHistory = true;
        controller.widerDistribution = false;

        controller.submit();

        expect($uibModalInstance.close).toHaveBeenCalledWith({
            soloRespondingExpected: false,
            highSpeedRoadsAtEvent: true,
            expectingBadWeather: false,
            hasSeriousHistory: true,
            widerDistribution: false
        });
    });

    it('should call uibModalInstance dismiss on cancel', function () {
        let testName = 'test-name';

        controller.cancel();

        expect($uibModalInstance.dismiss).toHaveBeenCalledWith('cancel');
    });
});