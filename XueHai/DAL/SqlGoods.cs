using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDAL;
using System.Data.Entity;

namespace DAL
{
  public  class SqlGoods:IGoods
    {
        XueHaiEntities db= DbContextFactory.CreateDbContext();
        public IEnumerable<Goods> GetGoods()
        {
            var goodss = db.Goods.ToList();
            return goodss;
        }
        public Goods GetGoodsById(int? id)
        {
            Goods goods = db.Goods.Find(id);
            return goods;
        }
        public IQueryable<Goods> whereGoodsById(int id)
        {
            var goods = db.Goods.Where(c=>c.Goods_id==id);
            return goods;
        }
        public IEnumerable<Goods> whereGoodsBykId(int id)
        {
            var goods = db.Goods.Where(c => c.GoodsK_id == id).ToList();
            return goods;
        }
        public IQueryable<Goods> GetGoodsbyTop(int top)
        {
            //var goods = db.Goods.OrderBy(c => c.Goods_id).Take(top);
            var goods = from gs in db.Goods
                        orderby gs.Goods_id descending
                        select gs;
            return goods.Take(top);
        }
        //public IEnumerable<Goods> GetbyTopandGoodskId(int top, int kid)
        ////public IEnumerable<Goods> GetbyTopandGoodskId()
        //{
        //    var goods = from gs in db.Goods
        //                where gs.GoodsK_id.StartsWith(kid)
        //                orderby gs.Goods_id descending
        //                select gs;
        //    //var goods = db.Goods.Where(c => c.GoodsK_id.StartsWith("kid")).OrderBy(c => c.Goods_id).Take(top);
        //    return goods.Take(top);
        //}
        public IQueryable<ShopCar> GetShopCarByGoodsId(int id)
        {
            var ShopCar = db.ShopCar.Include("Goods").Where(c => c.Goods_id == id);
            return ShopCar;
        }
        public IQueryable<OrderDetails> GetOrdersByGoodsId(int id)
        {
            var Orders = db.OrderDetails.Include("Goods").Where(o => o.Goods_id == id);
            return Orders;
        }
        public void RemoveGoods(Goods goods)
        {
            db.Goods.Remove(goods);
            db.SaveChanges();
        }
        public void AddGoods(Goods goods)
        {
            db.Goods.Add(goods);
            db.SaveChanges();
        }
        public void EditGoods(Goods goods)
        {
            db.Entry(goods).State = EntityState.Modified;
            db.SaveChanges();
        }
        public IEnumerable<Goods> Search(string search)
        {
            //var goods2 = from gs in db.Goods
            //            where gs.GoodsJianjie.Contains(search)
            //            select gs;
            //var goods1 = from gs in db.Goods
            //            where gs.GoodsName.Contains(search)
            //            select gs;
            //var goods = goods2 and goods1;
            var goods = db.Goods.Where(c => c.GoodsJianjie.Contains(search)).ToList();
            return goods;
        }
        public void RemoveRangeShopCar(IQueryable<ShopCar> shopcar)
        {
            db.ShopCar.RemoveRange(shopcar);
        }
        public void RemoveRangeOrders(IQueryable<OrderDetails> orderdetail)
        {
            db.OrderDetails.RemoveRange(orderdetail);
        }
    }
}
