using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using Web.ASP.models;
using Facebook;
using System.Configuration;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Security.Cryptography;

namespace Web.ASP.Controllers
{
    public class HomeController : Controller
    {
        // GET: Index
        private Manager_BookEntities db = new Manager_BookEntities();
        private Uri RedirectUri
        {
            get
            {
                var uriBuilder = new UriBuilder(Request.Url);
                uriBuilder.Query = null;
                uriBuilder.Fragment = null;
                uriBuilder.Path = Url.Action("FacebookCallback");
                return uriBuilder.Uri;
            }
        }
        public void sendMail()
        {
            var smtp = new SmtpClient("smtp.gmail.com",587);
            var mail = new MailMessage();

            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential("lamhan3012@gmail.com", "lamhoangan3012cmvn");

            mail.From = new MailAddress("lamhan3012@gmail.com", "Bạn Nụ Cute");
            mail.BodyEncoding = mail.SubjectEncoding = Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;

            mail.Body = "Nội dung email - có thể có cả thẻ html";
            mail.Subject = "Xác nhận quên mật khẩu";
            string mailTo = "laman3012@gmail.com";
            mail.To.Add(mailTo);
            smtp.UseDefaultCredentials = true;  
            smtp.Send(mail);
        }
        public ActionResult Index(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(db.BOOKs.OrderBy(x => x.C_id).ToPagedList(pageNumber, pageSize));
        }
        // Login
        public ActionResult Login(string ReturnUrl)
        {
            var isLogin = Session["isLogin"];
            if(!(isLogin is null)) 
            {
                return RedirectToAction(actionName: "Index", controllerName: "Home");
            }
            return View();
        }
        public string GetMD5(string str)
        {
            str = str + "md5";
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

            byte[] bHash = md5.ComputeHash(Encoding.UTF8.GetBytes(str));

            StringBuilder sbHash = new StringBuilder();

            foreach (byte b in bHash)
            {

                sbHash.Append(String.Format("{0:x2}", b));

            }
            return sbHash.ToString();
        }
        [HttpPost]
        public ActionResult Validate(string C_email_ID, string password, string returnUrl)
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
            else if (user.password.Trim() != GetMD5(password))
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
                var inforUser = db.INFORMATION.Find(user.C_email_ID);
                if(inforUser is null)
                {
                    var result = new
                    {
                        status = true,
                        isInfor = false,
                        link = new
                        {
                            returnUrlChange= "/Home/Information"
                        },
                        message = "Đăng nhập thành công"
                    };
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
                if (user.powers == "1")
                {
                    var result = new
                    {
                        status = true,
                        link = new
                        {
                            returnUrlChange = returnUrl
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
                            returnUrlChange = returnUrl
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
                acc.password = GetMD5(password);
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
        //infor
        [HttpGet]
        [isLoginController]
        public ActionResult Information()
        {
            return PartialView();
        }
        [isLoginController]
        [HttpPost]
        public ActionResult ValidateInfor(INFORMATION infor)
        {

            if (String.IsNullOrEmpty(infor.nameInformation))
            {
                var result = new
                {
                    status = false,
                    message = "Vui lòng nhập họ và tên"
                };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            if (String.IsNullOrEmpty(infor.maleInformation) || infor.maleInformation == "#")
            {
                var result = new
                {
                    status = false,
                    message = "Vui lòng chọn giới tính"
                };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            if (String.IsNullOrEmpty(infor.phoneInformation))
            {
                var result = new
                {
                    status = false,
                    message = "Vui lòng nhập số điện thoại"
                };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            if (String.IsNullOrEmpty(infor.addressInformation))
            {
                var result = new
                {
                    status = false,
                    message = "Vui lòng nhập địa chỉ"
                };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            if ((infor.birthday) > DateTime.Now   )
            {
                var result = new
                {
                    status = false,
                    message = "Ngày sinh không hợp lệ"
                };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                try
                {
                    infor.C_id = Session["user"].ToString();
                    db.INFORMATION.Add(infor);
                    db.SaveChanges();
                    var result = new
                    {
                        status = true,
                        link = new
                        {
                            actionName = "Index",
                            controllerName = "Home"
                        },
                        message = "Nhập thông tin thành công"
                    };
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
                catch
                {
                    var result = new
                    {
                        status = false,
                        message = "Nhập thông tin không thành công"
                    };
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
            }    
        }
        public ActionResult LoginFaceBook()
        {
            var fb = new FacebookClient();
            var loginUrl = fb.GetLoginUrl(new
            {
                client_id = ConfigurationManager.AppSettings["FbAppId"],
                client_secret = ConfigurationManager.AppSettings["FbAppSecret"],
                redirect_uri = RedirectUri.AbsoluteUri,
                response_type = "code",
                scope = "email",
            });
            return Redirect(loginUrl.AbsoluteUri);

        }
        public ActionResult FacebookCallback(string code)
        {
            var fb = new FacebookClient();
            dynamic result = fb.Post("oauth/access_token", new
            {
                client_id = ConfigurationManager.AppSettings["FbAppId"],
                client_secret = ConfigurationManager.AppSettings["FbAppSecret"],
                redirect_uri = RedirectUri.AbsoluteUri,
                code = code
            });
            var accessToken = result.access_token;
            if (!string.IsNullOrEmpty(accessToken))
            {
                fb.AccessToken = accessToken;
                dynamic me = fb.Get("me?fields=id,name");
                if((db.AUTHs.Find(me.id) is null))
                {
                    var auth = new AUTH()
                    {
                        C_email_ID = me.id,
                        powers = "0",
                        password = "12345",
                    };
                    InsertFacebook(auth);
                    return RedirectToAction(actionName: "Index", controllerName: "Home");
                }
                else{
                    Session["isLogin"] = true;
                    Session["user"] = me.id;
                    return RedirectToAction(actionName: "Index", controllerName: "Home");
                }
               
            }
            return View("");
        }
        private void InsertFacebook(AUTH auth)
        {
            db.AUTHs.Add(auth);
            db.SaveChanges();
        }
        [isLoginController]
        public ActionResult Bills()
        {
            var idInfo = Session["user"].ToString();
            var result = db.BILLs.Where(b => b.information_id == idInfo).GroupBy(b => b.order_id).Select(grp => grp.ToList() ).ToList();
            ViewBag.bills = result;
            return View();
        }
    }
}