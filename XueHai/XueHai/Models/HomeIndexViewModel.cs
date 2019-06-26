using BLL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XueHai.Models
{
    public class HomeIndexViewModel
    {
        public IEnumerable<Goods> Goods1 { get; set; }
        public IEnumerable<GoodsK> Goodsk { get; set; }
        public IEnumerable<Goods> Goods2 { get; set; }
        public IEnumerable<UserInfo> UserInfo1 { get; set; }
        //public IEnumerable<View_PostIndex> PostPaihang { get; set; }
    }
}