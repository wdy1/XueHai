
var slider={
 num:-1,
 cur:0,
 cr:[],
 al:null,
 at:3*1000,
 ar:true,
 init:function(){
  if(!slider.data || !slider.data.length)
   return false;

  var d=slider.data;
  slider.num=d.length;
  var pos = Math.floor(Math.random() * 1);//slider.num);
  var NavW = $("#slide-holder").width();
  console.log(NavW);
  for(var i=0;i<slider.num;i++){
      $('#' + d[i].id).css({ left: ((i - pos) * NavW) });
   $('#slide-nav').append('<a id="slide-link-'+i+'" href="#" onclick="slider.slide('+i+');return false;" onfocus="this.blur();" class="slideA">'+(i+1)+'</a>');
  }

  $('img,div#slide-controls', $('div#slide-holder')).fadeIn();
  $('.btn-previ').click(function () {
      var next2 = slider.cur - 1;
      if (next2 <= 0) next2 = slider.num;
      slider.slide(next2);
  });
  $(window).resize(function () {
      var next3 = slider.cur + 1;
      if (next3 >= slider.num) next3 = 0;
      slider.slide(next3);
  });
  $('.btn-next').click(function () {
      var next3 = slider.cur + 1;
      if (next3 >= slider.num) next3 = 0;
      slider.slide(next3);
  });
  slider.text(d[pos]);
  slider.on(pos);
  slider.cur=pos;
  window.setTimeout('slider.auto();',slider.at);
 },
 auto:function(){
  if(!slider.ar)
   return false;

  var next=slider.cur+1;
  if(next>=slider.num) next=0;
  slider.slide(next);
 },
 
 slide:function(pos){
  if(pos<0 || pos>=slider.num || pos==slider.cur)
   return;

  window.clearTimeout(slider.al);
  slider.al=window.setTimeout('slider.auto();',slider.at);

  var d = slider.data;
  var Navw = $("#slide-holder").width();
  for(var i=0;i<slider.num;i++)
      $('#' + d[i].id).stop().animate({ left: ((i - pos) * Navw) }, 1000, 'swing');
  
  slider.on(pos);
  slider.text(d[pos]);
  slider.cur=pos;
 },
 on:function(pos){
  $('#slide-nav a').removeClass('on');
  $('#slide-nav a#slide-link-'+pos).addClass('on');
 },
 text:function(di){
  slider.cr['a']=di.client;
  slider.cr['b']=di.desc;
  slider.ticker('#slide-client span',di.client,0,'a');
  slider.ticker('#slide-desc',di.desc,0,'b');
 },
 ticker:function(el,text,pos,unique){
  if(slider.cr[unique]!=text)
   return false;

  ctext=text.substring(0,pos)+(pos%2?'-':'_');
  $(el).html(ctext);

  if(pos==text.length)
   $(el).html(text);
  else
   window.setTimeout('slider.ticker("'+el+'","'+text+'",'+(pos+1)+',"'+unique+'");',30);
 }
};
