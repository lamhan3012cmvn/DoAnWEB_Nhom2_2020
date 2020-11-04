using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.ASP.models;

namespace Web.ASP.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Validate (string C_email_ID,string password)
        {
            if(String.IsNullOrEmpty(C_email_ID))
            {
                ViewBag.MessEmail ="Vui lòng nhập email";
            }
            if (String.IsNullOrEmpty(password))
            {
                ViewBag.MessPass = "Vui lòng nhập mật khẩu";
            }
            var db = new BookStoreNewEntities();
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
           
          
    }
}