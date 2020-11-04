using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.ASP.models;

namespace Web.ASP.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        public ActionResult Index()
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
            var db = new BookStoreNewEntities();
            var user = db.AUTHs.Find(email);
            if(!(user is null) || password != confirmpassword)
            {
                ViewBag.Mess = "Đăng kí không thành công";
                return View("Index");
            }
            var acc = new AUTH();
            acc.C_email_ID = email;
            acc.password = password;
            db.AUTHs.Add(acc);
            db.SaveChanges();
            return View("../Home/Index",db.BOOKs);
        }

    }
}