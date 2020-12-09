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
        [isLoginController]
        [isAdmin]
        public ActionResult Index()
        {
            ViewBag.categoryBook = new SelectList(db.CATEGORies, "C_id", "nameCategory");
            //viewBag.discountBook_ID = new SelectList(db.DISCOUNT_BOOK, "C_id", "C_id");
            ViewBag.publishingHouseBook = new SelectList(db.PUBLISHING_HOUSE, "C_id", "namePublishingHouse");
            return View();
        }
        [isLoginController]
        [isAdmin]
        [HttpGet]
        public ActionResult viewBook()
        {
            return PartialView(db.BOOKs.ToList());
        }
        // Add Book
        [isLoginController]
        [isAdmin]
        [HttpGet]
        public ActionResult AddBook()
        {

            ViewBag.categoryBook = new SelectList(db.CATEGORies, "C_id", "nameCategory");
            //viewBag.discountBook_ID = new SelectList(db.DISCOUNT_BOOK, "C_id", "C_id");
            ViewBag.publishingHouseBook = new SelectList(db.PUBLISHING_HOUSE, "C_id", "namePublishingHouse");
            ViewBag.authorBook = new SelectList(db.AUTHORs, "C_id", "nameAuthor");
            return PartialView();
        }
        [isLoginController]
        [isAdmin]
        [HttpPost]
        public ActionResult AddBook(BOOK model)
        {

            ViewBag.categoryBook = new SelectList(db.CATEGORies, "C_id", "nameCategory");
            //viewBag.discountBook_ID = new SelectList(db.DISCOUNT_BOOK, "C_id", "C_id");
            ViewBag.publishingHouseBook = new SelectList(db.PUBLISHING_HOUSE.Take(10), "C_id", "namePublishingHouse");
            return View();
        }
        [isLoginController]
        [isAdmin]
        [HttpGet]
        public ActionResult AddCategoryItem()
        {
            return PartialView();
        }
        [isLoginController]
        [isAdmin]
        [HttpGet]
        public ActionResult AddPublishingHouse()
        {
            return PartialView();
        }
        [isLoginController]
        [isAdmin]
        [HttpGet]
        public ActionResult ValidateBook( string nameBook, string contentBook,string categoryBook_ID,
                                    string publishingHouseBook_ID, string authorBook_ID, string countBook, string priceBook, string size, string numberOfPage)
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
            if (String.IsNullOrEmpty(authorBook_ID))
            {
                var result = new
                {
                    status = false,
                    message = "Vui lòng chọn tác giả"
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
            if (String.IsNullOrEmpty(size))
            {
                var result = new
                {
                    status = false,
                    message = "Vui lòng nhập kích thước sách"
                };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            if (String.IsNullOrEmpty(numberOfPage))
            {
                var result = new
                {
                    status = false,
                    message = "Vui lòng số trang sách"
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
                    var _id = "MS" + System.Guid.NewGuid().ToString();
                    var addbook = new BOOK()
                    {
                        C_id = _id,
                        nameBook = nameBook,
                        priceBook = Int32.Parse(priceBook),
                        contentBook = contentBook,
                        countBook = Int32.Parse(countBook),
                        imgBook_ID = "img01",
                        categoryBook_ID = categoryBook_ID,
                        publishingHouseBook_ID = publishingHouseBook_ID,
                        author_id = authorBook_ID
                        
                    };
                    var import_date = new IMPORT_BOOK()
                    {
                        book_ID = _id,
                        import_date = DateTime.Now
                    };
                    db.IMPORT_BOOK.Add(import_date);
                     db.BOOKs.Add(addbook);
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
        [isLoginController]
        [isAdmin]
        public ActionResult BillManagement()
        {
            var cart= db.CARTs.OrderBy(t => t.information_id).ToList();
            var bill = db.BILLs.ToList();
            var time_now = DateTime.Now;
            bill.ForEach(b =>
            {
                if(b.status_bill != "Đã giao")
                {
                    var time = time_now - b.order_date;
                    if (time < TimeSpan.FromSeconds(600))
                    {
                        b.status_bill = "Chờ lấy hàng";

                    }
                    else if (time < TimeSpan.FromSeconds(1200))
                    {
                        b.status_bill = "Đang giao";
                    }
                    else
                    {
                        b.status_bill = "Đã giao";
                    }
                }                         
            });
            db.SaveChanges();
            ViewBag.cartsCount = cart.Count;
            ViewBag.carts = cart;
            ViewBag.bills = bill;
            ViewBag.billsCount = bill.Count;
            return View();
        }
        public ActionResult loadBills()
        {
            return PartialView(db.BILLs.ToList());
        }
    }
}