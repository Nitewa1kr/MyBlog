using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using myBlog.Domain.Repositories;

namespace myBlogMain.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostRepo repo;

        public HomeController(IPostRepo PostRepo)
        {
            repo = PostRepo;
        }
        public ViewResult Posts()
        {
                //YOU HAVE TO RETURN SOMETHING IN THE VIEW
                return View(repo.Posts);
        }
        
    }
}