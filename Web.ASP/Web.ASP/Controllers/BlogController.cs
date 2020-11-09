using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.ASP.Controllers
{
    public class BlogController : Controller
    {
        // Blog
        public ActionResult Index()
        {
            return View();
        }
        // SingleBlog
        public ActionResult SingleBlog()
        {
            return View();
        }
    }
}