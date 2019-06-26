var imageWidth = 50;
var imageHeiht = 50;

$(function () {
    $('#uploadify').uploadify({
        'uploader': '/JS/Webupload/uploadify.swf',
        'script': '/UserInfo/UploadImg',
        'cancelImg': '/JS/Webupload/cancel.png',
        'folder': '/Images/UserImg',
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

                $("#bgDiv img").remove();                      //移除截图区里image标签
                $("#btnSave").show();                          //保存按钮显示                    
                var result = response.split('$');              //得返回参数

                var maxVal = 0;
                if (result[1] > result[2]) {
                    maxVal = result[2];
                }
                else {
                    maxVal = result[1];
                }
                $("#maxVal").val(100);                     //设置截图区大小

                $("#hidImageUrl").val(result[0]);             //上传路径存入隐藏域


                $("#imgCut").attr("src", result[0]);
                //ShowImg(result[0],result[1],result[2]);       //在截图区显示
                var jcrop_api, boundx, boundy;
                var $preview = $('.preview-pane');
                var $pcnt = $('.preview-pane .preview-container');
                var $pimg = $('.preview-pane .preview-container img');
                var xsize = $pcnt.width();
                var ysize = $pcnt.height();

                $("#target").attr("src", result[0]).Jcrop(
                                                    {
                                                        setSelect: [0, 0, 200, 200],
                                                        minSize: [200, 200],
                                                        aspectRatio: 1,
                                                        allowSelect: false,
                                                        onChange: updatePreview,
                                                        onSelect: updatePreview,
                                                    }, function () {
                                                        var bounds = this.getBounds();
                                                        boundx = bounds[0];
                                                        boundy = bounds[1];
                                                        jcrop_api = this;
                                                    });


                $("#uploadify").uploadifySettings('scriptData', { 'LastImgUrl': $('#hidImageUrl').val() }); 	  //更新参数

                function setCoords(c) {
                    $("#x").val(c.x);
                    $("#y").val(c.y);
                    $("#maxVal").val(c.w);
                }

                function updatePreview(c) {
                    if (parseInt(c.w) > 0) {
                        var rx = xsize / c.w;
                        var ry = ysize / c.h;
                        setCoords(c);
                        $pimg.css({
                            width: Math.round(rx * boundx) + 'px',
                            height: Math.round(ry * boundy) + 'px',
                            marginLeft: '-' + Math.round(rx * c.x) + 'px',
                            marginTop: '-' + Math.round(ry * c.y) + 'px'
                        });
                    }
                };
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



function ShowImg(imagePath, imgWidth, imgHeight) {
    var imgPath = imagePath != "" ? imagePath : "images/ef_pic.jpg";
    var ic = new ImgCropper("bgDiv", "dragDiv", imgPath, imgWidth, imgHeight, null);
}