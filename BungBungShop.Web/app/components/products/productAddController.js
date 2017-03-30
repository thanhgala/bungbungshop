(function (app) {
    app.controller('productAddController', productAddController);

    productAddController.$inject = ['$scope','apiService'];

    function productAddController($scope, apiService) {
        $scope.productcategories = [];

        $scope.ckeditorOptions = {
            language: 'vi',
            height:'200px'
        }

        $scope.product = {
            CreatedDate: new Date(),
            Status:true
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
                $scope.product.Image = fileUrl;
            }
            finder.popup();
        }
        loadProductCategory();
    }
})(angular.module('bungbungshop.products'));