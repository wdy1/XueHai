var LuoKiApp = angular.module("LuoKiApp", ["ngRoute"]);
//angular.module("LuoKiApp", []).factory('getPetList', function ($http) {
//    var GetPetList=function(shape,hair,fuc,frendly,siy,charact){
//        $http({
//        method: 'POST',
//        url: '/PetCategory/DogIndex',
//        responseType: 'json',
//        data: { shape: shape, hair: hair, fuc: fuc, frendly: frendly, siy: siy, charact: charact },
//        }).success(function (data, status, headers, config) {
//            return data;
//            //console.log(data);
//        }).error(function (data, status, headers, config) {
//            console.log("status=" + status);
//            deferred.reject(data);
//            return data;
//        });
//    }
//    return{
//        events: function (shape, hair, fuc, frendly, siy, charact) {
//            return GetPetList(shape, hair, fuc, frendly, siy, charact);
//        }
//    }
//})
angular.module("LuoKiApp").controller("DogIndexCtr1", function ($scope, $http)
{
    $scope.Shapes = [{ name: '不限', id: '0' }, { name: '小型', id: '1' }, { name: '中型', id: '2' }, { name: '大型', id: '3' }];
    $scope.Hairs = [{ name: '不限', id: '0' }, { name: '短毛', id: '1' }, { name: '中长毛', id: '2' }, { name: '长毛', id: '3' }];
    $scope.Fucs = [{ name: '不限', id: '0' }, { name: '伴侣犬', id: '1' }, { name: '牧羊犬', id: '2' }, { name: '守卫犬', id: '3' }, { name: '看家犬', id: '4' }, { name: '雪橇犬', id: '5' }, { name: '玩赏犬', id: '6' }, { name: '搜救犬', id: '7' }, { name: '导盲犬', id: '8' }];
    $scope.Frendlys = [{ name: '不限', id: '0' }, { name: '温顺', id: '1' }, { name: '一般', id: '2' }, { name: '容易暴躁', id: '3' }, { name: '暴躁', id: '4' }, { name: '烈犬', id: '5' }];
    $scope.SiYs = [{ name: '不限', id: '0' }, { name: '容易', id: '1' }, { name: '一般', id: '2' }, { name: '难', id: '3' }];
    $scope.Characts = [{ name: '不限', id: '0' }, { name: '不爱叫', id: '1' }, { name: '无体味', id: '2' }, { name: '少掉毛', id: '3' }, { name: '粘人', id: '4' }, { name: '耐热', id: '5' }, { name: '耐寒', id: '6' }, { name: '爱护家', id: '7' }];
    $scope.shapeA = 0; $scope.hairA = 0; $scope.fucA = 0; $scope.frendlyA = 0; $scope.siyA = 0; $scope.charactA = 0;
    $scope.PetLists = [];
    $scope.pageSize = 5;
    $scope.pages = 0;
    $scope.selpage = 1;
    $scope.privpage = 0;
    $scope.nextpage = 2;
    $scope.haspriv = false;
    $scope.hasnext = false;
    //$scope.Petpost = function () {
        $http({
            method: 'POST',
            url: '/PetCategory/DogIndex',
            responseType: 'json',
            data: { shape:$scope.shapeA,hair:$scope.hairA,fuc:$scope.fucA,frendly:$scope.frendlyA,siy:$scope.siyA,charact:$scope.charactA },
        }).success(function (data, status, headers, config) {
            $scope.PetNum = eval(data).length;
            $scope.PetLists = data;
            $scope.PetPageLists = $scope.PetLists.slice(0, $scope.pageSize);
            $scope.pages = Math.ceil($scope.PetLists.length / $scope.pageSize);
            console.log(data);
        }).error(function (data, status, headers, config) {
            console.log("status=" + status);
            deferred.reject(data);
        });
    $scope.shapeChange = function (shape) {
        $scope.shapeA = shape.id;
        $http({
            method: 'POST',
            url: '/PetCategory/DogIndex',
            responseType: 'json',
            data: { shape: $scope.shapeA, hair: $scope.hairA, fuc: $scope.fucA, frendly: $scope.frendlyA, siy: $scope.siyA, charact: $scope.charactA },
        }).success(function (data, status, headers, config) {
            $scope.PetNum = eval(data).length;
            $scope.PetLists = data;
            $scope.PetPageLists = $scope.PetLists.slice(0, $scope.pageSize);
            $scope.pages = Math.ceil($scope.PetLists.length / $scope.pageSize);
            $scope.selpage = 1;
            $scope.privpage = 0;
            $scope.nextpage = 2;
            $scope.haspriv = false;
            $scope.hasnext = false;
            console.log(data);
        }).error(function (data, status, headers, config) {
            console.log("status=" + status);
            deferred.reject(data);
        });
        //$scope.PetLists=getPetList.events($scope.shapeA,$scope.hairA,$scope.fucA,$scope.frendlyA,$scope.siyA,$scope.charactA)
    }
    $scope.hairChange = function (hair) {
        $scope.hairA = hair.id;
        $http({
            method: 'POST',
            url: '/PetCategory/DogIndex',
            responseType: 'json',
            data: { shape: $scope.shapeA, hair: $scope.hairA, fuc: $scope.fucA, frendly: $scope.frendlyA, siy: $scope.siyA, charact: $scope.charactA },
        }).success(function (data, status, headers, config) {
            $scope.PetNum = eval(data).length;
            $scope.PetLists = data;
            $scope.PetPageLists = $scope.PetLists.slice(0, $scope.pageSize);
            $scope.pages = Math.ceil($scope.PetLists.length / $scope.pageSize);
            $scope.selpage = 1;
            $scope.privpage = 0;
            $scope.nextpage = 2;
            $scope.haspriv = false;
            $scope.hasnext = false;
            console.log(data);
        }).error(function (data, status, headers, config) {
            console.log("status=" + status);
            deferred.reject(data);
        });
        //$scope.PetLists = getPetList.events($scope.shapeA, $scope.hairA, $scope.fucA, $scope.frendlyA, $scope.siyA, $scope.charactA)
    }
    $scope.fucChange = function (fuc) {
        $scope.fucA = fuc.id;
        $http({
            method: 'POST',
            url: '/PetCategory/DogIndex',
            responseType: 'json',
            data: { shape: $scope.shapeA, hair: $scope.hairA, fuc: $scope.fucA, frendly: $scope.frendlyA, siy: $scope.siyA, charact: $scope.charactA },
        }).success(function (data, status, headers, config) {
            $scope.PetNum = eval(data).length;
            $scope.PetLists = data;
            $scope.PetPageLists = $scope.PetLists.slice(0, $scope.pageSize);
            $scope.pages = Math.ceil($scope.PetLists.length / $scope.pageSize);
            $scope.selpage = 1;
            $scope.privpage = 0;
            $scope.nextpage = 2;
            $scope.haspriv = false;
            $scope.hasnext = false;
            console.log(data);
        }).error(function (data, status, headers, config) {
            console.log("status=" + status);
            deferred.reject(data);
        });
        //$scope.PetLists = getPetList.events($scope.shapeA, $scope.hairA, $scope.fucA, $scope.frendlyA, $scope.siyA, $scope.charactA)
    }
    $scope.frendlyChange = function (frendly) {
        $scope.frendlyA = frendly.id;
        $http({
            method: 'POST',
            url: '/PetCategory/DogIndex',
            responseType: 'json',
            data: { shape: $scope.shapeA, hair: $scope.hairA, fuc: $scope.fucA, frendly: $scope.frendlyA, siy: $scope.siyA, charact: $scope.charactA },
        }).success(function (data, status, headers, config) {
            $scope.PetNum = eval(data).length;
            $scope.PetLists = data;
            $scope.PetPageLists = $scope.PetLists.slice(0, $scope.pageSize);
            $scope.pages = Math.ceil($scope.PetLists.length / $scope.pageSize);
            $scope.selpage = 1;
            $scope.privpage = 0;
            $scope.nextpage = 2;
            $scope.haspriv = false;
            $scope.hasnext = false;
            console.log(data);
        }).error(function (data, status, headers, config) {
            console.log("status=" + status);
            deferred.reject(data);
        });
        //$scope.PetLists = getPetList.events($scope.shapeA, $scope.hairA, $scope.fucA, $scope.frendlyA, $scope.siyA, $scope.charactA)
    }
    $scope.siyChange = function (siy) {
        $scope.siyA = siy.id;
        $http({
            method: 'POST',
            url: '/PetCategory/DogIndex',
            responseType: 'json',
            data: { shape: $scope.shapeA, hair: $scope.hairA, fuc: $scope.fucA, frendly: $scope.frendlyA, siy: $scope.siyA, charact: $scope.charactA },
        }).success(function (data, status, headers, config) {
            $scope.PetNum = eval(data).length;
            $scope.PetLists = data;
            $scope.PetPageLists = $scope.PetLists.slice(0, $scope.pageSize);
            $scope.pages = Math.ceil($scope.PetLists.length / $scope.pageSize);
            $scope.selpage = 1;
            $scope.privpage = 0;
            $scope.nextpage = 2;
            $scope.haspriv = false;
            $scope.hasnext = false;
            console.log(data);
        }).error(function (data, status, headers, config) {
            console.log("status=" + status);
            deferred.reject(data);
        });
        //$scope.PetLists = getPetList.events($scope.shapeA, $scope.hairA, $scope.fucA, $scope.frendlyA, $scope.siyA, $scope.charactA)
    }
    $scope.charactChange = function (charact) {
        $scope.charactA = charact.id;
        $http({
            method: 'POST',
            url: '/PetCategory/DogIndex',
            responseType: 'json',
            data: { shape: $scope.shapeA, hair: $scope.hairA, fuc: $scope.fucA, frendly: $scope.frendlyA, siy: $scope.siyA, charact: $scope.charactA },
        }).success(function (data, status, headers, config) {
            $scope.PetNum = eval(data).length;
            $scope.PetLists = data;
            $scope.PetPageLists = $scope.PetLists.slice(0, $scope.pageSize);
            $scope.pages = Math.ceil($scope.PetLists.length / $scope.pageSize);
            $scope.selpage = 1;
            $scope.privpage = 0;
            $scope.nextpage = 2;
            $scope.haspriv = false;
            $scope.hasnext = false;
            console.log(data);
        }).error(function (data, status, headers, config) {
            console.log("status=" + status);
            deferred.reject(data);
        });
        //$scope.PetLists = getPetList.events($scope.shapeA, $scope.hairA, $scope.fucA, $scope.frendlyA, $scope.siyA, $scope.charactA)
    }
    //$scope.page = 5;
    //$scope.selpage = 1;
    //$scope.privpage = 0;
    //$scope.nextpage = 2;
    //$scope.haspriv = false;
    //$scope.hasnext = false;
    $scope.setData = function () {
        $scope.PetPageLists = $scope.PetLists.slice(($scope.pageSize * ($scope.selpage - 1)), ($scope.selpage * $scope.pageSize));//通过当前页数筛选出表格当前显示数据
    }
    $scope.selectpage=function(page)
    {
        $scope.privpage = page - 1;
        $scope.nextpage = page + 1;
        $scope.selpage = page;
        if(page>1)
        {
            $scope.haspriv = true;
            console.log("1");
        }
        else {
            $scope.haspriv = false;
        }
        if(page==$scope.pages)
        {
            $scope.hasnext = true;
            console.log("2");
        }
        else
        {
            $scope.hasnext = false;
            console.log("2");
        }
    }
    $scope.Next=function()
    {
        if ($scope.selpage == $scope.pages)
        {
            return;
        }
        $scope.selectpage($scope.selpage + 1);
        console.log("wei结束");
        $scope.setData();
    }
    $scope.Priv = function () {
        $scope.selectpage($scope.selpage - 1);
        $scope.setData();
    }
})