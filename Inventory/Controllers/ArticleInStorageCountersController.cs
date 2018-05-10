using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Inventory.Models;
using Inventory.Persistence;

namespace Inventory.Controllers
{
    public class ArticleInStorageCountersController : Controller
    {
        private InventoryContext db = new InventoryContext();

        // GET: ArticleInStorageCounters
        public ActionResult Index()
        {
            var articleInStorageCounters = db.ArticleInStorageCounters.Include(a => a.Articles).Include(a => a.WareHouses);
            return View(articleInStorageCounters.ToList());
        }

        // GET: ArticleInStorageCounters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticleInStorageCounter articleInStorageCounter = db.ArticleInStorageCounters.Find(id);
            articleInStorageCounter.Articles = db.Articles.Find(articleInStorageCounter.ArticleID);
            articleInStorageCounter.WareHouses = db.WareHouses.Find(articleInStorageCounter.WareHouseID);

            if (articleInStorageCounter == null)
            {
                return HttpNotFound();
            }
            return View(articleInStorageCounter);
        }

        // GET: ArticleInStorageCounters/Create
        public ActionResult Create()
        {
            ViewBag.ArticleID = new SelectList(db.Articles, "ID", "Name");
            ViewBag.WareHouseID = new SelectList(db.WareHouses, "ID", "Name");
            return View();
        }

        // POST: ArticleInStorageCounters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ArticleCounter,ArticleID,WareHouseID")] ArticleInStorageCounter articleInStorageCounter)
        {
            if (ModelState.IsValid)
            {
                db.ArticleInStorageCounters.Add(articleInStorageCounter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArticleID = new SelectList(db.Articles, "ID", "Name", articleInStorageCounter.ArticleID);
            ViewBag.WareHouseID = new SelectList(db.WareHouses, "ID", "Name", articleInStorageCounter.WareHouseID);
            return View(articleInStorageCounter);
        }

        // GET: ArticleInStorageCounters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticleInStorageCounter articleInStorageCounter = db.ArticleInStorageCounters.Find(id);
            if (articleInStorageCounter == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArticleID = new SelectList(db.Articles, "ID", "Name", articleInStorageCounter.ArticleID);
            ViewBag.WareHouseID = new SelectList(db.WareHouses, "ID", "Name", articleInStorageCounter.WareHouseID);
            return View(articleInStorageCounter);
        }

        // POST: ArticleInStorageCounters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ArticleCounter,ArticleID,WareHouseID")] ArticleInStorageCounter articleInStorageCounter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(articleInStorageCounter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArticleID = new SelectList(db.Articles, "ID", "Name", articleInStorageCounter.ArticleID);
            ViewBag.WareHouseID = new SelectList(db.WareHouses, "ID", "Name", articleInStorageCounter.WareHouseID);
            return View(articleInStorageCounter);
        }

        // GET: ArticleInStorageCounters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticleInStorageCounter articleInStorageCounter = db.ArticleInStorageCounters.Find(id);
            if (articleInStorageCounter == null)
            {
                return HttpNotFound();
            }
            return View(articleInStorageCounter);
        }

        // POST: ArticleInStorageCounters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ArticleInStorageCounter articleInStorageCounter = db.ArticleInStorageCounters.Find(id);
            db.ArticleInStorageCounters.Remove(articleInStorageCounter);
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
