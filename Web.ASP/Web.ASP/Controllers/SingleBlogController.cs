using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.ASP.Controllers
{
    public class SingleBlogController : Controller
    {
        // GET: SingleBlog
        public ActionResult Index()
        {
            return View();
        }
    }
}