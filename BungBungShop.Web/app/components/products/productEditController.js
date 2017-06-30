(function (app) {
    app.controller('productEditController', productEditController);

    productEditController.$inject = ['$scope', 'apiService', 'notificationService', '$stateParams','commonService','$state'];

    function productEditController($scope, apiService, notificationService, $stateParams, commonService, $state) {

        $scope.product = [];

        $scope.GetSeoTitle = GetSeoTitle;

        $scope.productcategories = [];

        $scope.UpdateProduct = UpdateProduct;

       

        //cấu hình ckeditor
        $scope.ckeditorOptions = {
            language: 'vi',
            height: '200px'
        }

        function loadProductDetail() {
            apiService.get('api/product/getid/' + $stateParams.id, null, function (result) {
                $scope.product = result.data;
                if ($scope.product.MoreImages === null) {
                    $scope.moreImages = [];
                }
                else {
                    $scope.moreImages = JSON.parse($scope.product.MoreImages);
                }
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }
        loadProductDetail();

        function GetSeoTitle() {
            $scope.product.Alias = commonService.getSeoTitle($scope.product.Name);
        }

        function loadProductCategory() {
            apiService.get('api/productcategory/getallparent', null, function (result) {
                $scope.productcategories = result.data
            }, function (error) {
                console.log('cannot get list parent');
            });
        }
        loadProductCategory();

        function UpdateProduct() {
            $scope.product.MoreImages = JSON.stringify($scope.moreImages)
            apiService.put('api/product/update', $scope.product, function (result) {
                notificationService.displaySuccess(result.data.Name + ' đã được chỉnh sửa');
                $state.transitionTo('products')
            }, function (error) {
                notificationService.displayError('Không thể chỉnh sửa bản ghi.');
            })
        }

        $scope.ChooseImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.product.Image = fileUrl;
                })
            }
            finder.popup();
        }

        $scope.ChooseMoreImages = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.moreImages.push(fileUrl);
                })
            }
            finder.popup();
        }

    }
})(angular.module('bungbungshop.products'));