describe("Change Communications Modal Controller", function () {
    let $controller: angular.IControllerService;
    let $uibModalInstance: angular.ui.bootstrap.IModalServiceInstance;
    let controller: ChangeCommunicationsController;

    const defaultChannel1 = "SJA1";
    const defaultChannel2 = "SJA2";
    const defaultPhoneNUmber = "01234 567 890";

    const newChannel1 = "SJA3";
    const newChannel2 = "SJA4";
    const newPhoneNumber = "01234 098 765";

    beforeEach(angular.mock.module('app'));

    beforeEach(inject(function (_$controller_: angular.IControllerService) {
        $controller = _$controller_;

        $uibModalInstance = jasmine.createSpyObj('$uibModalInstance', ['close', 'dismiss']);

        controller = $controller<ChangeCommunicationsController>('ChangeCommunicationsController', {
            $uibModalInstance: $uibModalInstance,
            usingSJARadio: true,
            usingAirwave: false,
            radioChannel: defaultChannel1,
            fallbackRadioChannel: defaultChannel2,
            controlPhoneNumber: defaultPhoneNUmber,
            cruTrackingInUse: true
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
        expect(controller.usingSJARadio).toBe(true);
        expect(controller.usingAirwave).toBe(false);
        expect(controller.radioChannel).toBe(defaultChannel1);
        expect(controller.fallbackRadioChannel).toBe(defaultChannel2);
        expect(controller.controlPhoneNumber).toBe(defaultPhoneNUmber);
        expect(controller.cruTrackingInUse).toBe(true);
    });

    it('should have properties usingSJARadio, usingAirwave, radioChannel, fallbackRadioChannel, controlPhoneNumber and cruTrackingInUse', function () {
        expect(controller.usingSJARadio).toBeDefined();
        expect(controller.usingAirwave).toBeDefined();
        expect(controller.radioChannel).toBeDefined();
        expect(controller.fallbackRadioChannel).toBeDefined();
        expect(controller.controlPhoneNumber).toBeDefined();
        expect(controller.cruTrackingInUse).toBeDefined();
    });

    it('should call uibModalInstance close on submit', function () {
        let testName = 'test-name';

        controller.usingSJARadio = false;
        controller.usingAirwave = true;
        controller.radioChannel = newChannel1;
        controller.fallbackRadioChannel = newChannel2;
        controller.controlPhoneNumber = newPhoneNumber;
        controller.cruTrackingInUse = false;

        controller.submit();

        expect($uibModalInstance.close).toHaveBeenCalledWith({
            usingSJARadio: false,
            usingAirwave: true,
            radioChannel: newChannel1,
            fallbackRadioChannel: newChannel2,
            controlPhoneNumber: newPhoneNumber,
            cruTrackingInUse: false
        });
    });

    it('should call uibModalInstance dismiss on cancel', function () {
        let testName = 'test-name';

        controller.cancel();

        expect($uibModalInstance.dismiss).toHaveBeenCalledWith('cancel');
    });
});