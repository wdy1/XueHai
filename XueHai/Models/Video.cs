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
    
    public partial class Video
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Video()
        {
            this.Comments = new HashSet<Comments>();
            this.FavoriteVideo = new HashSet<FavoriteVideo>();
        }
    
        public int Video_id { get; set; }
        public string VideoName { get; set; }
        public string Cover { get; set; }
        public string VideoJishu { get; set; }
        public Nullable<System.DateTime> AddTime { get; set; }
        public string VideoURL { get; set; }
        public int VideoK_id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comments> Comments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FavoriteVideo> FavoriteVideo { get; set; }
        public virtual VideoK VideoK { get; set; }
    }
}
