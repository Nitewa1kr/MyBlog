using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace myBlog.Main.Models
{
    public class Admin
    {
        [Key]
        public virtual int ID { get; set; }
        [Required]
        [MaxLength(25)]
        public virtual string AdminName { get; set; }
        [Required]
        [MaxLength(25)]
        public virtual string Password { get; set; }
    }
}