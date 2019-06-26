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
    
    public partial class Comments
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Comments()
        {
            this.Reply = new HashSet<Reply>();
            this.Praised = new HashSet<Praised>();
        }
    
        public int ComID { get; set; }
        public int Users_id { get; set; }
        public Nullable<int> Goods_id { get; set; }
        public Nullable<int> Post_id { get; set; }
        public Nullable<int> Video_id { get; set; }
        public string ComContent { get; set; }
        public System.DateTime ComTime { get; set; }
        public int PaiseNum { get; set; }
    
        public virtual Goods Goods { get; set; }
        public virtual Post Post { get; set; }
        public virtual UserInfo UserInfo { get; set; }
        public virtual Video Video { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reply> Reply { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Praised> Praised { get; set; }
    }
}
