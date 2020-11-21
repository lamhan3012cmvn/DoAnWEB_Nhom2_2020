using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.ASP.models;


namespace Web.ASP.models
{
    public class AuthController: ActionFilterAttribute
    {
        private Manager_BookEntities db = new Manager_BookEntities();
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var isLogin = HttpContext.Current.Session["user"];
            if (isLogin == null)
            {
                filterContext.Result = new RedirectResult("~/Home/Login");
            }
            else
            {
                var isAdmin = db.AUTHs.Find(isLogin).powers;
                if(!(isAdmin=="1"))
                    filterContext.Result = new RedirectResult("~/Home/Index");
            }
        }
    }
}