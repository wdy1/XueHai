using BLL;
using DAL;
using Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XueHai.Attributes;

namespace XueHai.Controllers
{
    //public class tip
    //{
    //    public string message { get; set; }
    //    public int code { get; set; }
    //}
    public class MallController : Controller
    {
        // GET: Mall
        public double Ordersum;
        XueHaiEntities db = DbContextFactory.CreateDbContext();
        GoodsManager goodsmanager = new GoodsManager();
        ShopCarManager shopcarmanager = new ShopCarManager();
        UserInfoManager userInfoManager = new UserInfoManager();
        OrdersManager ordersManager = new OrdersManager();
        public ActionResult Index()
        {
            return View();
        }
        #region 加入购物车
        [Login]
        [HttpPost]
        public ActionResult jrgwc([Bind(Include = "Goods_id,Count,Price,Users_id,note,Time,flag")] ShopCar shopCar)
        {
            string name = Request.Form["ljgm"];
            shopCar.Users_id = (int)Session["Users_id"];/*int.Parse(Session["Users_id"].ToString())*/
            var nowcount = shopCar.Count;
            var nowgoodsid = (int)shopCar.Goods_id;
            var a = shopcarmanager.CountShopcarById(shopCar.Users_id, shopCar.Goods_id);
            var b = shopcarmanager.CountShopcarCountById(shopCar.Users_id, shopCar.Goods_id);
            var beforecount = shopcarmanager.beforeCount(shopCar.Users_id, shopCar.Goods_id);
            if (a == 1)
            {
                //先查询出拿一条数据，再赋值
                var beforeshopcar = shopcarmanager.whereShopcarById(shopCar.Users_id, nowgoodsid);
                beforeshopcar.Goods_id = nowgoodsid;
                beforeshopcar.Users_id = (int)Session["Users_id"]; /*Session["Users_id"].ToString();*/
                beforeshopcar.Count = nowcount + beforecount;
                beforeshopcar.note = "";
                beforeshopcar.Time = System.DateTime.Now;
                beforeshopcar.flag = 0;
                shopcarmanager.UpdateShopcarCount(beforeshopcar);
                if (name == "1")
                {
                    return RedirectToAction("Shopcar", "Mall");
                }
                else
                {
                    if (b == 1)
                    {
                        return Content("<script>;alert('添加成功！');history.go(-1)</script>");
                    }
                    else
                    {
                        return Content("<script>;alert('添加失败！');history.go(-1)</script>");
                    }
                }
            }
            else
            {
                shopCar.Users_id = (int)Session["Users_id"];
                shopCar.note = "";
                shopCar.Time = System.DateTime.Now;
                shopCar.flag = 0;
                shopcarmanager.AddShopCar(shopCar);
                if (name == "1")
                {
                    return RedirectToAction("Shopcar", "Mall");
                }
                else
                {
                    var c = shopcarmanager.CountShopcarById(shopCar.Users_id, shopCar.Goods_id);
                    if (c == 1)
                    {
                        return Content("<script>;alert('加入购物车成功！');history.go(-1)</script>");
                    }
                    else
                    {
                        return Content("<script>;alert('加入购物车失败！');history.go(-1)</script>");
                    }
                }
            }
        }
        #endregion

        #region 购物车页
        [Login]
        public ActionResult Shopcar()
        {
            int uid = (int)Session["Users_id"];
            var vsc = shopcarmanager.FindviewShopcarById(uid);
            return View(vsc);
        }
        #endregion

        #region 购物车更新数量
        [HttpPost]
        public string Update(int id, int count)
        {
            int uid = (int)Session["Users_id"];
            var beforeshopcar = shopcarmanager.whereShopcarById(uid, id);
            beforeshopcar.Goods_id = id;
            beforeshopcar.Users_id = (int)Session["Users_id"];
            beforeshopcar.Count = count;
            beforeshopcar.note = "";
            beforeshopcar.Time = System.DateTime.Now;
            beforeshopcar.flag = 0;
            shopcarmanager.UpdateShopcarCount(beforeshopcar);
            if (shopcarmanager.CountShopcarById(uid, id) != 0)
            {
                string data = "修改成功";
                return data;
            }
            else
            {
                string data = "修改失败";
                return data;
            }
        }
        #endregion

