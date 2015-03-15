(function () {
    var controllerId = 'app.views.layout.header';
    var sbControllerId = 'app.views.layout.sideBar';

    angular.module('app').controller(controllerId, ['$rootScope', '$state', 'abp.services.app.session', '$mdSidenav', function ($rootScope, $state, sessionService, $mdSidenav) {
            var vm = this;
            vm.languages = abp.localization.languages;
            vm.currentLanguage = abp.localization.currentLanguage;
            vm.isMultiLingual = (abp.localization.languages.length > 1);
            vm.logo = '/App/Main/Images/blueprint_logo.png';

            vm.menu = abp.nav.menus.MainMenu;
            vm.currentMenuName = $state.current.menu;
            vm.userSession = null;
            
            $rootScope.$on('$stateChangeSuccess', function (event, toState, toParams, fromState, fromParams) {
                vm.currentMenuName = toState.menu;
            });

            $rootScope.toggleLeft = function () {
                $mdSidenav('leftNavBar').toggle();
            };

            $rootScope.close = function () {
                $mdSidenav('leftNavBar').close();
            };

            vm.loadCurrentSession = function () {
                abp.ui.setBusy(
                '',
                    sessionService.getSessionData({
                        tenencyId: abp.session.tenantId,
                        userId: abp.session.userId
                    }).success(function (data) {
                        vm.userSession = data;
                        $rootScope.currentUser = data;
                    })
                );
                
            };

            vm.loadCurrentSession();
        }
    ]);

    angular.module('app').controller(sbControllerId, ['$rootScope', '$state', function ($rootScope, $state) {
        var vm = this;
        vm.menu = abp.nav.menus.MainMenu;
        vm.currentMenuName = $state.current.menu;
    }]);
})();