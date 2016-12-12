using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myBlog.Models
{
    [Table("Posts")]
    public class Post
    {
        [Key]
        public int PostID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        [ForeignKey("FK_Blog_ID_For_Posts")]
        public int BlogID { get; set; }
        public virtual Blog Blog { get; set; }
    }
}