using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myBlog.Models
{
    [Table("Users")]
    public class Users
    {
        [Key]
        public int UserID { get; set; }
        //work on displaying user handle appropriately
        [Required]
        public string User_Handle { get; set; }
        //work on encrypting the password appropriately
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [Required]
        [ForeignKey("FK_POST_FOR_USER")]
        public string PostID { get; set; }

        public DateTime JoinDate { get; set; }
        public virtual IEnumerable<Users_Comments> Comments { get; set; }
    }
}