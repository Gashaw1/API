/// <reference path="angular.js" />
var apps = angular.module("apps", []);

apps.controller("myController", function ($scope, $http) {

    $http.get('http://localhost:50309/Api/Record')
    .then(function (response) {
        $scope.Record = response.data.records;
    });
});



