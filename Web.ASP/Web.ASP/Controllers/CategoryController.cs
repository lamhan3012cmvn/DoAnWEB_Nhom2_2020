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

        //[isLoginController]
        public ActionResult SingleBook(String _id)
        {
            var idInfor = Session["user"];
            var result = db.BOOKs.Find(_id);
            ViewBag.book = result;
            var star = (float)(result.REVIEWS.Sum(t => t.star))/(result.REVIEWS.Count);
            ViewBag.star = Math.Round(star,2);
            ViewBag.countReview = result.REVIEWS.Count;
            ViewBag.count5Star = result.REVIEWS.Count(s => s.star == 5);
            ViewBag.count4Star = result.REVIEWS.Count(s => s.star == 4);
            ViewBag.count3Star = result.REVIEWS.Count(s => s.star == 3);
            ViewBag.count2Star = result.REVIEWS.Count(s => s.star == 2);
            ViewBag.count1Star = result.REVIEWS.Count(s => s.star == 1);
            if(idInfor is null)
            {
                return View();
            }
            var user=  db.INFORMATION.Find(idInfor.ToString());
            ViewBag.nameUser = user.nameInformation;
            ViewBag.emailUser = user.C_id;
            return View();
        }

        [HttpPost]
        public ActionResult addReview (String book_id, String information_id, String review, String star)
        {
            //var id = Session["user"];
          
            try
            {
                var user = db.INFORMATION.Find(information_id);
                if (user is null)
                {
                    var result = new
                    {
                        status = false,
                        message = "user không tồn tại"
                    };
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var reviews = new REVIEW()
                    {
                        book_id = book_id,
                        information_id = information_id,
                        review1 = review,
                        star = Int32.Parse(star),
                        DateOfReview = DateTime.Now
                    };
                    db.REVIEWS.Add(reviews);
                    db.SaveChanges();
                    var result = new
                    {
                        status = true,
                        message = "Thêm nhận xét thành công",
                        link = new
                        {
                            actionName = "SingleBook?_id="+book_id,
                            controllerName = "Category"
                        }
                    };
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
            }
            catch
            {
                var result = new
                {
                    status = false,
                    message = "Thêm nhận xét không thành công"
                };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }
        // Cart
        [isLoginController]
        public ActionResult Cart()
        {
            String id = Session["user"].ToString();
            var result = db.INFORMATION.Find(id).CARTs.ToList();
            return View(result);
        }
        
        [HttpPost]
        public ActionResult createCart(string book_id,int count, string order_date)
        {
            var id = Session["user"];
            
            try
            {
                var isCart = db.INFORMATION.Find(id).CARTs.Where(t=>t.book_id==book_id).SingleOrDefault();
                if(!(isCart is null))
                {
                    isCart.count += count;
                    db.SaveChanges();
                }
                else
                {
                    var cart = new CART()
                    {
                        book_id = book_id,
                        count = count,
                        order_date = DateTime.Now,
                        information_id = id.ToString(),

                    };
                    db.CARTs.Add(cart);
                    db.SaveChanges();

                }
                var result = new
                {
                    status = true,
                    message = "Thêm Vào giỏ thành công"
                };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                var result = new
                {
                    status = false,
                    message = "Thêm Vào giỏ không thành công"
                };
                return Json(result, JsonRequestBehavior.AllowGet);
               
            }
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