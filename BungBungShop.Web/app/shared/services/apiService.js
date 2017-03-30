﻿/// <reference path="/Assets/admin/libs/angular/angular.js" />
(function (app) {
    app.factory('apiService', apiService);

    apiService.$inject = ['$http', 'notificationService'];

    function apiService($http, notificationService) {
        return {
            get: get,
            post: post,
            put: put,
            del:del
        }

        function post(url, data, success, failure) {
            $http.post(url, data).then(function (result) {
                success(result);
            }, function (error) {
                //Không có quyền authen
                if (error.status === 401) {
                    notificationService.displayError('Authenticate is require.');
                }
                else if (failure != null) {
                    failure(error)
                }
            });
        }

        function get(url, params, success, failure) {
            $http.get(url, params).then(function (result) {
                success(result);
            }, function (error) {
                failure(error);
            });
        }

        function put(url, data, success, failure) {
            $http.put(url, data).then(function (result) {
                success(result)
            }, function (error) {
                if (error.status === 401) {
                    notification.displayError('Authenticate is require');
                }
                else if (failure != null) {
                    failure(error);
                }
            });
        }

        function del(url, data, success, failure) {
            $http.delete(url, data).then(function (result) {
                success(result);
            }, function (error) {
                if (error.status === 401) {
                    notification.displayError('Authenticate is require');
                }
                else if (failure != null) {
                    failure(error)
                }
            });
        }
    }
})(angular.module('bungbungshop.common'));