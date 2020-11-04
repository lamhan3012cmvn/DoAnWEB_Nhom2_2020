using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.ASP.models;

namespace Web.ASP.Controllers
{
    public class SingleBookController : Controller
    {
        // GET: SingleBook
        public ActionResult Index(String _id)
        {
            var db = new BookStoreNewEntities();
            ViewBag.book = db.BOOKs.Find(_id);
            return View();
        }
        public ActionResult test(String _id)
        {
            var db = new BookStoreNewEntities();
            ViewBag.book = db.BOOKs.Find(_id);
            return View();
        }
    }
}