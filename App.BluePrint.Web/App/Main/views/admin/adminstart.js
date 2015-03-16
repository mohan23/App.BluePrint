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
                    userId: undefined,
                    menuId: undefined,
                    roleIds: $rootScope.currentUser.roleIds
                }).success(function (data) {
                    vm.adminMenu = data.id.menus;
                    vm.adminCats = data.id.categoryList;
                })
            );
        }
    ]);
})();