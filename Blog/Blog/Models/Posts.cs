using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models
{
    [Table(name: "Posts")]
    public class Posts
    {
        [Key]
        public int PostID { get; set; }
        [Display(Name ="Title"),StringLength(50)]
        [Required(ErrorMessage ="Please Enter The Title")]
        public string Title { get; set; }
        [Display(Name = "Author"), StringLength(50)]
        [Required(ErrorMessage = "Please Enter The Author")]
        public string Author { get; set; }
        [Display(Name = "Post"), StringLength(5000)]
        [Required(ErrorMessage = "Please Enter The Post")]
        public string PostBody { get; set; }
        public DateTime PostDate { get; set; }
        
    }
}