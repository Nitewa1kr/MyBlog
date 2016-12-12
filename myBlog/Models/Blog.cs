using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace myBlog.Models
{
    [Table("Blog")]
    public class Blog
    {
        public int BlogID { get; set; }
        public string Name { get; set; }

        public int AdminID { get; set; }
        public virtual List<Post> Posts { get; set; }
    }
}