$(function () {

    $(".zhuxiao").click(function () {

        $.ajax({
            url: "/UserInfo/ZhuXiao",
            type: "post",
            data: { a: 1 },
            success: function (data) {
                alert("注销成功");
                location.reload();
                $(".userinfo").unbind("mouseenter").unbind("mouseleave");
                var A = data;
            }
        });
    });
});

//$(function () {
//    $(".submit").click(function () {
//            var search1 = $(".input-search").val();
//            if (search1 == "") {
//                alert("请输入搜索内容");
//            }
//});
//$(function () {
   
//    $(".submit").click(function () {
//        var search1 = $(".input-search").val();
//        if (search1 != "") {
//            $.ajax({
//                url: "/Search/Index",
//                type: "post",
//                async: false,
//                data: { search: search1},//choose_id: 9
//                success: function (data) {
//                    window.location.href = '/Search/Index';
//                    //location.href = "/Search/Index";
//                }
//            });
//        } else {
//            alert("请输入搜索内容");
//        }
//    });
//});