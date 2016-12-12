using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace myBlog.Models
{
    public class BlogContext: DbContext
    {
        public DbSet<Admin> TheAdmin { get; set; }

        public DbSet<Blog> myBlog { get; set; }
        public DbSet<Post> myPosts { get; set; }

        public DbSet<Users> TheUsers { get; set; }
        public DbSet<Users_Comments> UsersComments { get; set; }
    }
}