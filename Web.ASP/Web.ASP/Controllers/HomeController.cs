using PagedList;
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
        public ActionResult Index(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(db.BOOKs.OrderBy(x => x.C_id).ToPagedList(pageNumber, pageSize));
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
                var result = new
                {
                    status = false,
                    message = "Vui lòng nhập email"
                };
                return Json(result,JsonRequestBehavior.AllowGet);         
            }
            if (String.IsNullOrEmpty(password))
            {
                var result = new
                {
                    status = false,
                    message = "Vui lòng nhập mật khẩu"
                };
                return Json(result,JsonRequestBehavior.AllowGet);
            }
            var user = db.AUTHs.Find(C_email_ID);
            if (user is null)
            {
                var result = new
                {
                    status = false,
                    message = "User hoặc mật khẩu không hợp lệ"
                };
                return Json(result,JsonRequestBehavior.AllowGet);
            }
            else if (user.password.Trim() != password)
            {
                var result = new
                {
                    status = false,
                    message = "User hoặc mật khẩu không hợp lệ"
                };
                return Json(result,JsonRequestBehavior.AllowGet);
            }
            else
            {
                Session["isLogin"] = true;
                Session["user"] = user.C_email_ID;
                if (user.powers == "1")
                {
                    var result = new
                    {
                        status = true,
                        link = new
                        {
                            actionName="Index",
                            controllerName= "Admin"
                        },
                        message = "Đăng nhập thành công"
                    };
                    return Json(result,JsonRequestBehavior.AllowGet);
                }
                if (user.powers == "0")
                {
                    var result = new
                    {
                        status = true,
                        link = new
                        {
                            actionName = "Index",
                            controllerName = "Home"
                        },
                        message = "Đăng nhập thành công"
                    };
                    return Json(result, JsonRequestBehavior.AllowGet);   
                }
            }
            return View("");
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
                var result = new
                {
                    status = false,
                    message = "Vui lòng nhập email"
                };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            if (String.IsNullOrEmpty(password))
            {
                var result = new
                {
                    status = false,
                    message = "Vui lòng nhập mật khẩu"
                };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            if (String.IsNullOrEmpty(confirmpassword))
            {
                var result = new
                {
                    status = false,
                    message = "Mật khẩu không trùng khớp"
                };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            var user = db.AUTHs.Find(email);
            if (!(user is null) || password != confirmpassword)
            {
                var result = new
                {
                    status = false,
                    link = new
                    {
                        actionName = "Registration",
                        controllerName = "Home"
                    },
                    message = "Đăng kí không thành công"
                };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            { 
                var acc = new AUTH();
                acc.C_email_ID = email;
                acc.password = password;
                acc.powers = "0";
                db.AUTHs.Add(acc);
                db.SaveChanges();
                var result = new
                {
                    status = true,
                    link = new
                    {
                        actionName = "Login",
                        controllerName = "Home"
                    },
                    message = "Đăng kí thành công"
                };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session["user"] = null;
            Session["isLogin"] = null;
            var result = new
            {
                status = true,
                link = new
                {
                    actionName = "Index",
                    controllerName = "Home"
                },
                message = "Đăng xuất thành công"
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}