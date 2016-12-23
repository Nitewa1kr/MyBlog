using myBlog.Main.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace myBlog.Main.DBContext
{
    public class myBlogDBContext : DbContext
    {
        DbSet<Posts> Post { get; set; }
        DbSet<Tags> Tag { get; set; }
        DbSet<Comments> Comment { get; set; }
        DbSet<Admin> Admin { get; set; }
    }
}