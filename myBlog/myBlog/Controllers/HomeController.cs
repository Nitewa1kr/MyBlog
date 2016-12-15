
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myBlog.Models;
using myBlog.ViewModel;
using myBlog.PasswordHelper;

namespace myBlog.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            using (myBlogEntities be = new myBlogEntities())
            {
                AdminViewModel adminViewModel = new AdminViewModel();
                adminViewModel.Admin = new Admin();
                return View("Index", adminViewModel);
            }
        }

        public ActionResult Register(AdminViewModel adminViewModel)
        {
            using (myBlogEntities be = new myBlogEntities())
            {
                adminViewModel.Admin.ADMIN_PASSWORD = 
                be.Admins.Add(adminViewModel.Admin);
                return View("Login");
            }
        }
    }
}