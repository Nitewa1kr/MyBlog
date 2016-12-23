using myPersonalBlog.Core.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myPersonalBlog.Core.IRepositories
{
    public interface IBlogRepo
    {
        //todo: determine if they needed to be set
        IEnumerable<Posts> Posts { get; }
        IEnumerable<Comments> Comments { get; }
    }
}
