using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Inventory.Models;
using Inventory.Persistence;

namespace Inventory.Controllers
{
    public class ArticlesController : Controller
    {
        private InventoryContext db = new InventoryContext();

        // GET: Articles
        public ActionResult Index()
        {
            var articles = db.Articles.Include(a => a.Categories);
            return View(articles.ToList());
        }

        // GET: Articles/Search
        public ActionResult Search(int id, string searchstring)
        {
            var storedArticles = from e in db.ArticleInStorageCounters
                                 where e.WareHouseID.Equals(id)
                                 where e.Articles.Name.Contains(searchstring)
                                 select e.Articles;
           
            return View(storedArticles.ToList());
        }

        // GET: Articles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        public FileContentResult GetImage(int itemId)
        {
            Article article = db.Articles.FirstOrDefault(u => u.ID.Equals(itemId));
            if (article != null)
                return File(article.PhotographyOfArticle, "image/png");
            else return null;
        }

        // GET: Articles/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "ID", "Name");
            return View();
        }

        // POST: Articles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,PhotographyOfArticle,MemeType,TextField,CategoryId")] Article article)
        {
            //string base64string = Convert.ToBase64String(article.PhotographyOfArticle);
            //Dodato je: article.PhotographyOfArticle != null && article.PhotographyOfArticle.Length > 0
            if (ModelState.IsValid && article.PhotographyOfArticle != null && article.PhotographyOfArticle.Length > 0)
            {
                
                //     var PhotographyOfArticle = Path.GetFileName(article.PhotographyOfArticle.ToList<byte>);
                //     var path = Path.Combine(Server.MapPath("Inventory.Maps"), PhotographyOfArticle);
                //     article.PhotographyOfArticle.SaveAs(path);
            
                db.Articles.Add(article);
                db.SaveChanges();
                return RedirectToAction("Index");
            }           
            
            ViewBag.CategoryId = new SelectList(db.Categories, "ID", "Name", article.CategoryId);
            return View(article);
                      
    }

        // GET: Articles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "ID", "Name", article.CategoryId);
            return View(article);
        }

        // POST: Articles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,PhotographyOfArticle,TextField,CategoryId")] Article article)
        {
            if (ModelState.IsValid)
            {
                db.Entry(article).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "ID", "Name", article.CategoryId);
            return View(article);
        }

        // GET: Articles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Article article = db.Articles.Find(id);
            db.Articles.Remove(article);
            db.SaveChanges();
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
