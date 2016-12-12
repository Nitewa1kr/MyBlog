using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myBlog.Models
{
    [Table("Blog")]
    public class Blog
    {
        [Key]
        public int BlogID { get; set; }
        public string Name { get; set; }
        //Date WIP??
        public DateTime BlogDate { get; set; }

        [ForeignKey("FK_Admin_for_blog")]
        public int AdminID { get; set; }
        public virtual List<Post> Posts { get; set; }
    }
}