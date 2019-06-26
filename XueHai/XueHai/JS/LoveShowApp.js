var LuoKiApp = angular.module("LoveShowApp", ["ngRoute"]);
angular.module("LoveShowApp").controller("LoveShowPhotos", function ($scope, $http)
{
    $http({
        method: 'POST',
        url: '/LoveShowPet/HotPhotos',
        responseType: 'json',
    }).success(function (data, status, headers, config) {
        $scope.HotPhotos = data;
    }).error(function (data, status, headers, config) {
        console.log("status=" + status);
        deferred.reject(data);
    });
})