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
    public class SqlOrderDetails:IOrdersDetails
    {
        XueHaiEntities db = DbContextFactory.CreateDbContext();
        public IEnumerable<OrderDetails> GetOrdersDetails()
        {
            var ordersds = db.OrderDetails.ToList();
            return ordersds;
        }
        public OrderDetails GetOrdersDetailsById(int? id)
        {
            OrderDetails ordersd = db.OrderDetails.Find(id);
            return ordersd;
        }
        //public IQueryable<View_OrderDetails> FindviewodById(string uid)
        //{
        //    var viewordersd = db.View_OrderDetails.Where(c => c.Users_id == uid);
        //    return viewordersd;
        //}
        public void RemoveOrdersDetails(OrderDetails ordersd)
        {
            db.OrderDetails.Remove(ordersd);
            db.SaveChanges();
        }
    }
}
