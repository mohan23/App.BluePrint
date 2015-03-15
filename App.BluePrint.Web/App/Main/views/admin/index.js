(function () {
    var controllerId = 'app.views.admin.index';
    angular.module('app').controller(controllerId, ['$rootScope',
        'abp.services.app.admin',
        function ($rootScope, adminService) {
            var vm = this;

            vm.adminMenu = [];
            vm.adminCats = [];

            abp.ui.setBusy(
                null,
                adminService.getAdminMenus({
                    roleIds: $rootScope.currentUser.roleIds
                }).success(function (data) {
                    vm.adminMenu = data.menus;
                    vm.adminCats = data.categoryList;
                })
            );
        }
    ]);
})();