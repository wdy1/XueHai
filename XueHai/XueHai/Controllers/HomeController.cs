using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace XueHai.Controllers
{
    public class HomeController : Controller
    {
        GoodsManager goodsManager = new GoodsManager();
        GoodsKManager goodskManager = new GoodsKManager();
        PostManager postManager = new PostManager();
        UserInfoManager userInfoManager = new UserInfoManager();
        public ActionResult Index()
        {
            var goods1 = goodsManager.GetGoods();
            var goodsk = goodskManager.GetGoodsK();
            Models.HomeIndexViewModel homevm = new Models.HomeIndexViewModel();
            homevm.Goods1 = goods1;
            homevm.Goodsk = goodsk;
            return View(homevm);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}