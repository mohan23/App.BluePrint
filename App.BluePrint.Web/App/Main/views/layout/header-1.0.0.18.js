(function () {
    var controllerId = 'app.views.layout.header';
    var sbControllerId = 'app.views.layout.sideBar';
    var themeProvider;

    angular.module('app').config(['$mdThemingProvider', function ($mdThemingProvider) {
        themeProvider = $mdThemingProvider;
    }]);


    angular.module('app').controller(controllerId, ['$rootScope', '$mdToast', '$state', 'abp.services.app.session', '$mdSidenav', function ($rootScope, $mdToast, $state, sessionService, $mdSidenav) {
            var vm = this;
            vm.languages = abp.localization.languages;
            vm.currentLanguage = abp.localization.currentLanguage;
            vm.isMultiLingual = (abp.localization.languages.length > 1);
            vm.logo = '/App/Main/Images/blueprint_logo.png';
            $rootScope.loadedAdminMenus = false;

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
                        $rootScope.hideProgressToast();
                    })
                );
                
            };

            $rootScope.updateNavBar = function (theme) {
                $(".navbar").each(function ()
                {
                    $(this).removeClass (function (index, css) {
                        return (css.match (/\bnavbar-\S+/g) || []).join(' ');
                    });
                    //var match = this.className.match(/\w*navbar-\w*/);
                    //if (match) {
                    //    if (match.length > 0) {
                    //        $(this).removeClass(match[0]);
                    //    }
                        //var nvBar = $(this);
                        //match.each(function (index) {
                        //    nvBar.removeClass(match[index]);
                        //});
                    //}

                    $(this).addClass("navbar-material-" + theme + " navbar-fixed-top");
                });

            };

            vm.loadCurrentSession();
            $rootScope.currentThemeProvider = themeProvider;
        }
    ]);

    angular.module('app').controller(sbControllerId, ['$rootScope', '$state', function ($rootScope, $state) {
        var vm = this;
        vm.menu = abp.nav.menus.MainMenu;
        vm.currentMenuName = $state.current.menu;
    }]);
})();