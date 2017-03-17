/// <reference path="D:\ASPNET\MyProject\BungBungShop\BungBungShop.Web\Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('bungbungshop', ['bungbungshop.products', 'bungbungshop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        //cách cấu hình routing cho bungbungshop
        $stateProvider.state('home', {
            url: "/admin",
            templateUrl: "/app/components/home/homeView.html",
            controller: "homeController"
        });
        $urlRouterProvider.otherwise('/admin')
    }
})();