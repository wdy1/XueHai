using BLL;
using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XueHai.Attributes;
using XueHai.Models;

namespace XueHai.Controllers
{
    public class CommentController : Controller
    {
        XueHaiEntities db = DbContextFactory.CreateDbContext();
        GoodsManager goodsmanager = new GoodsManager();
        // GET: Comment
        [Login]
        public ActionResult Index(int goodsid)
        {
            var good = goodsmanager.GetGoodsById(goodsid);
            return View(good);
        }
        [HttpGet]
        public ActionResult CommentSummery()
        {
            IEnumerable<ViewModel> vmss = GetComAndRep();
            return PartialView(vmss);
        }
        [HttpPost]
        public ActionResult CommentSummery(int? ComID, int? Users_id, int? rep_userid, int? Goods_id, int? Post_id, int? Video_id, string ComContent = null, int PaiseNum = 0)
        {
            if (Goods_id != null && ComContent != null)
            {
                Comments c = new Comments()
                {
                    Users_id = (int)Session["Users_id"],
                    Goods_id = Goods_id,
                    Post_id= Post_id,
                    Video_id= Video_id,
                    ComContent = ComContent,
                    ComTime = DateTime.Now,
                    PaiseNum = 0
                };
                db.Comments.Add(c);
                db.SaveChanges();
            }
            else if (ComID != null)
            {
                Reply r = new Reply()
                {
                    ComID = (int)ComID,
                    Users_id = (int)rep_userid,
                    ReplyContent = ComContent,
                    ReplyTime = DateTime.Now,
                    
                };
                db.Reply.Add(r);
                db.SaveChanges();
            }
            IEnumerable<ViewModel> vmss = GetComAndRep();
            return PartialView(vmss);
        }
        public IEnumerable<ViewModel> GetComAndRep()
        {
            //启用贪婪加载 否则你会发现当表中的数据为空时你第一次插入数据 会报Nullreferenceexception(未将对象引用设置到实例)
            //原因就是 comment表查出来但是默认的导航属性时懒加载 在试图中如果存在使用导航属性的地方自然报错
            IEnumerable<Comments> coms = db.Comments.Include("UserInfo");
            IList<ViewModel> vms = new List<ViewModel>();
            foreach (var com in coms)
            {
                int status = 2;
                //查找该评论下的点赞以及回复  
                //实际项目中 e.User_Id==1 应当使用当前用户id
                Praised p = db.Praised.Where(e => (e.ComID == com.ComID && e.Users_id == 1)).FirstOrDefault();
                //查找出当前用户点赞过的所有回复
                IQueryable<Praised> pp = db.Praised.Where(e => e.Users_id == 1);
                var query = (from P in pp
                             join R in db.Reply
                             on P.Reply_id equals R.Reply_id
                             select R).ToList();
                IList<Reply> pr = query;
                if (p != null)
                {
                    //该评论被当前用户赞过了
                    status = 1;
                }
                IQueryable<Reply> rs = db.Reply.Include("User").Where(e => e.ComID == com.ComID);
                ViewModel vm = new ViewModel()
                {
                    c = com,
                    Rs = rs,
                    PraStatus = status,
                    Ps = pr
                };
                vms.Add(vm);
            }
            IEnumerable<ViewModel> vmss = vms;

            return vmss;
        }
    }
}