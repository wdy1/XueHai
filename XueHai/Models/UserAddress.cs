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
    
    public partial class UserAddress
    {
        public int UserAddress_id { get; set; }
        public int Users_id { get; set; }
        public string Address { get; set; }
    
        public virtual UserInfo UserInfo { get; set; }
    }
}
