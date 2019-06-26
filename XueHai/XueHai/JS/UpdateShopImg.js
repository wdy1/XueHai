var imageWidth = 50;
var imageHeiht = 50;

$(function () {
    $('#uploadify').uploadify({
        'uploader': '/JS/Webupload/uploadify.swf',
        'script': '/UserInfo/UploadImg',
        'cancelImg': '/JS/Webupload/cancel.png',
        'folder': '/Images/ServiceShopImg',
        'queueID': 'fileQueue',
        'auto': true,
        'multi': false,
        'method': 'get',
        'fileExt': '*.jpg;*.png',
        'fileDesc': '请选择jpg , png文件...',
        'scriptData': null,
        'sizeLimit': 2097152,
        'onComplete': function (event, queueID, fileObj, response, data) {
            if (response.indexOf('Images') != -1) {
                $(".ShopEditImg #Content").addClass("active");
                $(".ShopEditImg #Content2").addClass("active");
                var result = response.split('$');              //得返回参数

                var maxVal = 0;
                if (result[1] > result[2]) {
                    maxVal = result[2];
                }
                else {
                    maxVal = result[1];
                }
                $("#hidImageUrl").val(result[0]);             //上传路径存入隐藏域
                $("#target").attr("src", result[0]);

            }
            else {
                alert(response);
            }
        }
        
        
    });

    $("#btnSave").click(function () {
        $.ajax({
            type: "POST",
            url: "/UserInfo/CutImg",
            data: { imgUrl: $('#hidImageUrl').val(), pointX: $("#x").val(), pointY: $("#y").val(), maxVal: $("#maxVal").val() },
            success: function (msg) {
                if (msg.indexOf('User') != -1) {
                    $("#imgCut").attr("src", msg);
                    alert("保存成功!");
                }
                else {
                    alert("error");
                }
            },
            error: function (xhr, msg, e) {
                alert("error");
            }
        });
    });
});



//function ShowImg(imagePath, imgWidth, imgHeight) {
//    var imgPath = imagePath != "" ? imagePath : "images/ef_pic.jpg";
//    var ic = new ImgCropper("bgDiv", "dragDiv", imgPath, imgWidth, imgHeight, null);
//}