using PagedList;
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
        private Manager_BookEntities db = new Manager_BookEntities();
        // GET: Category
        public ActionResult Index(int? page,string? categoryID)
        {
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            ViewBag.categoryBook = new SelectList(db.CATEGORies, "C_id", "nameCategory");
            string category = (categoryID ?? "");
            return View(db.BOOKs.Where(b=>b.categoryBook_ID.Contains(category)).OrderBy(x=>x.C_id).ToPagedList(pageNumber,pageSize));
          
        }
        // Single Book
        public ActionResult SingleBook(String _id)
        {
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
            ViewBag.publishingHouseBook = new SelectList(db.PUBLISHING_HOUSE.Take(10), "C_id", "namePublishingHouse");
            return View();
        }
        public ActionResult AddCategory()
        {
            return View();
        }
    }
}