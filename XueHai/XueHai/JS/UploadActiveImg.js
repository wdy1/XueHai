var imageWidth = 50;
var imageHeiht = 50;

$(function () {
    $('#uploadify').uploadify({
        'uploader': '/JS/Webupload/uploadify.swf',
        'script': '/LoveShowPet/UploadActiveImg',
        'cancelImg': '/JS/Webupload/cancel.png',
        'folder': '/Images/ActiveImg',
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

});
