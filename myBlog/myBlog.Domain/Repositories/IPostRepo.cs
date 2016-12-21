using myBlog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myBlog.Domain.Repositories
{
    public interface IPostRepo
    {
        IEnumerable<Post> Posts { get; }
    }
}
