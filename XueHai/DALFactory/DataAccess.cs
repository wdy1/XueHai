using IDAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DALFactory
{
    public class DataAccess
    {
        private static string AssemblyName = ConfigurationManager.AppSettings["Path"].ToString();
        private static string db = ConfigurationManager.AppSettings["DB"].ToString();
        public static IUserInfo CreateUserInfo()
        {
            string className = AssemblyName + "." + db + "UserInfo";
            return (IUserInfo)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static IGoods CreateGoods()
        {
            string className = AssemblyName + "." + db + "Goods";
            return (IGoods)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static IShopCar CreateShopCar()
        {
            string className = AssemblyName + "." + db + "ShopCar";
            return (IShopCar)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static IGoodsK CreateGoodsK()
        {
            string className = AssemblyName + "." + db + "GoodsK";
            return (IGoodsK)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static ILunTan CreateLunTan()
        {
            string className = AssemblyName + "." + db + "LunTan";
            return (ILunTan)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static IManager CreateManager()
        {
            string className = AssemblyName + "." + db + "Manager";
            return (IManager)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static IOrders CreateOrders()
        {
            string className = AssemblyName + "." + db + "Orders";
            return (IOrders)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static IOrdersDetails CreateOrderDetails()
        {
            string className = AssemblyName + "." + db + "OrderDetails";
            return (IOrdersDetails)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static IPost CreatePost()
        {
            string className = AssemblyName + "." + db + "Post";
            return (IPost)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static IUserGuanzhu CreateUserGuanzhu()
        {
            string className = AssemblyName + "." + db + "UserGuanzhu";
            return (IUserGuanzhu)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static IVideo CreateVideo()
        {
            string className = AssemblyName + "." + db + "Video";
            return (IVideo)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static IVideoK CreateVideoK()
        {
            string className = AssemblyName + "." + db + "VideoK";
            return (IVideoK)Assembly.Load(AssemblyName).CreateInstance(className);
        }






    }
}
