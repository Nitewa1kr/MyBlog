using myPersonalBlog.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace myPersonalBlog.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogRepo blogRepository;
        public int PageSize = 4;
        
        public BlogController(IBlogRepo blogRepo)
        {
            blogRepository = blogRepo;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ViewResult GetPosts(int page = 1)
        {
            return View(blogRepository.Posts
                .OrderByDescending(p => p.Post_Date)
                .Skip((page -1) * PageSize)
                .Take(PageSize)
                
                );
        }
    }
}