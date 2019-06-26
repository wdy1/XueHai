using IDAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DALFactory;
using BLL;
using XueHai.Models;
using DAL;
using XueHai.Attributes;

namespace XueHai.Controllers
{
    public class UserInfoController : Controller
    {
        XueHaiEntities db = DbContextFactory.CreateDbContext();
        UserInfoManager userinfomanager = new UserInfoManager();
        PostManager postManager = new PostManager();
        // GET: UserInfo
        public ActionResult Index()
        {
            return View();
        }
        # region 注册
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserInfo userInfo)
        {
            string PhoneYZM = Request.Form["PhoneYZM"].ToString();
            var addtime = DateTime.Now;
            userInfo.Addtime = addtime;
            if (PhoneYZM == "")
            {
                return Content("请输入验证码！");
            }
            if (ModelState.IsValid)
            {
                var mobilecodeItem = MobileCodeList.PhoneCodeList.Where(m => m.Mobile == userInfo.UserPhone).FirstOrDefault();
                if (mobilecodeItem == null)
                {
                    return Content("验证码还未发送,请重新发送或稍等！");
                }
                else if (PhoneYZM != mobilecodeItem.Code)
                {
                    return Content("<script>;alert('验证码错误,请重新输入！');</script>");
                }
                else
                {
                    var User = db.UserInfo.Where(u => u.UserPhone == userInfo.UserPhone).FirstOrDefault();
                    if (User != null)
                    {
                        return Content("<script>;alert('该手机号码已经被注册了，请更改手机号进行注册！');</script>");
                    }
                    else
                    {
                        userinfomanager.AddUserInfo(userInfo);
                        return Content("<script>;alert('注册成功！');window.location.href='/UserInfo/Login';</script>");
                    }
                }
            }
            return View();
        }
        //向手机发送验证码
        [HttpPost]
        public ContentResult MessageSend(string Phone)
        {
            var user = db.UserInfo.Where(u => u.UserPhone == Phone).FirstOrDefault();
            if (user != null)
            {
                return Content("0");
            }
            else
            {
                MessageSendXDemo messageSendXDemo = new MessageSendXDemo();
                string YZM = messageSendXDemo.random_6();
                messageSendXDemo.SendMessage(Phone, YZM);
                MobileCode mobilecode = new MobileCode();
                mobilecode.Mobile = Phone;
                mobilecode.Code = YZM;
                var mobilecodeItem = MobileCodeList.PhoneCodeList.Where(m => m.Mobile == Phone).FirstOrDefault();
                if (mobilecodeItem == null)
                {
                    MobileCodeList.PhoneCodeList.Add(mobilecode);
                }
                else
                {
                    MobileCodeList.PhoneCodeList.Remove(mobilecodeItem);
                    MobileCodeList.PhoneCodeList.Add(mobilecode);
                }
                return Content("1");
            }
        }
        [HttpPost]
        public ContentResult HasUser(string username)
        {
            var user = db.UserInfo.Where(o => o.UserName == username).FirstOrDefault();
            if (user != null)
            {
                return Content("0");
            }
            else
            {
                return Content("1");
            }
        }
        #endregion

