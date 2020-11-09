using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.ASP.models;

namespace Web.ASP.Controllers
{
    public class CategoryController : Controller
    {
        private BookStoreNewEntities db = new BookStoreNewEntities();
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }
        // Single Book
        public ActionResult SingleBook(String _id)
        {
            var db = new BookStoreNewEntities();
            ViewBag.book = db.BOOKs.Find(_id);
            return View();
        }
        // Cart
        public ActionResult Cart()
        {
            return View();
        }
        // Confirmation
        public ActionResult Confirmation()
        {
            return View();
        }
        // Checkout
        public ActionResult Checkout()
        {
            return View();
        }
        // Tracking
        public ActionResult Tracking()
        {
            return View();
        }
        // Add Cart
        public ActionResult AddCart()
        {
            
                ViewBag.categoryBook = new SelectList(db.CATEGORies, "C_id", "nameCategory");
                //viewBag.discountBook_ID = new SelectList(db.DISCOUNT_BOOK, "C_id", "C_id");
                ViewBag.publishingHouseBook = new SelectList(db.PUBLISHING_HOUSE, "C_id", "namePublishingHouse");
                return View();
        }
        [HttpPost]
        public ActionResult AddCart(BOOK model)
        {

            ViewBag.categoryBook = new SelectList(db.CATEGORies, "C_id", "nameCategory");
            //viewBag.discountBook_ID = new SelectList(db.DISCOUNT_BOOK, "C_id", "C_id");
            ViewBag.publishingHouseBook = new SelectList(db.PUBLISHING_HOUSE, "C_id", "namePublishingHouse");
            return View();
        }
    }
}