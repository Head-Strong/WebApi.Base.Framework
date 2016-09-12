//var Customers = (function () {

//    // 'http://localhost:50950/api/customer'

//    function getCustomers(url) {
//        $.ajax({
//            url: url,
//            type: "GET",
//            dataType: "json",
//            success: function (data) {

//                alert(data.length);

//                return data;
//            },
//            error: function (data) {
//                console.log("Error occured in http://localhost:50950/api/customer" + data.length);
//            }
//        });
//    }

//    return {
//        GetCustomers: function (url) {
//            return getCustomers(url);
//        },
//        BindCustomers: function (url) {
//            return getCustomers(url);
//        }
//    };
//})();

var app = angular.module('Myapp', []);
app.controller("Customers", function ($scope, $http) {
    var windowsServiceUrl = "http://localhost:8090/api/customer";
    var webAppUrl = "http://localhost:50950/api/customer";

    $http.get(windowsServiceUrl).
    success(function (data, status, headers, config) {
        $scope.items = data;
    }).
    error(function (data, status, headers, config) {
        // log error
    });
});

