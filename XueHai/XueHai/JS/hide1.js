var china = document.getElementById("j_china");
var cl = document.getElementsByClassName("cl")[0];
var home = document.getElementById("j_home");
var ho = document.getElementsByClassName("home")[0];
var like = document.getElementById("j_like");
var fav = document.getElementsByClassName("fav")[0];
console.log(cl);

hideNav(china, cl);
hideNav(home, ho);
hideNav(like, fav);
function hideNav(a, b) {
    a.addEventListener('mouseenter', function () {
        a.style.backgroundColor = '#fff';
        a.style.borderBottom = "none";
        b.style.display = 'block';
    }, false);
    a.addEventListener('mouseleave', function () {
        a.style.backgroundColor = '#f4f4f4';
        b.style.display = 'none';
    }, false);
}

var close = document.getElementsByClassName("close")[0];
var ewm = document.getElementsByClassName("ewm-box")[0];
close.onclick = function () {
    ewm.style.display = "none";
}
