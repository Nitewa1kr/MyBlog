using MyNewBlog.Controllers;
using MyNewBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyNewBlog.Controllers
{
    public class CommentController : Controller
    {
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
    }
}