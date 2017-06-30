(function (app) {
    app.controller('productAddController', productAddController);

    productAddController.$inject = ['$scope', 'apiService', '$state', 'commonService', 'notificationService'];

    function productAddController($scope, apiService, $state, commonService, notificationService) {
        $scope.productcategories = [];

        $scope.AddProduct = AddProduct;

        //cấu hình ckeditor
        $scope.ckeditorOptions = {
            language: 'vi',
            height:'200px'
        }

        $scope.product = {
            CreatedDate: new Date(),
            Status:true
        }

        $scope.GetSeoTitle = GetSeoTitle;

        $scope.moreImages = [];

        function GetSeoTitle() {
            $scope.product.Alias = commonService.getSeoTitle($scope.product.Name);
        }

        function loadProductCategory() {

            apiService.get('api/productcategory/getallparent', null, function (result) {
                $scope.productcategories = result.data;
            }, function (error) {
                console.log('cannot get list parent');
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
        loadProductCategory();

        function AddProduct() {
            $scope.product.MoreImages = JSON.stringify($scope.moreImages);
            apiService.post('api/product/create', $scope.product, function (result) {
                notificationService.displaySuccess(result.data.Name + ' đã được thêm mới');
                $state.transitionTo('products')
            }, function (error) {
                notificationService.displayError('Không thêm được bản ghi.');
            })
        }

        $scope.ChooseMoreImages = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                //sử dụng apply thực hiện ngay mà không bị delay
                $scope.$apply(function () {
                    $scope.moreImages.push(fileUrl);
                })
            }
            finder.popup();
        }
    }
})(angular.module('bungbungshop.products'));