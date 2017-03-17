/// <reference path="D:\ASPNET\MyProject\BungBungShop\BungBungShop.Web\Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('bungbungshop.products', ['bungbungshop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        //cách cấu hình routing cho bungbungshop
        $stateProvider.state('products', {
            url: "/products",
            templateUrl: "/app/components/products/productListView.html",
            controller: "productListController"
        }).state('product_add', {
            url: "/product_add",
            templateUrl: "/app/components/products/productAddView.html",
            controller: "productAddController"
        })
    }
})();