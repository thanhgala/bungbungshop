(function (app) {
    'use strict';

    app.controller('applicationUsersListController', applicationUsersListController);

    applicationUsersListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter'];

    function applicationUsersListController($scope, apiService, notificationService, $ngBootbox, $filter) {
        $scope.loading = true;
        $scope.data = [];
        $scope.page = 0;
        $scope.search = search;
        $scope.clearSearch = clearSearch;

        $scope.getApplicationUser = getApplicationUser;

        $scope.deleteItem = deleteItem;

        function deleteItem(id) {
            $ngBootbox.confirm('Bạn có chắc muốn xóa?')
                .then(function () {
                    var config = {
                        params: {
                            id: id
                        }
                    }
                    apiService.del('/api/applicationUser/delete', config, function () {
                        notificationService.displaySuccess('Đã xóa thành công.');
                        search();
                    },
                    function () {
                        notificationService.displayError('Xóa không thành công.');
                    });
                });
        }

        function search() {
            getApplicationUser();
        }
        function getApplicationUser(page) {
            page = page || 0;
            $scope.loading = true;
            var config = {
                params: {
                    page: page,
                    pageSize: 6,
                    filter: $scope.keyword
                }
            }
            apiService.get('/api/applicationUser/getlistpaging', null, dataLoadCompleted, dataLoadFailed);
        }

        function dataLoadCompleted(result) {
            if (result.data.TotalCount == 0)
            {
                notificationService.displayWarning('Không có bản ghi nào được tìm thấy.');
            }
            $scope.data = result.data.Items;
            //$scope.page = result.data.Page;
            //$scope.pagesCount = result.data.TotalPages;
            //$scope.totalCount = result.data.TotalCount;
            //$scope.countInPage = result.data.Count
            $scope.loading = false;

            if ($scope.keyword && $scope.keyword.length) {
                notificationService.displayInfo(result.data.Items.length + ' items found');
            }
        }
        function dataLoadFailed(response) {
            notificationService.displayError(response.data);
        }

        function clearSearch() {
            $scope.keyword = '';
            search();
        }

        $scope.getApplicationUser();
    }
})(angular.module('bungbungshop.application_users'));