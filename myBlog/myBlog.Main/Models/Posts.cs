using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace myBlog.Main.Models
{
    public class Posts
    {
        [Key]
        public virtual int ID { get; set; }
        [MaxLength(25)]
        public virtual int Title { get; set; }
        [MaxLength(25)]
        public virtual int Author { get; set; }
        [MaxLength(5000)]
        public virtual int PostBody { get; set; }
        public virtual DateTime PostDate { get; set; }

        [ForeignKey]
        public virtual IList<Tags> Tags { get; set; }
        public virtual Comments Comments { get; set; }
    }
}