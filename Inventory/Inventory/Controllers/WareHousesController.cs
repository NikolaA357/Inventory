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
    public class WareHousesController : Controller
    {
        private InventoryContext db = new InventoryContext();

        // GET: WareHouses
        public ActionResult Index()
        {
            var wareHouses = db.WareHouses.Include(w => w.Addresses);
            return View(wareHouses.ToList());
        }

        // GET: WareHouses/Details/5
        public ActionResult Details(int? id)//, string searchstring, string articlegen)
        {
            /*
            var warhaList = new List<String>();
            var warhaar = from e in db.Articles
                          orderby e.Name
                          select e.Name;
;
            warhaList.AddRange(warhaar.Distinct());
            ViewBag.articlegen = new SelectList(warhaList);

            var warehousearticle = from a in db.Articles
                                   select a;

            if (!String.IsNullOrEmpty(searchstring))
            {
                warehousearticle = warehousearticle.Where(s => s.Name.Contains(searchstring));
            }

            if (!string.IsNullOrEmpty(articlegen))
            {
                warehousearticle = warehousearticle.Where(x => x.Name.Equals(articlegen));
            }
            */
            WareHouse wareHouse;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            wareHouse = db.WareHouses.Find(id);

            if (wareHouse == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            wareHouse.Addresses = db.Addresses.Find(wareHouse.AddressId);

            if (wareHouse == null)
            {
                return HttpNotFound();
            }
            else
            {
                var counters = from c in db.ArticleInStorageCounters
                                select c;
                var list = db.ArticleInStorageCounters.Where(c => c.WareHouseID == id);
                if (list != null && list.Count() > 0)
                {
                    var counterObjects = list.ToList();
                    foreach (var item in list)
                    {
                        item.Articles = db.Articles.Find(item.ArticleID);
                    }

                    wareHouse.ArticleInStorageCounters = counterObjects;
                }
                else
                {
                    wareHouse.ArticleInStorageCounters = new List<ArticleInStorageCounter>();
                }
                return View(wareHouse);
            }
        }

        // GET: WareHouses/Create
        public ActionResult Create()
        {
            ViewBag.AddressId = new SelectList(db.Addresses, "ID", "StreetName");
            return View();
        }

        // POST: WareHouses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,SurfaceArea,Note,AddressId")] WareHouse wareHouse)
        {
            if (ModelState.IsValid)
            {
                db.WareHouses.Add(wareHouse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AddressId = new SelectList(db.Addresses, "ID", "StreetName", wareHouse.AddressId);
            return View(wareHouse);
        }

        // GET: WareHouses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WareHouse wareHouse = db.WareHouses.Find(id);
            if (wareHouse == null)
            {
                return HttpNotFound();
            }
            ViewBag.AddressId = new SelectList(db.Addresses, "ID", "StreetName", wareHouse.AddressId);
            return View(wareHouse);
        }

        // POST: WareHouses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,SurfaceArea,Note,AddressId")] WareHouse wareHouse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wareHouse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AddressId = new SelectList(db.Addresses, "ID", "StreetName", wareHouse.AddressId);
            return View(wareHouse);
        }

        // GET: WareHouses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WareHouse wareHouse = db.WareHouses.Find(id);
            if (wareHouse == null)
            {
                return HttpNotFound();
            }
            return View(wareHouse);
        }

        // POST: WareHouses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WareHouse wareHouse = db.WareHouses.Find(id);
            db.WareHouses.Remove(wareHouse);
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
