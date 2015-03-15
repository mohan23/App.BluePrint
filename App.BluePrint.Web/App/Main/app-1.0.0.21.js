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

    //Configuration for Angular UI routing.
    app.config([
        '$stateProvider', '$urlRouterProvider', '$mdThemingProvider',
        function ($stateProvider, $urlRouterProvider, $mdThemingProvider) {
            $urlRouterProvider.otherwise('/');
            $stateProvider
                .state('home', {
                    url: '/',
                    templateUrl: '/App/Main/views/home/home.cshtml',
                    menu: 'Dashboard' //Matches to name of 'Home' menu in App.ProjectsNavigationProvider
                })
                .state('process', {
                    url: '/about',
                    templateUrl: '/App/Main/views/process/index.cshtml',
                    menu: 'Process' //Matches to name of 'About' menu in App.ProjectsNavigationProvider
                })
                .state('search', {
                    url: '/search',
                    templateUrl: abp.appPath + 'App/Main/views/search/index.cshtml',
                    menu: 'Search' //Matches to name of 'Users' menu in ProjectsNavigationProvider
                })
                .state('admin', {
                    url: '/admin',
                    templateUrl: abp.appPath + 'App/Main/views/admin/index.cshtml',
                    menu: 'Administration' //Matches to name of 'Users' menu in ProjectsNavigationProvider
                })
                .state('insights', {
                    url: '/insights',
                    templateUrl: abp.appPath + 'App/Main/views/insights/index.cshtml',
                    menu: 'Insights' //Matches to name of 'Users' menu in ProjectsNavigationProvider
                });

            $mdThemingProvider.theme('default').primaryPalette('teal');
            $mdThemingProvider.theme('themePink').primaryPalette('pink');
        }
    ]);

    app.directive('alertDismiss', function () {
        return {
            restrict: 'E',
            templateUrl: '/App/Common/templates/alertDismissable.html'
        }
    });

    app.directive('alertMessage', function () {
        return {
            restrict: 'E',
            templateUrl: '/App/Common/templates/alertMessage.html'
        }
    });

    /* MESSAGE **************************************************/
    //Defines Message API, not implements it

    abp.message = abp.message || {};

    abp.message.info = function (message, title) {
        abp.utils.showUIMessage('info', title, message);
    };

    abp.message.warn = function (message, title) {
        abp.utils.showUIMessage('warn', title, message);
    };

    abp.message.error = function (message, title) {
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

    app.controller("alertController", ['$rootScope', '$mdToast', '$animate', function ($rootScope, $mdToast, $animate) {
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

    }]);

    abp.utils.showUIMessage = function (atype, atitle, amessage) {
        var $alertCont = angular.element(document.getElementById('alertContainer')).scope();
        $alertCont.hideProgressToast();
        $alertCont.$apply(function () {
            $alertCont.alert.type = atype;
            $alertCont.alert.title = atitle;
            $alertCont.alert.message = amessage;
        });
    };

    abp.utils.clearAlert = function () {
        var $alertCont = angular.element(document.getElementById('alertContainer')).scope();
        $alertCont.$apply(function () {
            $alertCont.alert.type = undefined;
            $alertCont.alert.title = undefined;
            $alertCont.alert.message = undefined;
        });
    }

    abp.utils.showProgress = function () {
        var $alertCont = angular.element(document.getElementById('alertContainer')).scope();
        $alertCont.alert = {};
        $alertCont.$apply(function () {
            $alertCont.showProgressToast();
        });
    };

    abp.utils.hideProgress = function () {
        var $alertCont = angular.element(document.getElementById('alertContainer')).scope();
        $alertCont.$apply(function () {
            $alertCont.hideProgressToast();
        });
    };

    /* UI *******************************************************/

    abp.ui = abp.ui || {};

    /* UI BLOCK */
    //Defines UI Block API, not implements it

    abp.ui.block = function (elm) {
        abp.utils.showProgress();
    };

    abp.ui.unblock = function (elm) {
        abp.utils.hideProgress();
    };

    /* UI BUSY */
    //Defines UI Busy API, not implements it

    abp.ui.setBusy = function (elm, optionsOrPromise) {
        optionsOrPromise.block = true;
        abp.ui.block(elm);
    };

    abp.ui.clearBusy = function (elm) {
        abp.ui.unblock(elm);
    };

})();