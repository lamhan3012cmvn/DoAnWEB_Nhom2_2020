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
        public ActionResult Index()
        {
            var db = new BookStoreNewEntities();
            return View(db.BOOKs);
        }
    }
}