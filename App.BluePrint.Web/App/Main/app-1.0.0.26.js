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
                    templateUrl: abp.appPath + 'App/Main/views/admin/adminstart.cshtml',
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

})();