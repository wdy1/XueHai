$(function(){
    var slider4 = function () {
        $(".item").each(function () {
            var index = $(".item").index($(this)) + 1;
            var indexclass = "item-pic" + index;
            $(this).addClass(indexclass);
        })
        var $recommend = $('#recommend2');
        var $carousel_item = $recommend.find('.carousel-slider').find('.item');
        var $carousel_prev = $recommend.find('.slider-prev');
        var $carousel_next = $recommend.find('.slider-next');
        var carouselArr = [];
        $(".item").each(function () {
            var index = $(".item").index($(this)) + 1;
            var indexclass = "item-pic" + index;
            carouselArr.push(indexclass);
        })
        //var carouselArr = ['item-pic1', 'item-pic2', 'item-pic3', 'item-pic4', 'item-pic5', 'item-pic6'];
        var b_stop = true;

        $carousel_prev.click(function () {
            if (b_stop) {
                b_stop = false;

                carouselArr.push(carouselArr.shift());

                $carousel_item.each(function (i) {
                    $carousel_item.removeClass(carouselArr[i]);
                    $(this).addClass(carouselArr[i]);

                    setTimeout(function () {
                        b_stop = true;
                    }, 400);
                });
            }

            return false;
        });

        $carousel_next.click(function () {
            if (b_stop) {
                b_stop = false;

                carouselArr.unshift(carouselArr.pop());

                $carousel_item.each(function (i) {
                    $carousel_item.removeClass(carouselArr[i]);
                    $(this).addClass(carouselArr[i]);

                    setTimeout(function () {
                        b_stop = true;
                    }, 400);
                });
            }

            return false;
        })
    }
    var slider1 = function () {
        $(".item").addClass("item-pic3")
        $(".leftmask").css("display", "none");
        $(".rightmask").css("display", "none");
        $(".main-operate").css("display", "none");
    }
    var slider3 = function () {
        $(".item").each(function () {
            var index = $(".item").index($(this)) + 2;
            console.log(index);
            var indexclass = "item-pic" + index;
            $(this).addClass(indexclass);
        })
        var $recommend = $('#recommend2');
        var $carousel_item = $recommend.find('.carousel-slider').find('.item');
        var $carousel_prev = $recommend.find('.slider-prev');
        var $carousel_next = $recommend.find('.slider-next');
        var carouselArr = [];
        $(".item").each(function () {
            var index = $(".item").index($(this)) + 2;
            var indexclass = "item-pic" + index;
            carouselArr.push(indexclass);
        })
        //var carouselArr = ['item-pic1', 'item-pic2', 'item-pic3', 'item-pic4', 'item-pic5', 'item-pic6'];
        var b_stop = true;

        $carousel_prev.click(function () {
            if (b_stop) {
                b_stop = false;

                carouselArr.push(carouselArr.shift());

                $carousel_item.each(function (i) {
                    $carousel_item.removeClass(carouselArr[i]);
                    $(this).addClass(carouselArr[i]);

                    setTimeout(function () {
                        b_stop = true;
                    }, 400);
                });
            }

            return false;
        });

        $carousel_next.click(function () {
            if (b_stop) {
                b_stop = false;

                carouselArr.unshift(carouselArr.pop());

                $carousel_item.each(function (i) {
                    $carousel_item.removeClass(carouselArr[i]);
                    $(this).addClass(carouselArr[i]);

                    setTimeout(function () {
                        b_stop = true;
                    }, 400);
                });
            }

            return false;
        })
    }
    var slider2 = function () {
        $(".item").eq(0).addClass("item-pic3");
        $(".item").eq(1).addClass("item-pic0");
        var $recommend = $('#recommend2');
        var $carousel_item = $recommend.find('.carousel-slider').find('.item');
        var $carousel_prev = $recommend.find('.slider-prev');
        var $carousel_next = $recommend.find('.slider-next');
        var carouselArr = [];
        carouselArr.push("item-pic3");
        carouselArr.push("item-pic0");
        //var carouselArr = ['item-pic1', 'item-pic2', 'item-pic3', 'item-pic4', 'item-pic5', 'item-pic6'];
        var b_stop = true;

        $carousel_prev.click(function () {
            if (b_stop) {
                b_stop = false;

                carouselArr.push(carouselArr.shift());

                $carousel_item.each(function (i) {
                    $carousel_item.removeClass(carouselArr[i]);
                    $(this).addClass(carouselArr[i]);

                    setTimeout(function () {
                        b_stop = true;
                    }, 400);
                });
            }

            return false;
        });

        $carousel_next.click(function () {
            if (b_stop) {
                b_stop = false;

                carouselArr.unshift(carouselArr.pop());

                $carousel_item.each(function (i) {
                    $carousel_item.removeClass(carouselArr[i]);
                    $(this).addClass(carouselArr[i]);

                    setTimeout(function () {
                        b_stop = true;
                    }, 400);
                });
            }

            return false;
        })
    }
    $(".item").each(function () {
        var src = $(this).find("img").attr('src')
        if (src == "") {
            $(this).remove();
        }
    })
    var itemNum = $(".item").length;
    if (itemNum == 1) {
        slider1();
    }
    if (itemNum == 3) {
        slider3();
    }
    if (itemNum == 2) {
        slider2();
    }
    if (itemNum > 3) {
        slider4();
    }
})