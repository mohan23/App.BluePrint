(function () {
    angular.module('app').directive('alertDismiss', function () {
        return {
            restrict: 'E',
            templateUrl: '/App/Common/templates/alertDismissable.html'
        }
    });

    angular.module('app').directive('alertMessage', function () {
        return {
            restrict: 'E',
            templateUrl: '/App/Common/templates/alertMessage.html'
        }
    });
})();