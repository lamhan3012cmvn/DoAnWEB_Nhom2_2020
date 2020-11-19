using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.ASP.models;

namespace Web.ASP.Controllers
{
    public class AdminController : Controller
    {
        private Manager_BookEntities db = new Manager_BookEntities();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        // Add Book
        [HttpGet]
        public ActionResult AddBook()
        {

            ViewBag.categoryBook = new SelectList(db.CATEGORies, "C_id", "nameCategory");
            //viewBag.discountBook_ID = new SelectList(db.DISCOUNT_BOOK, "C_id", "C_id");
            ViewBag.publishingHouseBook = new SelectList(db.PUBLISHING_HOUSE, "C_id", "namePublishingHouse");
            return View();
        }
        [HttpPost]
        public ActionResult AddBook(BOOK model)
        {

            ViewBag.categoryBook = new SelectList(db.CATEGORies, "C_id", "nameCategory");
            //viewBag.discountBook_ID = new SelectList(db.DISCOUNT_BOOK, "C_id", "C_id");
            ViewBag.publishingHouseBook = new SelectList(db.PUBLISHING_HOUSE.Take(10), "C_id", "namePublishingHouse");
            return View();
        }
        [HttpGet]
        public ActionResult AddCategoryItem()
        {
            return PartialView();
        }
        [HttpGet]
        public ActionResult AddPublishingHouse()
        {
            return PartialView();
        }
        [HttpGet]
        public ActionResult AddBookItem()
        {
            ViewBag.categoryBook = new SelectList(db.CATEGORies, "C_id", "nameCategory");
            //viewBag.discountBook_ID = new SelectList(db.DISCOUNT_BOOK, "C_id", "C_id");
            ViewBag.publishingHouseBook = new SelectList(db.PUBLISHING_HOUSE, "C_id", "namePublishingHouse");
            return PartialView();
        }
        public ActionResult ValidateBook( string nameBook, string contentBook,string categoryBook_ID,
                                    string publishingHouseBook_ID, string countBook, string priceBook)
        {
            if (String.IsNullOrEmpty(nameBook))
            {
                var result = new
                {
                    status = false,
                    message = "Vui lòng nhập tên sách"
                };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            if (String.IsNullOrEmpty(contentBook))
            {
                var result = new
                {
                    status = false,
                    message = "Vui lòng nhập mô tả sách"
                };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            if (String.IsNullOrEmpty(contentBook))
            {
                var result = new
                {
                    status = false,
                    message = "Vui lòng nhập mô tả sách"
                };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            if (String.IsNullOrEmpty(categoryBook_ID))
            {
                var result = new
                {
                    status = false,
                    message = "Vui lòng chọn thể loại sách"
                };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            if (String.IsNullOrEmpty(publishingHouseBook_ID))
            {
                var result = new
                {
                    status = false,
                    message = "Vui lòng chọn nhà xuất bản"
                };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            if (String.IsNullOrEmpty(countBook))
            {
                var result = new
                {
                    status = false,
                    message = "Vui lòng nhập số lượng sách"
                };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            if (String.IsNullOrEmpty(priceBook))
            {
                var result = new
                {
                    status = false,
                    message = "Vui lòng nhập giá sách"
                };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            var book = db.BOOKs.Find(nameBook);
            if(!(book is null))
            {
                var result = new
                {
                    status = false,
                    link = new
                    {
                        actionName = "AddBook",
                        controllerName = "Admin"
                    },
                    message = "Nhập sách không thành công"
                };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var addbook = new BOOK();
                addbook.C_id = "MS11";
                addbook.nameBook = nameBook;
                addbook.priceBook = Int32.Parse(priceBook);
                addbook.contentBook = contentBook;
                addbook.countBook = Int32.Parse(countBook); ;
                addbook.imgBook_ID = "img01";
                
                addbook.categoryBook_ID = categoryBook_ID;
                
                addbook.publishingHouseBook_ID = publishingHouseBook_ID;
                db.BOOKs.Add(addbook);
                db.SaveChanges();
                var result = new
                {
                    status = true,
                    link = new
                    {
                        actionName = "AddBook",
                        controllerName = "Admin"
                    },
                    message = "Nhập sách thành công"
                };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }
    }
}