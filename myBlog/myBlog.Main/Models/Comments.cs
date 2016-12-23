using System;
using System.Collections.Generic;

namespace myBlog.Main.Models
{
    public class Comments
    {
        public virtual int ID { get; set; }
        public virtual string UserName { get; set; }
        public virtual string CommentBody { get; set; }
        public virtual string CommentDate { get; set; }

        public virtual IList<Posts> Posts { get; set; }
    }
}