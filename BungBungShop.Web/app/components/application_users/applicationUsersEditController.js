(function (app) {
    'use strict';

    app.controller('applicationUsersEditController', applicationUsersEditController)

    applicationUsersEditController.$inject = ['apiService', '$scope', 'notificationService', '$location', '$stateParams', 'commonService'];
    
    function applicationUsersEditController(apiService, $scope, notificationService, $location, $stateParams, commonService) {
        $scope.account = {
            Groups : []
        }

        $scope.updateAccount = updateAccount;

        function loadDetail() {
            apiService.get('/api/applicationUser/detail/' + $stateParams.id, null, function (result) {
                $scope.account = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }
        function loadGroups() {
            apiService.get('/api/applicationGroup/getlistall',
                null,
                function (response) {
                    $scope.groups = response.data;
                }, function (err) {
                    notificationService.displayError('Không tải được danh sách nhóm.');
                })
        }


        function updateAccount() {
            apiService.put('api/applicationUser/update', $scope.account, addSuccessed, addFailed);
        }

        function addSuccessed() {
            notificationService.displaySuccess($scope.account.FullName + ' đã được cập nhật thành công.');
            $location.url('application_users');
        }

        function addFailed(response) {
            notificationService.displayError(response.data.Message);
            notificationService.displayErrorValidation(response);
        }

        loadDetail();
        loadGroups();
    }
})(angular.module('bungbungshop.application_users'));