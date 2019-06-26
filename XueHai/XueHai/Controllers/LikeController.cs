using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace XueHai.Controllers
{
    public class LikeController : Controller
    {
        XueHaiEntities db = DbContextFactory.CreateDbContext();
        // GET: Like
        public ActionResult Index()
        {
            var fabook = db.FavoriteGoods.ToList();
            return View(fabook);
        }
        public ActionResult SC(int id)
        {
            var book = db.Goods.Where(p => p.Goods_id == id).FirstOrDefault();
            var type = db.GoodsK.Where(p => p.GoodsK_id == book.GoodsK_id).FirstOrDefault().GoodsKName;
            try
            {
             if (book!=null)
                {
                    FavoriteGoods fabook = new FavoriteGoods()
                     {
                         Users_id = (int)Session[" Users_id"],
                         Goods_id = book.Goods_id,
                         FavoriteType = type,
                         Time = DateTime.Now,
                         Number=0
                     };
                    db.FavoriteGoods.Add(fabook);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Like");
                }
            else
            {
                return Content("<script>;alert('收藏失败！');</script>");
            }
            }
            catch (Exception ex)
            {
                //return ex.ToString();
                return Content(ex.Message);
            }



        }
    }
}