using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    public interface IShopCar
    {
        ShopCar whereShopcarById(int uid, int gid);
        IQueryable<ShopCar> IQwhereShopcarById(int uid, int gid);
        int whereCountInShopcar(int uid, int gid);
        int CountShopcarCountById(int uid, int gid);
        int beforeCount(int uid, int gid);
        int CountShopcarById(int uid, int gid);
        void UpdateShopcarCount(ShopCar shopCar);
        IQueryable<ShopCar> FindShopcarById(int uid);
        IEnumerable<View_OrderDetails> FindviewodById(int uid);
        IQueryable<View_ShopCar> FindviewShopcarById(int uid);
        IQueryable<View_ShopCar> FindviewShopcarByIdflag1(int uid);
        void RemoveRangeShopCar(IQueryable<ShopCar> shopcar);
        void AddShopCar(ShopCar shopcar);
    }
}
