using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myBlog.Domain.Entities
{
    public class Post
    {
        public int POST_ID { get; set; }
        public string TITLE { get; set; }
        public string POST_BODY { get; set; }
        public string POST_AUTHOR { get; set; }
        public DateTime P_DATE_TIME { get; set; }
    }
}
