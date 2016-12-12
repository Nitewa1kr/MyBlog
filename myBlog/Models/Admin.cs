using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations.Schema;

namespace myBlog.Models
{
    [Table("Admin")]
    public class Admin
    {
        public int AdminID { get; set; }
        public string AdminHandle { get; set; }
        public string Password { get; set; }
        //[NotMapped]
        
        public DateTime DatePosted { get; set; }

        public int BlogID { get; set; }
        public virtual List<Blog> Blog { get; set; }
        
    }
}