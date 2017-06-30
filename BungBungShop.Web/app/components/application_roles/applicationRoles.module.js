/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('bungbungshop.application_roles', ['bungbungshop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {

        $stateProvider
            .state('application_roles', {
                url: "/application_roles",
                parent: 'base',
                templateUrl: "/app/components/application_roles/applicationRolesListView.html",
                controller: "applicationRolesListController"
            })
            .state('add_application_role', {
                url: "/add_application_role",
                parent: 'base',
                templateUrl: "/app/components/application_roles/applicationRolesAddView.html",
                controller: "applicationRolesAddController"
            })
            .state('edit_application_role', {
                //cấu hình state khi lấy tham số từ url
                url: "/edit_application_role/:id",
                parent: 'base',
                templateUrl: "/app/components/application_roles/applicationRolesEditView.html",
                controller: "applicationRolesEditController"
            })
    }
})();