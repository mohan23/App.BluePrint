(function () {
    angular.module('app').controller("alertController", ['$rootScope', '$mdToast', '$animate', function ($rootScope, $mdToast, $animate) {
        $rootScope.alert = {};

        $rootScope.toastPosition = {
            bottom: false,
            top: true,
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
            $rootScope.alert = {};
            $mdToast.hide();
        });
    }]);
})();