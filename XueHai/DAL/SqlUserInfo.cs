using IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data.Entity;

namespace DAL
{
    public class SqlUserInfo : IUserInfo
    {
        XueHaiEntities db = DbContextFactory.CreateDbContext();
        public void AddUserInfo(UserInfo userInfo)
        {
            db.UserInfo.Add(userInfo);
            db.SaveChanges();
        }

        public void AddUserAddress(UserAddress userAddress)
        {
            db.UserAddress.Add(userAddress);
            db.SaveChanges();
        }
        public void GuanZhu(UserGuanzhu us)
        {
            throw new NotImplementedException();
        }

        public UserInfo Login(string UserPhone, string UserPass)
        {
            var userInfo = db.UserInfo.Where(u => u.UserPhone == UserPhone).Where(u => u.UserName == UserPass).FirstOrDefault();
            return userInfo;
        }

        public void QuXiaoGuanZhu(int userA, int userB)
        {
            throw new NotImplementedException();
        }

        public void UpdateUserInfo(UserInfo userInfo)
        {
            db.Entry(userInfo).State = EntityState.Modified;
            db.SaveChanges();
        }
        public IEnumerable<UserInfo> Search(string search)
        {
            var userInfo = from po in db.UserInfo
                           where po.UserName.Contains(search) || po.Users_id.Equals(search)
                           select po;
            return userInfo.ToList();
        }

        public IEnumerable<View_UserInfo> CountUserGuanzhu1ById(int uid)  //关注人数
        {
            var userA = from ugz in db.View_UserInfo
                        where ugz.UserA == uid
                        select ugz; /*db.UserGuanzhu.Where(c => c.UserA == uid).Select(c => c.UserA).Count();*/
            return userA;
        }
        public IEnumerable<View_UserInfo> CountUserGuanzhu2ById(int uid)  //被关注人数
        {
            var userB = from ugz in db.View_UserInfo
                        where ugz.UserB == uid
                        select ugz; /*db.UserGuanzhu.Where(c => c.UserB == uid).Select(c => c.UserB).Count();*/
            return userB;
        }
        //public UserInfo GetUsersById(string Users_id)
        //{
        //    UserInfo userInfo = db.UserInfo.Find(Users_id);
        //    return userInfo;
        //}
        public IEnumerable<UserInfo> IEGetUsersById(int Users_id)
        {
            var userInfo = db.UserInfo.Where(c => c.Users_id == Users_id);
            return userInfo;
        }
    }
}
