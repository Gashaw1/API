///<reference path="angular.js"/>
var app = angular.module("myApp", ["ngRoute"])
app.config(function ($routeProvider) {
    $routeProvider
    .when('/Home', {
        templateUrl: "Templates/Home.html",
        controller: "homeController"
    })
    .when("/Department", {
        templateUrl: "Templates/Department.html",
        controller: "departmentController"
    })
    .when("/Employee", {
        templateUrl: "Templates/Employee.html",
        controller: "employeeController"
    })
})
.controller("homeController", function ($scope) {
    $scope.message = "Home page";
})
.controller("departmentController", function ($scope, $http) {
    $http.get('http://localhost:50780/api/Department')
    .then(function (response)
    {
        $scope.Department = response.data.departments;

    })

})
.controller("employeeController", function ($scope, $http) {
    $http.get('http://localhost:50780/api/Department')
   .then(function (response) {

       $scope.Department = response.data.departments;

   })
})


