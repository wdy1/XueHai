using DAL;
using DALFactory;
using IDAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserInfoManager
    {
        //IUserInfo iuserinfo = new SqlUserInfo();
        IUserInfo iuserinfo = DataAccess.CreateUserInfo();
        public void AddUserInfo(UserInfo userInfo)
        {
            iuserinfo.AddUserInfo(userInfo);
        }
        public UserInfo Login(string UserName, string UserPass) 
        {
            var userInfo = iuserinfo.Login(UserName, UserPass);
            return userInfo;
        }
        public void AddUserAddress(UserAddress userAddress)
        {
            iuserinfo.AddUserAddress(userAddress);
        }
        public IEnumerable<UserInfo> Search(string search)
        {
            var userInfo = iuserinfo.Search(search);
            return userInfo;
        }
        public IEnumerable<UserInfo> IEGetUsersById(int Users_id)
        {
            var userInfo = iuserinfo.IEGetUsersById(Users_id);
            return userInfo;
        }
        public void UpdateUserInfo(UserInfo userInfo)
        {
            iuserinfo.UpdateUserInfo(userInfo);
        }
        public IEnumerable<View_UserInfo> CountUserGuanzhu1ById(int uid)  //关注人数
        {
            var u1 = iuserinfo.CountUserGuanzhu1ById(uid);
            return u1;
        }
        public IEnumerable<View_UserInfo> CountUserGuanzhu2ById(int uid)  //被关注人数
        {
            var u2 = iuserinfo.CountUserGuanzhu2ById(uid);
            return u2;
        }

        public void GuanZhu(UserGuanzhu us)
        {
            iuserinfo.GuanZhu(us);
        }

        public void QuXiaoGuanZhu(int userA, int userB)
        {
            iuserinfo.QuXiaoGuanZhu(userA, userB);
        }
    }
}
