using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    public interface  IOrders
    {
        IEnumerable<Orders> GetOrders();
        Orders GetOrdersById(int? id);
        void RemoveOrders(Orders orders);
        void EditOrders(Orders orders);
        void Goumai(int uid, string uname, string userphone, string address, string note);
        //void Goumai(int uid, string uname, string userphone, string address, string note, DateTime ordertime);
    }
}
