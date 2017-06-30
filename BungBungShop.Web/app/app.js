/// <reference path="D:\ASPNET\MyProject\BungBungShop\BungBungShop.Web\Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('bungbungshop',
        ['bungbungshop.products',
         'bungbungshop.product_categories',
         'bungbungshop.application_groups',
         'bungbungshop.application_roles',
         'bungbungshop.application_users',
         'bungbungshop.common'])
        .config(config)
        .config(configAuthentication);

    config.$inject = ['$stateProvider', '$urlRouterProvider', '$qProvider', '$locationProvider'];

    //configAuthentication.$inject = ['$httpProvider'];

    function config($stateProvider, $urlRouterProvider, $qProvider, $locationProvider) {
        //cách cấu hình routing cho bungbungshop
        $stateProvider
            .state('base', {
                url: '',
                templateUrl: '/app/shared/view/baseView.html',
                abstract: true
            })
            .state('login', {
                url: '/login',
                templateUrl: "/app/components/login/loginView.html",
                controller: "loginController"
            })
            .state('home', {
                url: "/home",
                parent: 'base',
                templateUrl: "/app/components/home/homeView.html",
                controller: "homeController"
            });
        $urlRouterProvider.otherwise('/login');
        $qProvider.errorOnUnhandledRejections(false);
        $locationProvider.html5Mode(true);
    }
    function configAuthentication($httpProvider) {
        $httpProvider.interceptors.push(function ($q, $location) {
            return {
                request: function (config) {

                    return config;
                },
                requestError: function (rejection) {

                    return $q.reject(rejection);
                },
                response: function (response) {
                    if (response.status == '401') {
                        $location.path('/login');
                    }
                    //the same response/modified/or a new one need to be returned.
                    return response;
                },
                responseError: function (rejection) {

                    if (rejection.status == '401') {
                        $location.path('/login');
                    }
                    return $q.reject(rejection);
                }
            };
        });
    }
})();