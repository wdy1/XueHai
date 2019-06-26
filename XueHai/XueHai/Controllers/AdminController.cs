using BLL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace XueHai.Controllers
{
    
    public class AdminController : Controller
    {
        ManagerManager ma = new ManagerManager();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login([Bind(Include = "ManagerName,ManagerPass")]string ManagerName, string ManagerPass)
        {
            try
            {
                var users = ma.Denglu(ManagerName, ManagerPass);
                if (users != null)
                {
                    //保存到Session HttpContext.
                    Session["Manager_id"] = ManagerName;
                    //string data = "登录成功";
                    return Content("<script>;alert('登录成功！');window.location.href='/ManagerAdd/menu';</script>");
                }
                else
                {
                    //string data = "登录失败";
                    return Content("<script>;alert('登录失败！');window.history.go(-1);</script>");
                }
            }
            catch (Exception ex)
            {
                //string data = "错误";
                return Content("<script>;alert('登录失败！');window.history.go(-1);</script>");
            }
        }
    }
}