//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class View_OrderDetails
    {
        public int OrderDetails { get; set; }
        public int Orders_id { get; set; }
        public int Goods_id { get; set; }
        public Nullable<decimal> Sum { get; set; }
        public System.DateTime OrderTime { get; set; }
        public string UserName { get; set; }
        public string UserPhone { get; set; }
        public string Address { get; set; }
        public string note { get; set; }
        public string GoodsName { get; set; }
        public string GoodsImage { get; set; }
        public Nullable<int> Count { get; set; }
        public Nullable<decimal> Price { get; set; }
        public int Users_id { get; set; }
    }
}
