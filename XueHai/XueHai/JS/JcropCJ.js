var uploader = WebUploader.create({
    swf: '@Url.Content("~/JS/Webupload/Uploader.swf")',
    server: '@Url.Action("UploadImage", "UserInfo")',
    fileVal: 'imgFile',
    formData: { resizeWidth: 300, resizeHeight: 300 },
    pick: '#btnBrowserPic', // 选择图片按钮
    accept: {
        title: 'Images',
        extensions: 'gif,jpg,jpeg,bmp,png',
        mimeTypes: 'image/.gif,.jpg,.jpeg,.bmp,.png'
    },
    auto: true, // 自动上传
    multiple: false, // 不允许多个文件同时上传
    fileNumLimit: 1 // 当前队列数
});

//开始上传
uploader.on("uploadStart", function () {
                
});

//上传成功
uploader.on('uploadSuccess', function (file, response) {

　　//根据自己返回的结果具体操作
　　if (response.Status) {
           $(".div-origin").html('<img id="imgOrigin" style="max-width:300px;max-height:300px;" />');
           var base64Data = "data:image/bmp;base64," + response.Data;

　　　　　　// 配置 jcrop
           $("#imgOrigin").attr("src", base64Data).Jcrop({
                   onChange: setCoordsAndImgSize,
                   onSelect: setCoordsAndImgSize,
                   aspectRatio: 1,
                   setSelect: [50, 50, 150, 150]
            });

            $("#imgCropped").attr("src", base64Data).css({ width: $(".jcrop-holder").width() + "px", height: $(".jcrop-holder").height() + "px" });
            $("#imgData").val(response.Data);
  }
}); 

// 上传失败 
uploader.on("uploadError", function (file) { 
   alert("图片未加载成功！");
}); 

// 错误 
uploader.on("error", function () { 
　　alert("一次只能上传一张图片（不是有效的图片文件）！"); 
}); 

// 上传完成 
uploader.on("uploadComplete", function () { 
  uploader.reset(); // 重置当前队列 
}); 

$("#btn_save").on("click", function () { 
　　$("form_headportrait").submit(); 
}); 
$("form_headportrait").ajaxForm({
　　dataType: 'json',
　　success: function (data) { 

　　　　// 成功后，执行其他操作 

 　　}
 });

// 纪录裁剪的位置
function setCoordsAndImgSize(e) {
   var imgX = e.x, imgY = e.y, imgW = e.w, imgH = e.h;
   $("#imgX").val(imgX);
   $("#imgY").val(imgY);
   $("#imgW").val(imgW);
   $("#imgH").val(imgH);

  if (parseInt(e.w) > 0) {
      var rx = 100 / imgW;
      var ry = 100 / imgH;

      $('#imgCropped').css({
         width: Math.round(rx * $(".jcrop-holder").width()) + 'px',
         height: Math.round(ry * $(".jcrop-holder").height()) + 'px',
         marginLeft: '-' + Math.round(rx * imgX) + 'px',
         marginTop: '-' + Math.round(ry * imgY) + 'px'
     }).show();
  }

}