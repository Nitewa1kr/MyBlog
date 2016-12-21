using myBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace myBlog.Controllers
{
    public class PostsController : Controller
    {
        public ActionResult Index()
        {
            using (var db = new myBlogEntities())
            {
                var post = db.Posts.ToList();
                ViewBag.IsAdmin = IsAdmin;
                return View(post);
            }
              
        }
        [ValidateInput(false)]
        public ActionResult Update(int? id, string title, string author, string body)
        {
            using (var db = new myBlogEntities())
            {
                //dateTime = DateTime.Now;
                if(!IsAdmin)
                {
                    return RedirectToAction("Index");
                }

                Post post = GetPost(id);
                post.TITLE = title;
                post.POST_AUTHOR = author;
                post.POST_BODY = body;
                post.P_DATE_TIME = DateTime.Now;
                
                if(!id.HasValue)
                {
                    db.Posts.Add(post);
                }
                db.SaveChanges();
                return RedirectToAction("Details", new { id = post.POST_ID });
            }
        }

        public ActionResult Edit(int? id)
        {
            using (var db = new myBlogEntities())
            {
                Post post = GetPost(id);
                return View(post);
            }
        }
        
        private Post GetPost(int? id)
        {
            using (var db = new myBlogEntities())
            {
                return id.HasValue ? db.Posts.Where(x => x.POST_ID == id).First() : new Post() { POST_ID = -1 };
            }
        }   
        public bool IsAdmin { get { return true; } }// { return Session["IsAdmin"] != null && (bool)Session["IsAdmin"]; } }

    }
}