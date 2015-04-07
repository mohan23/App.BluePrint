(function () {
    var controllerId = 'app.views.admin.adminstart';
    var $stateProviderReference;
    var $urlRouteReference;

    var app = angular.module('app');

    app.config(['$stateProvider', '$urlRouterProvider', '$mdThemingProvider',
        function ($stateProvider, $urlRouterProvider, $mdThemingProvider) {
            $stateProviderReference = $stateProvider;
            $urlRouteReference = $urlRouterProvider
        }]);

    app.controller(controllerId, ['$rootScope', '$state', 'abp.services.app.admin',
        function ($rootScope, $state, adminService) {
            var vm = this;
            vm.menuData = [];
            vm.currentMenu = $state.current.name + ".";
            $rootScope.updateNavBar("blue-grey-700");

            abp.ui.setBusy(
                null,
                adminService.getAdminMenus({
                    userId: '',
                    menuId: '',
                    roleIds: $rootScope.currentUser.roleIds
                }).success(function (data) {
                    if (!$rootScope.loadedAdminMenus)
                        vm.updateRouteData(data.items);
                    vm.menuData = data.items;
                    $rootScope.hideProgressToast();
                    //console.log(angular.toJson($state.get()));
                })
            );

            vm.updateRouteData = function (items) {
                angular.forEach(items, function (catItems) {
                    angular.forEach(catItems.menus, function (route) {
                        var mnuName = $state.current.name + "." + route.menuName;
                        if ($state.get(mnuName) == null) {
                            $stateProviderReference.state(mnuName,
                                {
                                    url: route.linkUrl,
                                    views: {
                                        "adminvw": {
                                            templateUrl: route.relativeUrl
                                        }
                                    }
                                });
                        }
                    });
                });
                $rootScope.loadedAdminMenus = true;
            };
        }
    ]);
})();