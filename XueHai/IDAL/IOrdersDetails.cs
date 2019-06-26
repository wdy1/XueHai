using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    public interface IOrdersDetails
    {
        IEnumerable<OrderDetails> GetOrdersDetails();
        OrderDetails GetOrdersDetailsById(int? id);
        void RemoveOrdersDetails(OrderDetails ordersdetails);
        //IQueryable<View_OrderDetails> FindviewodById(string uid);
    }
}
