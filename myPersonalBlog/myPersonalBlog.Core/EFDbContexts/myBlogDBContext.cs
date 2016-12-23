using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using myPersonalBlog.Core.Objects;

namespace myPersonalBlog.Core.EFDbContexts
{
    public class myBlogDBContext : DbContext
    {
        public DbSet<Posts> Posts { get; set; }
        public DbSet<Comments> Comments { get; set; }
    }
}
