using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myPersonalBlog.Core.Objects
{
    [Table("Posts")]
    public class Posts
    {
        [Key]
        public virtual int ID { get; set; }
        [MaxLength(50)]
        public virtual string Title { get; set; }
        [MaxLength(50)]
        public virtual string Author { get; set; }
        [MaxLength(5000)]
        public virtual string Post_Body { get; set; }
        public virtual DateTime Post_Date { get; set; }

        [ForeignKey("CommentId")]//reference to Comment ID
        public virtual Comments Comments { get; set; } //ONE TO MANY ; ONE POST TO MANY COMMENTS
    }
}
