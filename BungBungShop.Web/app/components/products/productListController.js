(function (app) {
    app.controller('productListController', productListController);

    productListController.$inject = ['$scope', 'apiService', 'notificationService'];

    function productListController($scope, apiService, notificationService) {
        $scope.products = [];

        $scope.keyword = '';

        $scope.getProduct = getProduct;

        $scope

        function getProduct(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize:2
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
        getProduct();
    }
})(angular.module('bungbungshop.products'));