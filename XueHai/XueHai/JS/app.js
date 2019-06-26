﻿var JuyYouApp=angular.module("JuYouApp", ["ngRoute"]);
JuyYouApp.controller("YueZhanHomeCtr", function ($scope, $http)
{
    $scope.YueZhanHomeData={};
    $http({
        method:'POST',
        //headers: {'Content-type': 'application/json;charset=UTF-8'},
        url:'/admin/query',
        responseType:'json',
        params: {'admin':admin}
    }).success(function (data, status, headers, config)
    {
        $scope.YueZhanHomeData = data;
    }).error(function (data, status, headers, config) {
        console.log("status=" + status);
        deferred.reject(data);//失败，返回错误信息
    });
    $scope.City = $scope.YueZhanHomeData.City;
    $scope.Area = $scope.YueZhanHomeData.Area;
    $scope.YueZhanList = $scope.YueZhanHomeData.YueZhanHomeList;
})

//var app = angular.module("myApp", []);
//app.controller("myCtrl", function ($scope, $http) {
//    $http.get("Service.js").then(function (response) {
//        //数据源
//        $scope.data = response.data.records;
//        //分页总数
//        $scope.pageSize = 5;
//        $scope.pages = Math.ceil($scope.data.length / $scope.pageSize); //分页数
//        $scope.newPages = $scope.pages > 5 ? 5 : $scope.pages;
//        $scope.pageList = [];
//        $scope.selPage = 1;
//        //设置表格数据源(分页)
//        $scope.setData = function () {
//            $scope.items = $scope.data.slice(($scope.pageSize * ($scope.selPage - 1)), ($scope.selPage * $scope.pageSize));//通过当前页数筛选出表格当前显示数据
//        }
//        $scope.items = $scope.data.slice(0, $scope.pageSize);
//        //分页要repeat的数组
//        for (var i = 0; i < $scope.newPages; i++) {
//            $scope.pageList.push(i + 1);
//        }
//        //打印当前选中页索引
//        $scope.selectPage = function (page) {
//            //不能小于1大于最大
//            if (page < 1 || page > $scope.pages) return;
//            //最多显示分页数5
//            if (page > 2) {
//                //因为只显示5个页数，大于2页开始分页转换
//                var newpageList = [];
//                for (var i = (page - 3) ; i < ((page + 2) > $scope.pages ? $scope.pages : (page + 2)) ; i++) {
//                    newpageList.push(i + 1);
//                }
//                $scope.pageList = newpageList;
//            }
//            $scope.selPage = page;
//            $scope.setData();
//            $scope.isActivePage(page);
//            console.log("选择的页：" + page);
//        };
//        //设置当前选中页样式
//        $scope.isActivePage = function (page) {
//            return $scope.selPage == page;
//        };
//        //上一页
//        $scope.Previous = function () {
//            $scope.selectPage($scope.selPage - 1);
//        }
//        //下一页
//        $scope.Next = function () {
//            $scope.selectPage($scope.selPage + 1);
//        };
//    });
//})
