(function () {
    var controllerId = 'app.views.layout';
    angular.module('app').controller(controllerId, [
        '$scope', function ($scope) {
            var vm = this;

            vm.initMaterial = function () {
                //angular.element.material.init();
                $.material.init();
            };

            vm.initMaterial();
        }]);
})();