        #region 购物车删除
        public ActionResult Delete(int id)
        {
            int uid = (int)Session["Users_id"];
            var existShopCar = shopcarmanager.IQwhereShopcarById(uid, id);
            if (existShopCar != null)
            {
                var newshopcar = shopcarmanager.FindShopcarById(uid);
                shopcarmanager.RemoveRangeShopCar(existShopCar);
                return Content("<script>;alert('删除成功！');window.location.href='/Mall/ShopCar'</script>");
            }
            return RedirectToAction("Shopcar");
        }

        #endregion

        #region 购物车结算按钮
        [HttpPost]
        public string Jiesuan(int id, double? sum)
        {
            int uid = (int)Session["Users_id"];/*int a = int.Parse(Session["Users_id"].ToString())*/
            Ordersum = Convert.ToDouble(sum);
            var beforeshopcar = shopcarmanager.whereShopcarById(uid, id);
            beforeshopcar.flag = 1;
            shopcarmanager.UpdateShopcarCount(beforeshopcar);
            if (shopcarmanager.CountShopcarById(uid, id) != 0)
            {
                string data = "修改成功";
                return data;
            }
            else
            {
                string data = "修改失败";
                return data;
            }
        }
        #endregion

        #region 订单页
        [Login]
        public ActionResult Order(double? ordersum)
        { 
            ViewBag.Ordersum = ordersum;
            int uid = (int)Session["Users_id"];
            var user1 = userInfoManager.IEGetUsersById(uid);
            var viewshopcar1 = shopcarmanager.FindviewShopcarByIdflag1(uid);

            Models.OrderViewModels ordervm = new Models.OrderViewModels();
            ordervm.List1 = new SelectList(db.UserAddress.Where(c => c.Users_id == uid), "Address", "Address");//下拉列表数据绑定
            ordervm.ViewShopCar1 = viewshopcar1;
            ordervm.UserInfo1 = user1;
            return View(ordervm);
        }
        #endregion

        #region 确认购买

        [HttpPost]
        public string Querengoumai(string uname, string userphone, string address, string note)
        {
            int uid = (int)Session["Users_id"];
            ordersManager.Goumai(uid, uname, userphone, address, note);
            string data = "修改成功";
            return data;
        }
        //public JsonResult Querengoumai(string name, string phone, string address2, string note)
        //{
        //    int uid = (int)Session["Users_id"];
        //    tip t = null;
        //    Orders o = new Orders()
        //    {
        //        Users_id = uid,
        //        UserName = name,
        //        UserPhone = phone,
        //        Address = address2,
        //        note = note,
        //        OrderTime = DateTime.Now
        //    };
        //    try
        //    {
        //        ordersManager.Goumai(o.Users_id, o.UserName, o.UserPhone, o.Address, o.note, o.OrderTime);
        //        //db.ShopCar_Orders.Add(o.);
        //        //db.SaveChanges();
        //        t = new tip()
        //        {
        //            message = "生成订单成功",
        //            code = 200
        //        };
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //    return base.Json(t);
        //}
        #endregion

        #region 添加地址

        [HttpPost]
        public string UserAddress(UserAddress useraddress, string address)
        {
            useraddress.Users_id = (int)Session["Users_id"];
            useraddress.Address = address;
            userInfoManager.AddUserAddress(useraddress);
            string data = "成功";
            return data;
        }
        #endregion

        #region 我的订单页
        [Login]
        public ActionResult OrderDetails(int? page)
        {
            int uid = (int)Session["Users_id"];
            var vod = shopcarmanager.FindviewodById(uid);
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(vod.ToPagedList(pageNumber, pageSize));
        }
        #endregion

        #region 订单列表
        public ActionResult OrdersIndex(int? page)
        {
            var goods = ordersManager.GetOrders();
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View(goods.ToPagedList(pageNumber, pageSize));
        }
        #endregion

        #region 个人中心订单页
        [Login]
        public ActionResult _ucOrderDetails(int? page)
        {
            int uid = (int)Session["Users_id"];
            var vod = shopcarmanager.FindviewodById(uid);
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(vod.ToPagedList(pageNumber, pageSize));
        }
        #endregion

    }
}