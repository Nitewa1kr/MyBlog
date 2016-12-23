using myPersonalBlog.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using myPersonalBlog.Core.Objects;

namespace myPersonalBlog.Core.EFDbContexts
{
    public class BlogRepo : IBlogRepo
    {
        private readonly myBlogDBContext context = new myBlogDBContext();
        public IEnumerable<Posts> Posts
        {
            get { return context.Posts; }
        }
        public IEnumerable<Comments> Comments
        {
            get { return context.Comments; }
        }
    }
}
