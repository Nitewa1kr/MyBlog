using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myPersonalBlog.Core.Objects
{
    [Table("AdminTbl")]
    public class Admin
    {
        [Key]
        public virtual int ID { get; set; }
        [Required]
        [MaxLength(20)]
        public virtual string NAME { get; set; }
        [Required]
        [MaxLength(20)]
        public virtual string PASSWORD { get; set; }
    }
}
