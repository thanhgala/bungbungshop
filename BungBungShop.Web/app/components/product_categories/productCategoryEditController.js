(function (app) {
    app.controller('productCategoryEditController', productCategoryEditController)

    productCategoryEditController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams','commonService'];
    
    function productCategoryEditController(apiService, $scope, notificationService, $state, $stateParams, commonService) {
        $scope.productCategory = {
            CreatedDate: new Date(),
            Status: true
        }

        $scope.parentCategories = [];

        $scope.UpdateProductCategory = UpdateProductCategory;

        $scope.GetSeoTitle = GetSeoTitle;

        function GetSeoTitle() {
            $scope.productCategory.Alias = commonService.getSeoTitle($scope.productCategory.Name);
        }
        //để lấy giá trị trên url ta dùng $stateParams
        function loadProductCategoryDetail() {
            apiService.get('api/productcategory/getbyid/' + $stateParams.id, null,function (result) {
                $scope.productCategory = result.data
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        function UpdateProductCategory() {
            apiService.put('api/productcategory/update', $scope.productCategory, function (result) {
                notificationService.displaySuccess(result.data.Name + ' đã được chỉnh sữa');
                $state.go('product_categories')
            }, function (error) {
                notificationService.displayError('Không thể chỉnh sữa bản ghi.')
            })
        }

        function loadParentCategories() {
            apiService.get('api/productcategory/getallparent', null, function (result) {
                $scope.parentCategories = result.data;
            }, function () {
                console.log('Cannot get list parent.');
            })
        }

        loadParentCategories();
        loadProductCategoryDetail();
    }
})(angular.module('bungbungshop.product_categories'));