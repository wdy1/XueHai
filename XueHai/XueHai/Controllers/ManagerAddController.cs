using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BLL;
using PagedList;
using System.Net;
using System.IO;
using System.Web.Helpers;
using XueHai.Attributes;
using System.Data.Entity;
using DAL;

namespace Shiyun.Controllers
{
    public class ManagerAddController : Controller
    {
        XueHaiEntities db = DbContextFactory.CreateDbContext();
        //TimeManager timemanager = new TimeManager();
        VideoKManager vk = new VideoKManager();
        VideoManager video = new VideoManager();
        ManagerManager mm = new ManagerManager();
        GoodsManager gd = new GoodsManager();
        GoodsKManager gdk = new GoodsKManager();

        

        #region 视频后台
        #region 视频类别添加
        public ActionResult VideoKCreate()
        {
            return View("VideoKCreate");
        }
        #region//添加视频类别的POST方法
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult VideoKCreate([Bind(Include = "VideoK_id,VideoKName,Cover,VideoDetails,VideoJianjie,Source,AddTime")]VideoK videok)
        {
            videok.AddTime = System.DateTime.Now;
            try
            {
                HttpPostedFileBase videokcover = Request.Files["Cover"];

                string filePath = videokcover.FileName;
                string filename = filePath.Substring(filePath.LastIndexOf("\\") + 1);
                string serverpath = Server.MapPath(@"\Images\VideoK\") + filename;
                string relativepath = @"/Images/VideoK/" + filename;
                videokcover.SaveAs(serverpath);
                videok.Cover = relativepath;
                vk.AddVideoK(videok);

                db.SaveChanges();
                return RedirectToAction("TypeIndex");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
            return View("VideoKCreate", videok);
        }

        #endregion
        #endregion
        #region 视频类别列表
        public ActionResult VideoKIndex(int? page)
        {
            var shi =vk.GetVideoK();
            int pageSize = 10;
            int pageNumber = (page ?? 1);

            return View(shi.ToPagedList(pageNumber, pageSize));
        }
        #endregion

        #region 视频添加
        #region//添加视频的Get方法
        public ActionResult VideoCreate()
        {
            
            ViewBag.VideoK_id = new SelectList(db.VideoK, "VideoK_id", "VideoKName");
            return View("VideoCreate");
        }
        #endregion      
        #region //添加视频的POST方法
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult VideoCreate(Video v)
        {
            HttpPostedFileBase videocover = Request.Files["Cover"];
            HttpPostedFileBase videurl = Request.Files["VideoURL"];
            v.AddTime = System.DateTime.Now;
            try
            {

                if (videocover != null)
                {
                    string filePath = videocover.FileName;
                    string filename = filePath.Substring(filePath.LastIndexOf("\\") + 1);
                    string serverpath = Server.MapPath(@"\Images\Video\") + filename;
                    string relativepath = @"/Images/Video/" + filename;
                    videocover.SaveAs(serverpath);
                    v.Cover = relativepath;
                }
                else
                {
                    return Content("<script>;alert('请先上传图片！');history.go(-1)</script>");
                }
                if (videurl != null)
                {
                    string filePath = videurl.FileName;
                    string filename = filePath.Substring(filePath.LastIndexOf("\\") + 1);
                    string serverpath = Server.MapPath(@"\Video\") + filename;
                    string relativepath = @"/Video/" + filename;
                    videurl.SaveAs(serverpath);
                    v.VideoURL = relativepath;
                }
                video.AddVideo(v);
               
                db.SaveChanges();
                return RedirectToAction("CiIndex");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
            ViewBag.VideoK_id = new SelectList(db.VideoK, "VideoK_id", "VideoKName", v.VideoK_id);
            return View("CiCreate", v);
        }
        #endregion
        #endregion
        #region 视频列表
        public ActionResult VideoIndex(int? page)
        {
            var shi = video.GetVideo();
            int pageSize = 10;
            int pageNumber = (page ?? 1);

            return View(shi.ToPagedList(pageNumber, pageSize));
        }
        #endregion
        #endregion

        #region 后台附页
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult main()
        {
            return View();
        }
        #endregion      

        #region 后台主页
        public ActionResult menu()
        {
            string uid = Session["Manager_id"].ToString();
            if (uid != null)
            {
                return View();
            }
            else
            {
                return Content("<script>alert('您尚未登陆，请登陆');history.go(-1);</script>");
            }
            
        }
        #endregion

        #region 后台登录
        [HttpPost]
        public string Login([Bind(Include = "Manager_id,ManagerPass")]string Manager_id, string ManagerPass)
        {
            try
            {
                var users = mm.Denglu(Manager_id, ManagerPass);
                if (users != null)
                {
                    //保存到Session HttpContext.
                    Session["Manager_id"] = Manager_id;
                    Session["ManagerName"] = mm.GetManagersById(Manager_id).ManagerName;
                    string data = "登录成功";
                    return data;
                }
                else
                {
                    string data = "登录失败";
                    return data;
                }
            }
            catch (Exception ex)
            {
                string data = "错误";
                return data;
            }
        }
        #endregion

        #region 后台注销
        [HttpPost]
        public string Zhuxiao()
        {
            //保存到Session HttpContext.
            Session["Manager_id"] = null;
            string A = "a";
            return A;
        }
        #endregion

        #region 评论列表
        public ActionResult ScIndex()
        {
            var comments = db.Comments.ToList();/*var a = db.Set<Comments>();*/
            return View(comments);
        }
        #endregion
         

    }
}