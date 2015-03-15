(function () {
    'use strict';

    var app = angular.module('app', [
        'ngAnimate',
        'ngSanitize',
        'ngMaterial',

        'ui.router',
        'ui.bootstrap',
        'ui.jq',

        'abp'
    ]);

    app.directive('alertDismiss', function () {
        return {
            restrict: 'E',
            templateUrl: '/App/Common/alertDismissable.html'
        }
    });

    app.directive('alertMessage', function () {
        return {
            restrict: 'E',
            templateUrl: '/App/Common/alertMessage.html'
        }
    });

    /* MESSAGE **************************************************/
    //Defines Message API, not implements it

    abp.message = abp.message || {};

    abp.message.info = function (message, title) {
        abp.log.warn('abp.message.info is not implemented!');
        alert('INFO ' + (title || '') + ' ' + message);

    };

    abp.message.warn = function (message, title) {
        abp.log.warn('abp.message.warn is not implemented!');
        alert('WARN ' + (title || '') + ' ' + message);
    };

    abp.message.error = function (message, title) {
        if (title == undefined)
            title = "Error !";
        abp.utils.showUIMessage('danger', title, message);
    };

    abp.message.confirm = function (message, titleOrCallback, callback) {
        abp.log.warn('abp.message.confirm is not implemented!');

        if (titleOrCallback && !(typeof titleOrCallback == 'string')) {
            callback = titleOrCallback;
        }

        var result = confirm(message);
        callback && callback(result);
    };

    app.controller("alertController", ["$scope", function ($scope) {
        $scope.alert = {};
        $scope.setAlertData = function (atype, atitle, amessage) {
            $scope.alert = {
                type: atype,
                title: atitle,
                message: amessage
            }
        };
    }]);

    abp.utils.showUIMessage = function (atype, atitle, amessage) {
        var $alertCont = angular.element(document.getElementById('alertContainer')).scope();
        $alertCont.setAlertData(atype, atitle, amessage);
    };
    

})();