(function () {
    var controllerId = 'app.views.admin.processDesign';
    var app = angular.module('app');

    app.controller(controllerId, ['$rootScope', '$scope', '$timeout', '$mdSidenav',
       function ($rootScope, $scope, $timeout, $mdSidenav) {
           $rootScope.updateNavBar("pink-400");
           if ($rootScope.currentThemeProvider != undefined)
               $rootScope.currentThemeProvider.setDefaultTheme('themePink');
           
           $mdSidenav('left').open();

           $scope.toggleLeft = function () {
               $mdSidenav('left').toggle();
           };
           $scope.toggleRight = function () {
               $mdSidenav('right').toggle();
           };
       }]);

    app.controller(controllerId + ".LeftCtrl", ['$scope','$mdSidenav',
      function ($scope, $mdSidenav) {
          $scope.toggleLeft = function () {
              $mdSidenav('left').close();
          };
      }]);

    app.controller(controllerId + ".RightCtrl", ['$scope', '$mdSidenav',
     function ($scope, $mdSidenav) {
         $scope.toggleLeft = function () {
             $mdSidenav('right').close();
         };
     }]);
})();