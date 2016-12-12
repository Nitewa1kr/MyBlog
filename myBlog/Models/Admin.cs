using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myBlog.Models
{
    [Table("Admin")]
    public class Admin
    {
        public int AdminID { get; set; }
        //THE THE NAME OF THE ADMIN IS ONLY ONE,
        //THERE SHOULD BE NO FIELD FOR IT.
        public string AdminHandle { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        
        public DateTime DatePosted { get; set; }

        public int BlogID { get; set; }
        public virtual List<Blog> Blog { get; set; }
        
    }
}