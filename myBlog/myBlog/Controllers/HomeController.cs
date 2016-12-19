using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using myBlog.Models;

namespace myBlog.Controllers
{
    public class HomeController : Controller
    {
        public myBlogEntities db = new myBlogEntities();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetPosts(int? id)
        {
                var posts = id.HasValue ? db.Posts.Where(x => x.POST_ID == id).First() : new Post() { POST_ID = -1 };
                return Json(posts, JsonRequestBehavior.AllowGet);
        }
        public JsonResult addPost(int? id, string title, string Post_Body, string Author, DateTime dateTime, string tags)
        {
            if (!IsAdmin)
            {
                return Json("Index");
            }
            Post post = GetPosts(id);
            post.TITLE = title;
            post.POST_BODY = Post_Body;
            post.POST_AUTHOR = Author;
            post.P_DATE_TIME = dateTime;

            post.Tags.Clear();
            tags = tags ?? string.Empty;
            string[] tagNames = tags.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach(string tagName in tagNames)
            {
                post.Tags.Add(GetTag(tagName));
            }

        }

        private Tag GetTag(string tagName)
        {
            return db.Tags.Where(x => x.TAG_NAME == tagName).FirstOrDefault() ?? new Tag() { TAG_NAME = tagName };
        }

        //TODO: DO NOT RETURN TRUE
        public bool IsAdmin { get { return true; } }// { return Session["IsAdmin"] != null && (bool)Session["IsAdmin"]; } }
    }
}