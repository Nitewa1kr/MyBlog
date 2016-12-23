using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myPersonalBlog.Core.Objects
{
    [Table("Comments")]
    public class Comments
    {
        [Key]
        public virtual int ID { get; set; }

        [MaxLength(50)]
        public virtual string UserName { get; set; }
        [MaxLength(5000)]
        public virtual string Comment_Body { get; set; }
        [ForeignKey("PostId")] //reference to Post ID
        public virtual IList<Posts> Posts { get; set; }
    }
}
