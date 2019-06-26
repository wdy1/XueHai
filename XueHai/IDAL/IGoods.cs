using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    public interface  IGoods
    {
        IEnumerable<Goods> GetGoods();
        Goods GetGoodsById(int? id);
        IQueryable<Goods> whereGoodsById(int id);
        IEnumerable<Goods> whereGoodsBykId(int id);
        IQueryable<Goods> GetGoodsbyTop(int top);
        //IEnumerable<Goods> GetbyTopandGoodskId(int top, int kid);
        //IEnumerable<Goods> GetbyTopandGoodskId();
        IQueryable<ShopCar> GetShopCarByGoodsId(int id);
        IQueryable<OrderDetails> GetOrdersByGoodsId(int id);
        void RemoveGoods(Goods goods);
        void AddGoods(Goods goods);
        void EditGoods(Goods goods);
        IEnumerable<Goods> Search(string search);
        void RemoveRangeShopCar(IQueryable<ShopCar> shopcar);
        void RemoveRangeOrders(IQueryable<OrderDetails> orderdetail);
    
}
}
