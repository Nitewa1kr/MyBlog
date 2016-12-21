using MyNewBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using MyNewBlog.Controllers;

namespace myBlog.Controllers
{
    public class PostsController : Controller
    {
        private const int PostsPerPage = 4;

        public ActionResult Index(int? id)
        {
            using (var db = new myBlogEntities())
            {

                int pageNumber = id ?? 0;
                var posts = db.Posts.ToList().Skip(pageNumber * PostsPerPage).Take(PostsPerPage + 1);
                ViewBag.IsPreviousLinkVisible = pageNumber > 0;
                ViewBag.IsNextLinkVisible = posts.Count() > PostsPerPage;
                ViewBag.PageNumber = pageNumber;
                ViewBag.IsAdmin = IsAdmin;
                return View(posts.Take(PostsPerPage));
            }

        }

        internal static void GetPost(int id)
        {
            throw new NotImplementedException();
        }

        public ActionResult Details(int id)
        {
            using (var db = new myBlogEntities())
            {
                Post post = GetPost(id);
                ViewBag.IsAdmin = IsAdmin;
                return View(post);
            }
        }

        [ValidateInput(false)]
        public ActionResult Comment(int id, string name, string email, string body)
        {
            using (var db = new myBlogEntities())
            {
                Post post = GetPost(id);
                Comment comment = new Comment();
                comment.Post = post;
                comment.C_DATE_TIME = DateTime.Now;
                comment.USER_EMAIL = email;
                comment.COMMENT_BODY = body;
                db.Comments.Add(comment);
                db.SaveChanges();

                return RedirectToAction("Details", new { id = id });
            }
        }

        [ValidateInput(false)]
        public ActionResult Update(int? id, string title, string author, string body)
        {
            using (var db = new myBlogEntities())
            {
                //dateTime = DateTime.Now;
                if (!IsAdmin)
                {
                    return RedirectToAction("Index");
                }

                Post post = GetPost(id);
                post.TITLE = title;
                post.POST_AUTHOR = author;
                post.POST_BODY = body;
                post.P_DATE_TIME = DateTime.Now;

                if (!id.HasValue)
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