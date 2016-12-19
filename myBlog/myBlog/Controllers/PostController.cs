using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myBlog.Models;

namespace myBlog.Controllers
{
    public class PostController : Controller
    {
        // GET: Post
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetPosts()
        {
            using (var db = new myBlogEntities())
            {
                var posts = db.Posts.ToList();
                return Json(posts, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult addPost(string title, string Post_Body, string Author, DateTime dateTime, string tags)
        {
            using (var db = new myBlogEntities())
            {
                if (!IsAdmin)
                {
                    return Json("Index");
                }
                db.Posts.Add(new Post()
                {
                    TITLE = title,
                    POST_BODY = Post_Body,
                    POST_AUTHOR = Author,
                    //Tags = tags,
                    P_DATE_TIME = dateTime
                });
                db.SaveChanges();
                var posts = db.Posts.ToList();
                return Json(posts, JsonRequestBehavior.AllowGet);

            }

        }

        private Post GetPost(int? id)
        {
            using (var db = new myBlogEntities())
            {
                return id.HasValue ? db.Posts.Where(x => x.POST_ID == id).First() : new Post() { POST_ID = -1 };
            }
        }

        private Tag GetTag(string tagName)
        {
            using (var db = new myBlogEntities())
            {
                return db.Tags.Where(x => x.TAG_NAME == tagName).FirstOrDefault() ?? new Tag() { TAG_NAME = tagName };
            }
        }

        //TODO: DO NOT RETURN TRUE
        public bool IsAdmin { get { return true; } }// { return Session["IsAdmin"] != null && (bool)Session["IsAdmin"]; } }
    }
}