(function (app) {
    'use strict';

    app.controller('applicationGroupsEditController', applicationGroupsEditController)

    applicationGroupsEditController.$inject = ['apiService', '$scope', 'notificationService', '$location', '$stateParams', 'commonService'];
    
    function applicationGroupsEditController(apiService, $scope, notificationService, $location, $stateParams, commonService) {
        $scope.group = {
            Roles:[]
        }

        $scope.updateApplicationGroup = updateApplicationGroup;

        function loadDetail() {
            apiService.get('/api/applicationGroup/detail/' + $stateParams.id, null, function (result) {
                $scope.group = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        function updateApplicationGroup() {
            apiService.put('api/applicationGroup/update', $scope.group, addSuccessed, addFailed);
        }

        function addSuccessed() {
            notificationService.displaySuccess($scope.group.Name + ' đã được cập nhật thành công.');
            $location.url('application_groups');
        }

        function addFailed(response) {
            notificationService.displayError(response.data.Message);
            notificationService.displayErrorValidation(response);
        }

        function loadRoles() {
            apiService.get('/api/applicationRole/getlistall',
                null,
                function (response) {
                    $scope.roles = response.data;
                }, function (err) {
                    notificationService.displayError('Không tải được danh sách quyền.')
                })
        }

        loadRoles();
        loadDetail();
    }
})(angular.module('bungbungshop.application_groups'));