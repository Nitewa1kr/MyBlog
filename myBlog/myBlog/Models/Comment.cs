//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace myBlog.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Comment
    {
        public int COMMENT_ID { get; set; }
        public string USERNAME { get; set; }
        public string USER_EMAIL { get; set; }
        public string COMMENT_BODY { get; set; }
        public Nullable<System.DateTime> C_DATE_TIME { get; set; }
        public int C_POST_ID { get; set; }
    
        public virtual Post Post { get; set; }
    }
}
