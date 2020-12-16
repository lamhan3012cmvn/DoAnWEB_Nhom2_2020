using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.ASP.models;


namespace Web.ASP.models
{
    public class isAdmin: ActionFilterAttribute
    {
        private Manager_BookEntities db = new Manager_BookEntities();
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var userID = HttpContext.Current.Session["user"];
            var returnUrl = filterContext.HttpContext.Request.RawUrl;
            var isAdmin = db.AUTHs.Find(userID).powers;
            if(!(isAdmin=="1"))
                filterContext.Result = new RedirectResult("~/Home/Index");
            
        }
    }
}