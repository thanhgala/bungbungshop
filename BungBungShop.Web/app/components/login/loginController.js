(function (app) {
    app.controller('loginController', ['$scope', 'loginService', '$injector', 'notificationService',
        function ($scope, loginService, $injector, notificationService) {

            $scope.loginData = {
                userName: "",
                password: ""
            };

            $scope.loginSubmit = function () {
                loginService.login($scope.loginData.userName, $scope.loginData.password).then(function (response) {
                    if (response != null) {
                        notificationService.displayError("Đăng nhập không đúng");
                    }
                    else {
                        var stateService = $injector.get('$state');
                        stateService.go('home');
                    }
                });
            }
        }]);

    //app.controller('loginController', loginController);
    //loginController.$inject = ['$scope', 'loginService', 'notificationService', '$state'];
    //function loginController($scope, loginService, notificationService, $state) {
    //    $scope.loginData = {
    //        userName: "",
    //        password: ""
    //    };
    //    $scope.loginSubmit = loginSubmit;

    //    function loginSubmit() {
    //        loginService.login($scope.loginData.userName, $scope.loginData.password).then(function (response) {
    //            if (response != null) {
    //                notificationService.displayError("Đăng nhập không đúng.");
    //            }
    //            else {
    //                $state.go('home');
    //            }
    //        });

    //    }
    //}
})(angular.module('bungbungshop'));