using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Blog.Models;

namespace Blog.DAL
{
    public class BlogDBContext : DbContext
    {
        public BlogDBContext() : base("BlogDBContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Posts> Post { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            
        }
    }

}