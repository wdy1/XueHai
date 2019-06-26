using BLL;
using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace XueHai.Controllers
{
    public class SearchController : Controller
    {
        UserInfoManager userInfoManager = new UserInfoManager();
        GoodsManager goodsManager = new GoodsManager();
        PostManager postManager = new PostManager();
        VideoManager videoManager = new VideoManager();
        Models.SearchViewModel searchvm = new Models.SearchViewModel();
        // GET: Search
        //public ActionResult Index()
        //{
        //    string search = Session["Search"].ToString();
        //    searchvm.Video1 = videoManager.Search(search);
        //    searchvm.Goods1 = goodsManager.Search(search);
        //    searchvm.Post1 = postManager.Search(search);
        //    searchvm.UserInfo1 = userInfoManager.Search(search);
        //    return View(searchvm);
        //}
        #region 搜索页面
        public ActionResult Index(string search)
        {
            if(search == "")
            {
                return Content("<script>;alert('请输入搜索内容!!');window.location.href='/Home/Index'</script>");
                //return Content("<script>;alert('请输入搜索内容!');</script>");
            }
            else
            {
                Session["Search"] = search;
                //searchvm.Video1 = videoManager.Search(search);
                searchvm.Goods1 = goodsManager.Search(search);
                //searchvm.Post1 = postManager.Search(search);
                //searchvm.UserInfo1 = userInfoManager.Search(search);
                return View(searchvm);
            }
            
        }
        #endregion
    }
}