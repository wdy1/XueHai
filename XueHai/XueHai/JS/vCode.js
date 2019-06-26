(function () {
    var randstr = function (length) {
        var key = {

            str: [
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
                'o', 'p', 'q', 'r', 's', 't', 'x', 'u', 'v', 'y', 'z', 'w', 'n',
                '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'
            ],

            randint: function (n, m) {
                var c = m - n + 1;
                var num = Math.random() * c + n;
                return Math.floor(num);
            },

            randStr: function () {
                var _this = this;
                var leng = _this.str.length - 1;
                var randkey = _this.randint(0, leng);
                return _this.str[randkey];
            },

            create: function (len) {
                var _this = this;
                var l = len || 10;
                var str = '';

                for (var i = 0 ; i < l ; i++) {
                    str += _this.randStr();
                }

                return str;
            }

        };

        length = length ? length : 10;

        return key.create(length);
    };//获得一个字符串的函数

    var randint = function (n, m) {
        var c = m - n + 1;
        var num = Math.random() * c + n;
        return Math.floor(num);
    };

    var vCode = function (dom, options) {
        this.codeDoms = [];
        this.lineDoms = [];
        this.initOptions(options);
        this.dom = dom;
        this.init();
        this.addEvent();//为验证码图片添加一个按钮事件 让其没按一次变换一张验证码图片
        this.update();//初始化验证码
        this.mask();
    };

    vCode.prototype.init = function () {
        this.dom.style.position = "relative";
        this.dom.style.overflow = "hidden";
        this.dom.style.cursor = "pointer";
        this.dom.title = "点击更换验证码";
        this.dom.style.background = this.options.bgColor;
        this.w = this.dom.clientWidth;
        this.h = this.dom.clientHeight;
        this.uW = this.w / this.options.len;
    };

    vCode.prototype.mask = function () {
        var dom = document.createElement("div");
        dom.style.cssText = [
            "width: 100%",
            "height: 100%",
            "left: 0",
            "top: 0",
            "position: absolute",
            "cursor: pointer",
            "z-index: 9999999"
        ].join(";");//将数组转化成字符串

        dom.title = "点击更换验证码";

        this.dom.appendChild(dom);
    };//创建一个DIV 加在母对象中

    vCode.prototype.addEvent = function () {
        var _this = this;
        _this.dom.addEventListener("click", function () {
            _this.update.call(_this);
        });
    };//为母对象添加一个点击变换验证码的事件

    vCode.prototype.initOptions = function (options) {

        var f = function () {
            this.len = 4;
            this.fontSizeMin = 20;
            this.fontSizeMax = 48;
            this.colors = [
                "green",
                "red",
                "blue",
                "#53da33",
                "#AA0000",
                "#FFBB00"
            ];
            this.bgColor = "#FFF";//白色背景色
            this.fonts = [
                "Times New Roman",
                "Georgia",
                "Serif",
                "sans-serif",
                "arial",
                "tahoma",
                "Hiragino Sans GB"
            ];
            this.lines = 8;
            this.lineColors = [
                "#888888",
                "#FF7744",
                "#888800",
                "#008888"
            ];

            this.lineHeightMin = 1;
            this.lineHeightMax = 3;
            this.lineWidthMin = 1;
            this.lineWidthMax = 60;
        };

        this.options = new f();

        if (typeof options === "object") {
            for (i in options) {
                this.options[i] = options[i];//将传递的参数替换JS里默认的参数，相当于extend（）方法的效果
            }
        }
    };

    vCode.prototype.update = function () {
        for (var i = 0; i < this.codeDoms.length; i++) {
            this.dom.removeChild(this.codeDoms[i]);
        }
        for (var i = 0; i < this.lineDoms.length; i++) {
            this.dom.removeChild(this.lineDoms[i]);
        }
        this.createCode();
        this.draw();
    };//调用创建验证字符createcod（）方法 和调用绘画draw方法

    vCode.prototype.createCode = function () {//随机产生字符方法
        this.code = randstr(this.options.len);
    };

    vCode.prototype.verify = function (code) {
        return this.code === code;
    };//判断输入的字符与验证码字符进行比较  返回对错值

    vCode.prototype.draw = function () {
        this.codeDoms = [];
        for (var i = 0; i < this.code.length; i++) {
            this.codeDoms.push(this.drawCode(this.code[i], i));
        }

        this.drawLines();
    };

    vCode.prototype.drawCode = function (code, index) {
        var dom = document.createElement("span");

        dom.style.cssText = [
            "font-size:" + randint(this.options.fontSizeMin, this.options.fontSizeMax) + "px",
            "color:" + this.options.colors[randint(0, this.options.colors.length - 1)],
            "position: absolute",
            "left:" + 25 * index + "px",
            "top:" +12 + "px",
            "transform:rotate(" + randint(-30, 30) + "deg)",
            "-ms-transform:rotate(" + randint(-30, 30) + "deg)",
            "-moz-transform:rotate(" + randint(-30, 30) + "deg)",
            "-webkit-transform:rotate(" + randint(-30, 30) + "deg)",
            "-o-transform:rotate(" + randint(-30, 30) + "deg)",
            "font-family:" + this.options.fonts[randint(0, this.options.fonts.length - 1)],
            "font-weight:" + randint(400, 900)
        ].join(";");
        dom.innerHTML = code;
        this.dom.appendChild(dom);

        return dom;
    };

    vCode.prototype.drawLines = function () {
        this.lineDoms = [];
        for (var i = 0; i < this.options.lines; i++) {
            var dom = document.createElement("div");

            dom.style.cssText = [
                "position: absolute",
                "opacity: " + randint(3, 8) / 10,
                "width:" + randint(this.options.lineWidthMin, this.options.lineWidthMax) + "px",
                "height:" + randint(this.options.lineHeightMin, this.options.lineHeightMax) + "px",
                "background: " + this.options.lineColors[randint(0, this.options.lineColors.length - 1)],
                "left:" + randint(0, this.w - 20) + "px",
                "top:" + randint(0, this.h) + "px",
                "transform:rotate(" + randint(-30, 30) + "deg)",
                "-ms-transform:rotate(" + randint(-30, 30) + "deg)",
                "-moz-transform:rotate(" + randint(-30, 30) + "deg)",
                "-webkit-transform:rotate(" + randint(-30, 30) + "deg)",
                "-o-transform:rotate(" + randint(-30, 30) + "deg)",
                "font-family:" + this.options.fonts[randint(0, this.options.fonts.length - 1)],
                "font-weight:" + randint(400, 900)
            ].join(";");
            this.dom.appendChild(dom);

            this.lineDoms.push(dom);
        }
    };

    this.vCode = vCode;

}).call(this);
