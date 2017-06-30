(function (app) {
    app.controller('productListController', productListController);

    productListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox','$filter'];

    function productListController($scope, apiService, notificationService, $ngBootbox,$filter) {
        $scope.products = [];

        $scope.keyword = '';

        $scope.getProducts = getProducts;

        $scope.search = search;

        $scope.deleteProduct = deleteProduct;

        $scope.selectAll = selectAll;

        $scope.deleteMultiple = deleteMultiple;

        function search() {
            getProducts();
        }

        function getProducts(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize:5
                }
            }
            apiService.get('api/product/getall', config, function (result) {
                if (result.data.TotalCount == 0) {
                    notificationService.displayWarning('Không có bản ghi nào được tìm thấy.');
                }
                $scope.products = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
                $scope.countInPage = result.data.Count;
            }, function () {
                console.log('Load productcategory failed.');
            });
        }
        getProducts();

        function deleteProduct(id) {
            $ngBootbox.confirm('Bạn có chắc muốn xóa?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('api/product/delete', config, function () {
                    search();
                    notificationService.displaySuccess('Xóa thành công.');
                }, function () {
                    notificationService.displayError('Xóa không thành công.');
                })
            });
        }

        $scope.isAll = false;
        function selectAll() {
            if ($scope.isAll === false) {
                angular.forEach($scope.products, function (item) {
                    item.checked = true;
                })
                $scope.isAll = true;
            }
            else {
                angular.forEach($scope.products, function (item) {
                    item.checked = false;
                })
                $scope.isAll = false;
            }
        }

        //lắng nghe sự thay đổi từ $scope.products
        $scope.$watch("products", function (n,o) {
            var checked = $filter('filter')(n, { checked: true });
            if (checked.length) {
                $scope.selected = checked;
                $('#btnDelete').removeAttr('disabled')
            } else {
                $('#btnDelete').attr('disabled', 'disabled');
            }
        },true)

        function deleteMultiple() {
            var listID = [];
            angular.forEach($scope.selected, function (item) {
                listID.push(item.ID);
            });

            var config = {
                params: {
                    checkedProduct:JSON.stringify(listID)
                }
            }
            apiService.del('api/product/deletemulti', config, function (result) {
                notificationService.displaySuccess('Xóa thành công ' + result.data + ' bản ghi');
                search();
            }, function (error) {
                notificationService.displayWarning('Xóa không thành công.')
            });
        }
    }
})(angular.module('bungbungshop.products'));