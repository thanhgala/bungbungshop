﻿(function (app) {
    'use strict';

    app.controller('applicationRolesListController', applicationRolesListController);

    applicationRolesListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter'];

    function applicationRolesListController($scope, apiService, notificationService, $ngBootbox, $filter) {
        $scope.loading = true;
        $scope.data = [];
        $scope.page = 0;
        $scope.search = search;
        $scope.clearSearch = clearSearch;

        $scope.getApplicationRole = getApplicationRole;

        $scope.deleteItem = deleteItem;

        $scope.selectAll = selectAll;

        $scope.deleteMultiple = deleteMultiple;

        function deleteItem(id) {
            $ngBootbox.confirm('Bạn có chắc muốn xóa?')
                .then(function () {
                    var config = {
                        params: {
                            id: id
                        }
                    }
                    apiService.del('/api/applicationRole/delete', config, function () {
                        notificationService.displaySuccess('Đã xóa thành công.');
                        search();
                    },
                    function () {
                        notificationService.displayError('Xóa không thành công.');
                    });
                });
        }

        function deleteMultiple() {
            var listId = [];
            angular.forEach($scope.selected, function (item) {
                listId.push(item.ID);
            });
            //$.each($scope.selected, function (i, item) {
            //    listId.push(item.ID);
            //});
            var config = {
                params: {
                    checkedList: JSON.stringify(listId)
                }
            }
            apiService.del('api/applicationRole/deletemulti', config, function (result) {
                notificationService.displaySuccess('Xóa thành công ' + result.data + ' bản ghi')
                search();
            }, function (error) {
                notificationService.displayError('Xóa không thành công.')
            });
        }

        $scope.isAll = false; //mặc định là chưa check ô nào
        function selectAll() {
            if ($scope.isAll === false) {
                angular.forEach($scope.data, function (item) {
                    item.checked = true;
                });
                $scope.isAll = true;
            } else {
                angular.forEach($scope.data, function (item) {
                    item.checked = false;
                });
                $scope.isAll = false;
            }
        }

        //watch lắng nghe 1 scope nào đó
        $scope.$watch("data", function (n, o) {
            var checked = $filter("filter")(n, { checked: true });
            if (checked.length) {
                $scope.selected = checked;
                $('#btnDelete').removeAttr('disabled')
            } else {
                $('#btnDelete').attr('disabled', 'disabled');
            }
        }, true);

        function search() {
            getApplicationRole();
        }
        function getApplicationRole(page) {
            page = page || 0;
            $scope.loading = true;
            var config = {
                params: {
                    page: page,
                    pageSize: 6,
                    filter: $scope.keyword
                }
            }
            apiService.get('/api/applicationRole/getlistpaging', config, dataLoadCompleted, dataLoadFailed);
        }

        function dataLoadCompleted(result) {
            if (result.data.TotalCount == 0)
            {
                notificationService.displayWarning('Không có bản ghi nào được tìm thấy.');
            }
            $scope.data = result.data.Items;
            $scope.page = result.data.Page;
            $scope.pagesCount = result.data.TotalPages;
            $scope.totalCount = result.data.TotalCount;
            $scope.countInPage = result.data.Count
            $scope.loading = false;

            if ($scope.keyword && $scope.keyword.length) {
                notificationService.displayInfo(result.data.Items.length + ' items found');
            }
        }
        function dataLoadFailed(response) {
            notificationService.displayError(response.data);
        }

        function clearSearch() {
            $scope.filterExpression = '';
            search();
        }

        $scope.getApplicationRole();
    }
})(angular.module('bungbungshop.application_roles'));