using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myBlog.Main.Models
{
    public class Tags
    {
        public virtual int ID { get; set; }
        public virtual int TagName { get; set; }

        public virtual IList<Posts> Posts { get; set; }
    }
}