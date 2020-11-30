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
            ViewBag.publishingHouse = new SelectList(db.PUBLISHING_HOUSE, "C_id", "namePublishingHouse");
            string category = (categoryID ?? "");
            return View(db.BOOKs.Where(b=>b.categoryBook_ID.Contains(category)).OrderBy(x=>x.C_id).ToPagedList(pageNumber,pageSize));
          
        }
        public ActionResult loadData(string? categoryID,string? publishingHouseID, int? page)
        {
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            ViewBag.categoryBook = new SelectList(db.CATEGORies, "C_id", "nameCategory");
            string category = (categoryID ?? "");
            ViewBag.publishingHouse = new SelectList(db.PUBLISHING_HOUSE, "C_id", "namePublishingHouse");
            string publishingHouse = (publishingHouseID ?? "");

            var result = db.BOOKs.Where(b => b.categoryBook_ID.Contains(category) && b.publishingHouseBook_ID.Contains(publishingHouse)).OrderBy(x => x.C_id);
            return PartialView(result.ToPagedList(pageNumber, pageSize));

        }
        // Single Book
       
        public ActionResult SingleBook(String _id)
        {
            ViewBag.book = db.BOOKs.Find(_id);
            return View();
        }
        // Cart
        [isLoginController]
        public ActionResult Cart()
        {
            String id = Session["user"].ToString();
            var result = db.INFORMATION.Find(id).CARTs.ToList();
            return View(result);
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
    }
}