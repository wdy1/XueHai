using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Models;
using DALFactory;

namespace BLL
{
    public class ShopCarManager
    {
        IShopCar ishopcar = DataAccess.CreateShopCar();
        public ShopCar whereShopcarById(int uid, int gid)
        {
            ShopCar shopcar = ishopcar.whereShopcarById(uid, gid);
            return shopcar;
        }

        public IQueryable<ShopCar> IQwhereShopcarById(int uid, int gid)
        {
            var shopcar = ishopcar.IQwhereShopcarById(uid, gid);
            return shopcar;
        }
        public IQueryable<ShopCar> FindShopcarById(int uid)
        {
            var shopcar = ishopcar.FindShopcarById(uid);
            return shopcar;
        }

        public IEnumerable<View_OrderDetails> FindviewodById(int uid)
        {
            var viewordersd = ishopcar.FindviewodById(uid);
            return viewordersd;
        }
        public IQueryable<View_ShopCar> FindviewShopcarById(int uid)
        {
            var viewshopcar = ishopcar.FindviewShopcarById(uid);
            return viewshopcar;
        }
        public IQueryable<View_ShopCar> FindviewShopcarByIdflag1(int uid)
        {
            var viewshopcar = ishopcar.FindviewShopcarByIdflag1(uid);
            return viewshopcar;
        }
        public int CountShopcarById(int uid, int gid)
        {
            var shopcar = ishopcar.CountShopcarById(uid, gid);
            return shopcar;
        }
        public void UpdateShopcarCount(ShopCar shopCar)
        {
            ishopcar.UpdateShopcarCount(shopCar);
        }
        public int CountShopcarCountById(int uid, int gid)
        {
            var shopcar = ishopcar.CountShopcarCountById(uid, gid);
            return shopcar;
        }
        public int beforeCount(int uid, int gid)
        {
            var shopcar = ishopcar.beforeCount(uid, gid);
            return shopcar;
        }
        public int whereCountInShopcar(int uid, int gid)
        {
            var shopcar = ishopcar.whereCountInShopcar(uid, gid);
            return shopcar;
        }
        public void RemoveRangeShopCar(IQueryable<ShopCar> shopcar)
        {
            ishopcar.RemoveRangeShopCar(shopcar);
        }

        public void AddShopCar(ShopCar shopcar)
        {
            ishopcar.AddShopCar(shopcar);
        }
    }
}
