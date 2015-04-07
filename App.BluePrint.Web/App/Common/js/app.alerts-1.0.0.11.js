(function () {

    angular.module('app').controller("alertController", ['$rootScope', '$mdToast', '$animate', function ($rootScope, $mdToast, $animate) {
        $rootScope.alert = {};

        $rootScope.showAlert = function (type, title, message) {
            var msg = message;
            if (typeof message == 'object')
                msg = title + " !!!. " + message.message;
            else if (title != undefined)
                msg = title + " !!!. " + message;

            $rootScope.alert = {
                type: type,
                title: title,
                message: msg
            }
        };

        $rootScope.hideAlert = function () {
            $rootScope.alert = {
                type: undefined,
                title: undefined,
                message: undefined
            }
        };

        $rootScope.toastPosition = {
            bottom: true,
            top: false,
            left: false,
            right: true
        };

        $rootScope.getToastPosition = function () {
            return Object.keys($rootScope.toastPosition)
              .filter(function (pos) { return $rootScope.toastPosition[pos]; })
              .join(' ');
        };
        $rootScope.showProgressToast = function () {
            $mdToast.show({
                controller: "alertController",
                templateUrl: '/App/Common/Templates/progressToast.html',
                hideDelay: 0,
                position: $rootScope.getToastPosition()
            });
        };

        $rootScope.hideProgressToast = function () {
            $mdToast.hide();
        };

        $rootScope.$on('$viewContentLoading', function (event, viewConfig) {
            $rootScope.hideAlert();
            $mdToast.hide();
        });
    }]);
})();