(function (app) {
    'use strict';

    app.controller('applicationUsersAddController', applicationUsersAddController);

    applicationUsersAddController.$inject = ['apiService', '$scope', 'notificationService', '$location', 'commonService'];
    function applicationUsersAddController(apiService, $scope, notificationService, $location, commonService) {
        $scope.account = {
            Id: 0,
            Groups: []
        }  

        $scope.addAccount = addAccount;

        function addAccount() {
            apiService.post('/api/applicationUser/add', $scope.account, addSuccessed, addFailed);
        }

        function addSuccessed() {
            notificationService.displaySuccess($scope.account.FullName + ' đã được thêm mới.');

            $location.url('application_users');
        }
        function addFailed(response) {
            notificationService.displayError(response.data.Message);
            notificationService.displayErrorValidation(response);
        }

        function loadGroups()
        {
            apiService.get('/api/applicationGroup/getlistall',
                null,
                function (response) {
                    $scope.groups = response.data;
                }, function (err) {
                    notificationService.displayError('Không tải được danh sách nhóm.');
                })
        }
        loadGroups();
    }
})(angular.module('bungbungshop.application_users'));