﻿using System;
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
            
            // var user = HttpContext.Current.Session["user"];
            if (isLogin == null)
            {
                var returnUrl = filterContext.HttpContext.Request.RawUrl;
                filterContext.Result = new RedirectResult(String.Concat("~/Home/Login", "?ReturnUrl=", returnUrl));
            }
        }
    }
}