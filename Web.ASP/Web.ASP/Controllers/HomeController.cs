using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using Web.ASP.models;

namespace Web.ASP.Controllers
{
    public class HomeController : Controller
    {
        // GET: Index
        private Manager_BookEntities db = new Manager_BookEntities();
        public ActionResult Index()
        {
            return View(db.BOOKs);
        }
        // Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Validate(string C_email_ID, string password)
        {
            if (String.IsNullOrEmpty(C_email_ID))
            {
                ViewBag.MessEmail = "Vui lòng nhập email";
            }
            if (String.IsNullOrEmpty(password))
            {
                ViewBag.MessPass = "Vui lòng nhập mật khẩu";
            }
            var user = db.AUTHs.Find(C_email_ID);
            if (user is null)
            {
                ViewBag.Mess = "user hoặc mật khẩu không hợp lệ";
                return View("Index");
            }
            else
            {
                if (user.password.Trim() != password)
                {
                    ViewBag.Mess = "user hoặc mật khẩu không hợp lệ";
                    return View("Index");
                }
            }
            return RedirectToAction("../Home/Index");
        }
        // Registor
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(string email, string password, string confirmpassword)
        {
            if (String.IsNullOrEmpty(email))
            {
                ViewBag.MessEmail = "Vui lòng nhập email";
            }
            if (String.IsNullOrEmpty(password))
            {
                ViewBag.MessPass = "Vui lòng nhập mật khẩu";
            }
            if (String.IsNullOrEmpty(confirmpassword))
            {
                ViewBag.MessConfirm = "Vui lòng nhập mật khẩu";
            }
            var user = db.AUTHs.Find(email);
            if (!(user is null) || password != confirmpassword)
            {
                ViewBag.Mess = "Đăng kí không thành công";
                return View("Index");
            }
            var acc = new AUTH();
            acc.C_email_ID = email;
            acc.password = password;
            db.AUTHs.Add(acc);
            db.SaveChanges();
            return View("../Home/Index", db.BOOKs);
        }

    }
}