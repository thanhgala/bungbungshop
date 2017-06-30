(function (app) {
    'use strict';

    app.controller('applicationRolesEditController', applicationRolesEditController)

    applicationRolesEditController.$inject = ['apiService', '$scope', 'notificationService', '$location', '$stateParams', 'commonService'];
    
    function applicationRolesEditController(apiService, $scope, notificationService, $location, $stateParams, commonService) {
        $scope.role = {}

        $scope.updateApplicationRole = updateApplicationRole;

        function loadDetail() {
            apiService.get('/api/applicationRole/detail/' + $stateParams.id, null, function (result) {
                $scope.role = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        function updateApplicationRole() {
            apiService.put('api/applicationRole/update', $scope.role, addSuccessed, addFailed);
        }

        function addSuccessed() {
            notificationService.displaySuccess($scope.role.Name + ' đã được cập nhật thành công.');
            $location.url('application_roles');
        }

        function addFailed(response) {
            notificationService.displayError(response.data.Message);
            notificationService.displayErrorValidation(response);
        }

        loadDetail();
    }
})(angular.module('bungbungshop.application_roles'));