using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using myBlog.Models;
using System.Text;

namespace myBlog.Controllers
{
    public class HomeController : Controller
    {
       // private myBlogEntities db = new myBlogEntities();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult addPost(int? id, string title, string Post_Body, string Author, DateTime dateTime, string tags)
        {
            using (var db = new myBlogEntities())
            {
                if (!IsAdmin)
                {
                    return RedirectToAction("Index");
                }
                Post post = GetPost(id);
                post.TITLE = title;
                post.POST_BODY = Post_Body;
                post.POST_AUTHOR = Author;
                post.P_DATE_TIME = dateTime;

                post.Tags.Clear();
                tags = tags ?? string.Empty;
                string[] tagNames = tags.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string tagName in tagNames)
                {
                    post.Tags.Add(GetTag(tagName));
                }
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
            Post post = GetPost(id);
            StringBuilder tagList = new StringBuilder();
            foreach(Tag tag in post.Tags)
            {
                tagList.AppendFormat("{0}", tag.TAG_NAME);
            }
            ViewBag.Tags = tagList.ToString();
            return View(post);
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