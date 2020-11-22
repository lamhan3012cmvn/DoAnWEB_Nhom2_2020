using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.ASP.models;


namespace Web.ASP.models
{
    public class isLoginController: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var isLogin = HttpContext.Current.Session["isLogin"];
            if (isLogin == null)
            {
                filterContext.Result = new RedirectResult("~/Home/Login");
            }
        }
    }
}