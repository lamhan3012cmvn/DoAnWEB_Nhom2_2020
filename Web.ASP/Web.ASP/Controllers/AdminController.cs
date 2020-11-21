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
        [AuthController]
        public ActionResult Index()
        {
            ViewBag.categoryBook = new SelectList(db.CATEGORies, "C_id", "nameCategory");
            //viewBag.discountBook_ID = new SelectList(db.DISCOUNT_BOOK, "C_id", "C_id");
            ViewBag.publishingHouseBook = new SelectList(db.PUBLISHING_HOUSE, "C_id", "namePublishingHouse");
            return View();
        }

        public ActionResult viewBook()
        {
            return PartialView(db.BOOKs.ToList());
        }
        // Add Book
        [HttpGet]
        public ActionResult AddBook()
        {

            ViewBag.categoryBook = new SelectList(db.CATEGORies, "C_id", "nameCategory");
            //viewBag.discountBook_ID = new SelectList(db.DISCOUNT_BOOK, "C_id", "C_id");
            ViewBag.publishingHouseBook = new SelectList(db.PUBLISHING_HOUSE, "C_id", "namePublishingHouse");
            return PartialView();
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
            var book = db.BOOKs.Where(n => n.nameBook.Equals(nameBook)).SingleOrDefault();//???
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
                try {
                    var addbook = new BOOK()
                    {
                        C_id = "MS12" +
                        "",
                        nameBook = nameBook,
                        priceBook = Int32.Parse(priceBook),
                        contentBook = contentBook,
                        countBook = Int32.Parse(countBook),
                        imgBook_ID = "img01",
                        categoryBook_ID = categoryBook_ID,
                        publishingHouseBook_ID = publishingHouseBook_ID
                    };
                     db.BOOKs.Add(addbook);//???
                     db.SaveChanges();
                }
                catch
                {
                    var error = new
                    {
                        status = false,
                        link = new
                        {
                            actionName = "AddBook",
                            controllerName = "Admin"
                        },
                        message = "Nhập sách không thành công"
                    };
                    return Json(error, JsonRequestBehavior.AllowGet);
                }
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