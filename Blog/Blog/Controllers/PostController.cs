using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

using Blog.DAL;
using Blog.Models;
using PagedList;
using System.Data.Entity.Infrastructure;

namespace Blog.Controllers
{
    public class PostController : Controller
    {
        private BlogDBContext db = new BlogDBContext();
        
        public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? page, int? postsID, int? commentID)
        {
           
            ViewBag.CurrentSort = sortOrder;
            ViewBag.SortByDate = sortOrder == "Date" ? "ByPostDate" : "Date";

            if(searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;

            var posts = from p in db.Post where p.PostDate < DateTime.Now orderby p.PostDate descending select p;
            
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(posts.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Posts posts = db.Post.Find(id);
            if (posts == null)
            {
                return HttpNotFound();
            }
            return View(posts);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title,Author,PostBody")] Posts posts)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    posts.PostDate = DateTime.Now;
                    db.Post.Add(posts);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch(RetryLimitExceededException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again");
            }

            return View(posts);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Posts posts = db.Post.Find(id);
            if (posts == null)
            {
                return HttpNotFound();
            }
            return View(posts);
        }

       
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var postToUpdate = db.Post.Find(id);
            if(TryUpdateModel(postToUpdate, "",
                new string[] { "Title","Author","PostBody" }))
            try
            {
                    
                        postToUpdate.PostDate = DateTime.Now;
                        db.SaveChanges();
                    
                    return RedirectToAction("Index");
            }
            catch(RetryLimitExceededException)
            {
                ModelState.AddModelError("", "Unable to Save Changes. Try again.");
            }
            return View(postToUpdate);
        }

        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Posts posts = db.Post.Find(id);
            if (posts == null)
            {
                return HttpNotFound();
            }
            return View(posts);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                    Posts posts = db.Post.Find(id);
                    db.Post.Remove(posts);
                    db.SaveChanges();
            }
            catch (RetryLimitExceededException)
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }
               
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
