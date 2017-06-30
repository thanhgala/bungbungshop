/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('bungbungshop.application_groups', ['bungbungshop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {

        $stateProvider
            .state('application_groups', {
                url: "/application_groups",
                parent: 'base',
                templateUrl: "/app/components/application_groups/applicationGroupsListView.html",
                controller: "applicationGroupsListController"
            })
            .state('add_application_group', {
                url: "/add_application_group",
                parent: 'base',
                templateUrl: "/app/components/application_groups/applicationGroupsAddView.html",
                controller: "applicationGroupsAddController"
            })
            .state('edit_application_group', {
                //cấu hình state khi lấy tham số từ url
                url: "/edit_application_group/:id",
                parent: 'base',
                templateUrl: "/app/components/application_groups/applicationGroupsEditView.html",
                controller: "applicationGroupsEditController"
            })
    }
})();