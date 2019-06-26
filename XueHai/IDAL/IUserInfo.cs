using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public interface IUserInfo
    {
        void AddUserInfo(UserInfo userInfo);
        void AddUserAddress(UserAddress userAddress);
        UserInfo Login(string UserPhone, string UserPass);
        void UpdateUserInfo(UserInfo userInfo);
        void GuanZhu(UserGuanzhu us);
        void QuXiaoGuanZhu(int userA, int userB);
        IEnumerable<UserInfo> Search(string search);
        IEnumerable<View_UserInfo> CountUserGuanzhu1ById(int uid);
        IEnumerable<View_UserInfo> CountUserGuanzhu2ById(int uid);
        IEnumerable<UserInfo> IEGetUsersById(int Users_id);
    }
}
