var LuoKiApp = angular.module("LoveShowApp", ["ngRoute"]);
angular.module("LoveShowAPP").controller("HotPhotos", function ($scope, $http)
{
    $http({
        method: 'POST',
        url: '/PetCategory/DogIndex',
        responseType: 'json',
    }).success(function (data, status, headers, config) {
        $scope.HotPhotos = data;
    }).error(function (data, status, headers, config) {
        console.log("status=" + status);
        deferred.reject(data);
    });
})