        #region 登录
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserInfo userInfo)
        {
            string ValidateCode1 = Request["code1"];
            string ValidateCode2 = Request["help"].ToString();
            if (ValidateCode2 != "true")
            {
                return Content("<script>;alert('验证码错误！');window.location.href='/UserInfo/Login'</script>");
            }
            try
            {
                var username = db.UserInfo.Where(o => o.UserName == userInfo.UserName).FirstOrDefault(); ;
                if (username != null)
                {
                    var users = db.UserInfo.Where(o => o.UserName == userInfo.UserName).Where(o => o.UserPass == userInfo.UserPass).FirstOrDefault();
                    if (users != null)
                    {
                        //以下代码将权限保存到Session
                        // var current_user = db.Users.Where(o => o.UserName == user.UserName).FirstOrDefault();
                        HttpContext.Session["Users_id"] = users.Users_id;
                        HttpContext.Session["UserName"] = users.UserName;
                        //return Content("<script>;alert('登录成功!返回首页!');window.location.href='/Home/Index'</script>");
                        return Content("<script>;alert('登录成功!');history.go(-2)</script>");
                    }
                    else
                    {
                        return Content("<script>;alert('密码输入错误!');</script>");
                    }
                }
                else
                {
                    return Content("<script>;alert('该账号不存在!');</script>");
                }
                //return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        #endregion

        #region 退出
        [HttpPost]
        public string Zhuxiao()
        {
            //保存到Session HttpContext.
            Session["Users_id"] = null;
            string A = "a";
            return A;
        }
        //public ActionResult ZhuXiao()
        //{
        //    HttpContext.Session["Users_id"] = null;
        //    return Content("<script>;alert('退出成功!');window.location.href='/Home/Index'</script>");

        //}
        #endregion

        #region 个人中心
        [Login]
        public ActionResult UserCenter(int Users_id)
        {
            UserCenterViewModel uc = new UserCenterViewModel();
            uc.Uses1 = userinfomanager.IEGetUsersById(Users_id);
            ViewBag.Users_id = Users_id;
            //uc.List1 = new SelectList(db.UserAddress.Where(c => c.Users_id == Users_id), "Address", "Address");//下拉列表数据绑定
            uc.UserInfo = db.UserInfo.Find(Users_id);
            Session["Guanzhu"] = 0; //未关注
            //关注人数
            uc.UserA = userinfomanager.CountUserGuanzhu1ById(Users_id).Count();
            //粉丝人数            
            uc.UserB = userinfomanager.CountUserGuanzhu2ById(Users_id).Count();
            uc.UsesAa = userinfomanager.CountUserGuanzhu1ById(Users_id);
            uc.UsesBb = userinfomanager.CountUserGuanzhu2ById(Users_id);

            //判断是否为其粉丝
            foreach (var item in userinfomanager.CountUserGuanzhu2ById(Users_id))
            {
                if (Session["Users_id"] != null)
                {
                    if (item.UserA == (int)Session["Users_id"])
                    {
                        Session["Guanzhu"] = 1; //已经关注
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
            return View(uc);
        }
        #endregion

        //#region 分页数据获取
        //public ActionResult _Yuanchuang(int Users_id, int? page)
        //{
        //    ViewBag.Users_id = Users_id;
        //    var yuanchaung = postManager.GetPostByUser(Users_id, 1);
        //    int pageSize = 10;
        //    int pageNumber = (page ?? 1);
        //    return View(yuanchaung.ToPagedList(pageNumber, pageSize));
        //}
        //public ActionResult _Langsong(int Users_id, int? page)
        //{
        //    ViewBag.Users_id = Users_id;
        //    var yuanchaung = postManager.GetPostByUser(Users_id, 2);
        //    int pageSize = 10;
        //    int pageNumber = (page ?? 1);
        //    return View(yuanchaung.ToPagedList(pageNumber, pageSize));
        //}
        //public ActionResult _TaoLun(int Users_id, int? page)
        //{
        //    ViewBag.Users_id = Users_id;
        //    var yuanchaung = postManager.GetPostByUser(Users_id, 3);
        //    int pageSize = 10;
        //    int pageNumber = (page ?? 1);
        //    return View(yuanchaung.ToPagedList(pageNumber, pageSize));
        //}
        //public ActionResult _Caogao(int Users_id, int? page)
        //{
        //    ViewBag.Users_id = Users_id;
        //    var caogao = postManager.GetPostDraftByUser(Users_id);
        //    int pageSize = 10;
        //    int pageNumber = (page ?? 1);
        //    return View(caogao.ToPagedList(pageNumber, pageSize));
        //}
        //#endregion

        #region 修改资料
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Ziliao(UserInfo userInfo)
        {
            HttpPostedFileBase userImage = Request.Files["UserImage"];
            try
            {
                if (userImage.FileName != "")
                {

                    string filePath = userImage.FileName;
                    /*DateTime.Now.ToString("yyyyMMddHHmmssfffffff") +*/
                    string filename = filePath.Substring(filePath.LastIndexOf("\\") + 1);
                    string serverpath = Server.MapPath(@"\Images\userInfo\") + filename;
                    string relativepath = @"\Images\userInfo\" + filename;
                    userImage.SaveAs(serverpath);
                    userInfo.UserImage = relativepath;
                }
                else
                {
                    userInfo.UserImage = db.UserInfo.Find(userInfo.Users_id).UserImage;
                }
                if (ModelState.IsValid)
                {
                    var beuserInfo = db.UserInfo.Where(p => p.Users_id == userInfo.Users_id).FirstOrDefault();
                    beuserInfo.UserName = userInfo.UserName;
                    beuserInfo.UserRPass = beuserInfo.UserPass;
                    beuserInfo.UserImage = userInfo.UserImage;
                    beuserInfo.UserMail = userInfo.UserMail;
                    beuserInfo.Address = userInfo.Address;
                    beuserInfo.SafeQues = userInfo.SafeQues;
                    beuserInfo.Sex = userInfo.Sex;
                    beuserInfo.UserSign = userInfo.UserSign;
                    beuserInfo.Answer = userInfo.Answer;
                    beuserInfo.UserImage = userInfo.UserImage;
                    //userInfo.UserPass = db.UserInfo.Find(userInfo.Users_id).UserPass;
                    //userInfo.UserRPass = db.UserInfo.Find(userInfo.Users_id).UserPass;
                    userinfomanager.UpdateUserInfo(beuserInfo);

                    return RedirectToAction("UserCenter", "UserInfo", new { Users_id = userInfo.Users_id });
                    //return Content("<script>;alert('修改成功！');</script>");
                }
                else
                {
                    //return "bb";
                    return Content("<script>;alert('修改失败！');window.history.go(-1);window.location.reload();</script>");
                }
            }
            catch (Exception ex)
            {
                //return ex.ToString();
                return Content(ex.Message);
            }
        }

        #endregion
    }
}