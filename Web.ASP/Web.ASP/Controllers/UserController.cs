using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.ASP.models;

namespace Web.ASP.Controllers
{
    public class UserController : Controller
    {
        private Manager_BookEntities db = new Manager_BookEntities();
        [HttpPost]
        [isLoginController]
        public ActionResult addReview(String book_id, String information_id, String review, String star)
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
                            actionName = "SingleBook?_id=" + book_id,
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
            if (result.Count == 0)
                result = null;
            return View(result);
        }

        [HttpPost]
        [isLoginController]
        public ActionResult updateCart(string book_id, int count, string order_date)
        {
            var id = Session["user"];
            try
            {
                var isCart = db.INFORMATION.Find(id).CARTs.Where(t => t.book_id == book_id).SingleOrDefault();
                if (!(isCart is null))
                {
                    isCart.count = count;
                    db.SaveChanges();
                }
                var result = new
                {
                    status = true
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

        [HttpPost]
        [isLoginController]
        public ActionResult createCart(string book_id, int count, string order_date)
        {
            var id = Session["user"];
            if(id is null)
            {
                var result = new
                {
                    isLogin = false,
                };
                return Json(result, JsonRequestBehavior.AllowGet);
            }    
            try
            {
                var isCart = db.INFORMATION.Find(id).CARTs.Where(t => t.book_id == book_id).SingleOrDefault();
                if (!(isCart is null))
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
        [isLoginController]
        public ActionResult Confirmation()
        {
            try
            {
                var idInfo = Session["user"].ToString();
                var order_id = "OD" + System.Guid.NewGuid().ToString();
                var cartOfInfo = db.INFORMATION.Find(idInfo).CARTs.ToList();
                cartOfInfo.ForEach(cart =>
                {
                    var bill = new BILL();
                    bill.order_id = order_id;
                    bill.information_id = idInfo;
                    bill.book_id = cart.book_id;
                    bill.total = cart.count;
                    bill.order_date = DateTime.Now;
                    bill.status_bill = "Chờ xác nhận";
                    cart.BOOK.countBook -= (int)cart.count;
                    db.BILLs.Add(bill);
                    db.CARTs.Remove(cart);
                });
                db.SaveChanges();
                ViewBag.bills = db.BILLs.Where(b => b.information_id == idInfo && b.order_id == order_id).ToList();

                return View();
            }
            catch
            {
                //Xin lỗi không đủ số lượng sách bán cho bạn
                return RedirectToAction(actionName: "Cart", controllerName: "Category");
            }

        }

        // Checkout
        [isLoginController]
        public ActionResult Checkout()
        {
            return View();
        }
        // Tracking
        [isLoginController]
        public ActionResult Tracking()
        {
            return View();
        }

        [isLoginController]
        public ActionResult UserBillManagement()
        {
            var id_user = Session["user"].ToString();
            var info = db.INFORMATION.Find(id_user);
            //Tất Cả
            var bill = info.BILLs.GroupBy(b => b.order_id).Select(grp => grp.ToList()).ToList();
            ViewBag.bills = bill;
            ViewBag.billsCount = bill.Count;

            //Chờ Xác Nhận
            var bill_WaitConfirm = info.BILLs.Where(t => t.status_bill.Contains("Chờ xác nhận")).GroupBy(b => b.order_id).Select(grp => grp.ToList()).ToList();
            ViewBag.bill_WaitConfirms = bill_WaitConfirm;
            ViewBag.bill_WaitConfirms_Count = bill_WaitConfirm.Count;

            //Xử Lý
            var bill_Shipping = info.BILLs.Where(t => t.status_bill.Contains("Đang giao")).ToList();
            DateTime currentTime = DateTime.Now;
            bill_Shipping.ForEach(b =>
            {
                var t = currentTime - b.order_date;
                if (t > TimeSpan.FromSeconds(432000))
                {
                    b.status_bill = "Đã hủy";
                }
                else if (t > TimeSpan.FromSeconds(1800)) b.status_bill = "Chờ nhận hàng";
            });
            db.SaveChanges();

            //Chờ Giao Hàng
            var bill_Shipping_set = info.BILLs.Where(t => t.status_bill.Contains("Đang giao")).OrderByDescending(t => t.order_date).GroupBy(b => b.order_id).Select(grp => grp.ToList()).ToList();
            ViewBag.bill_Shippings = bill_Shipping_set;
            ViewBag.bill_Shippings_Count = bill_Shipping_set.Count;

            //Chờ nhận hàng
            var bill_WaitingForDelivery = info.BILLs.Where(t => t.status_bill.Contains("Chờ nhận hàng")).OrderByDescending(t => t.order_date).GroupBy(b => b.order_id).Select(grp => grp.ToList()).ToList();
            ViewBag.bill_WaitingForDelivery = bill_WaitingForDelivery;
            ViewBag.bill_WaitingForDelivery_Count = bill_WaitingForDelivery.Count;

            //Đã Hủy or Giao Không thành công
            var bill_Cancel= info.BILLs.Where(t => t.status_bill.Contains("Đã hủy")).OrderByDescending(t => t.order_date).GroupBy(b => b.order_id).Select(grp => grp.ToList()).ToList();
            ViewBag.bill_Cancel = bill_Cancel;
            ViewBag.bill_Cancel_Count = bill_Cancel.Count;

            //Đã Giao
            var bill_isDone = info.BILLs.Where(t => t.status_bill.Contains("Đã giao")).GroupBy(b => b.order_id).Select(grp => grp.ToList()).ToList();
            ViewBag.bill_isDone = bill_isDone;
            ViewBag.bill_isDone_Count = bill_isDone.Count;
            return View();
        }
    }
}