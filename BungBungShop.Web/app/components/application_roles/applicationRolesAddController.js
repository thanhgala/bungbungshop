(function (app) {
    'use strict';

    app.controller('applicationRolesAddController', applicationRolesAddController);

    applicationRolesAddController.$inject = ['apiService', '$scope', 'notificationService', '$location', 'commonService'];
    function applicationRolesAddController(apiService, $scope, notificationService, $location, commonService) {
        $scope.role = {
            ID: 0,
            Roles:[]
        }  

        $scope.addAppRole = addApplicationRole;

        function addApplicationRole() {
            apiService.post('/api/applicationRole/add', $scope.role, addSuccessed, addFailed);
        }

        function addSuccessed() {
            notificationService.displaySuccess($scope.role.Name + ' đã được thêm mới.');

            $location.url('application_roles');
        }
        function addFailed(response) {
            notificationService.displayError(response.data.Message);
            notificationService.displayErrorValidation(response);
        }
    }
})(angular.module('bungbungshop.application_roles'));