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
    
    public partial class Post
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Post()
        {
            this.Comments = new HashSet<Comments>();
        }
    
        public int Post_id { get; set; }
        public string PostTitle { get; set; }
        public Nullable<System.DateTime> AddTime { get; set; }
        public int Users_id { get; set; }
        public string PostDetails { get; set; }
        public int LunTan_id { get; set; }
        public string PostImage { get; set; }
        public Nullable<int> Post_top { get; set; }
        public string PostJianjie { get; set; }
        public Nullable<int> Post_down { get; set; }
        public Nullable<int> Post_upvote { get; set; }
        public Nullable<int> Post_click { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comments> Comments { get; set; }
        public virtual LunTan LunTan { get; set; }
        public virtual UserInfo UserInfo { get; set; }
    }
}