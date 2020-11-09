using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Web.ASP.models;

namespace Web.ASP.Controllers
{
    public class BOOKsController : Controller
    {
        private BookStoreNewEntities db = new BookStoreNewEntities();

        // GET: BOOKs
        public ActionResult Index()
        {
            var bOOKs = db.BOOKs.Include(b => b.CATEGORY).Include(b => b.DISCOUNT_BOOK).Include(b => b.PUBLISHING_HOUSE);
            return View(bOOKs.ToList());
        }

        // GET: BOOKs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BOOK bOOK = db.BOOKs.Find(id);
            if (bOOK == null)
            {
                return HttpNotFound();
            }
            return View(bOOK);
        }

        // GET: BOOKs/Create
        public ActionResult Create()
        {
            ViewBag.categoryBook_ID = new SelectList(db.CATEGORies, "C_id", "nameCategory");
            ViewBag.discountBook_ID = new SelectList(db.DISCOUNT_BOOK, "C_id", "C_id");
            ViewBag.publishingHouseBook_ID = new SelectList(db.PUBLISHING_HOUSE, "C_id", "namePublishingHouse");
            return View();
        }

        // POST: BOOKs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "C_id,nameBook,priceBook,contentBook,countBook,imgBook_ID,categoryBook_ID,discountBook_ID,publishingHouseBook_ID")] BOOK bOOK)
        {
            if (ModelState.IsValid)
            {
                db.BOOKs.Add(bOOK);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.categoryBook_ID = new SelectList(db.CATEGORies, "C_id", "nameCategory", bOOK.categoryBook_ID);
            ViewBag.discountBook_ID = new SelectList(db.DISCOUNT_BOOK, "C_id", "C_id", bOOK.discountBook_ID);
            ViewBag.publishingHouseBook_ID = new SelectList(db.PUBLISHING_HOUSE, "C_id", "namePublishingHouse", bOOK.publishingHouseBook_ID);
            return View(bOOK);
        }

        // GET: BOOKs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BOOK bOOK = db.BOOKs.Find(id);
            if (bOOK == null)
            {
                return HttpNotFound();
            }
            ViewBag.categoryBook_ID = new SelectList(db.CATEGORies, "C_id", "nameCategory", bOOK.categoryBook_ID);
            ViewBag.discountBook_ID = new SelectList(db.DISCOUNT_BOOK, "C_id", "C_id", bOOK.discountBook_ID);
            ViewBag.publishingHouseBook_ID = new SelectList(db.PUBLISHING_HOUSE, "C_id", "namePublishingHouse", bOOK.publishingHouseBook_ID);
            return View(bOOK);
        }

        // POST: BOOKs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "C_id,nameBook,priceBook,contentBook,countBook,imgBook_ID,categoryBook_ID,discountBook_ID,publishingHouseBook_ID")] BOOK bOOK)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bOOK).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.categoryBook_ID = new SelectList(db.CATEGORies, "C_id", "nameCategory", bOOK.categoryBook_ID);
            ViewBag.discountBook_ID = new SelectList(db.DISCOUNT_BOOK, "C_id", "C_id", bOOK.discountBook_ID);
            ViewBag.publishingHouseBook_ID = new SelectList(db.PUBLISHING_HOUSE, "C_id", "namePublishingHouse", bOOK.publishingHouseBook_ID);
            return View(bOOK);
        }

        // GET: BOOKs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BOOK bOOK = db.BOOKs.Find(id);
            if (bOOK == null)
            {
                return HttpNotFound();
            }
            return View(bOOK);
        }

        // POST: BOOKs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            BOOK bOOK = db.BOOKs.Find(id);
            db.BOOKs.Remove(bOOK);
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
