using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace myBlog.Models
{
    public class Users_Comments
    {
        [Key]
        public int CommentID { get; set; }
        //REQUIRED
        public string Comment { get; set; }

        [Required]
        [ForeignKey("FK_Blog_ID")]
        public int BlogID { get; set; }
        [Required]
        [ForeignKey("FK_Post_ID")]
        public int PostID { get; set; }
        [Required]
        [ForeignKey("FK_User_ID")]
        public int UserID { get; set; }

        public virtual Users Users { get; set; }
    }
}