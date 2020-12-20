    using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.ASP.models;

namespace Web.ASP.Controllers
{
    public class CategoryController : Controller
    {
        private Manager_BookEntities db = new Manager_BookEntities();
        // GET: Category
        public ActionResult Index(int? page,string? categoryID)
        {
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            ViewBag.categoryBook = new SelectList(db.CATEGORies, "C_id", "nameCategory");
            ViewBag.publishingHouse = new SelectList(db.PUBLISHING_HOUSE, "C_id", "namePublishingHouse");
            string category = (categoryID ?? "");
            return View(db.BOOKs.Where(b=>b.categoryBook_ID.Contains(category)).OrderBy(x=>x.C_id).ToPagedList(pageNumber,pageSize));
          
        }
        public ActionResult loadData(string? categoryID,string? publishingHouseID, int? page,int? sort)
        {
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            ViewBag.categoryBook = new SelectList(db.CATEGORies, "C_id", "nameCategory");
            string category = (categoryID ?? "");
            ViewBag.publishingHouse = new SelectList(db.PUBLISHING_HOUSE, "C_id", "namePublishingHouse");
            string publishingHouse = (publishingHouseID ?? "");
            var result = db.BOOKs.Where(b => b.categoryBook_ID.Contains(category) && b.publishingHouseBook_ID.Contains(publishingHouse));
            int sortc = (sort ?? 1);
            if (sortc == 2) return PartialView(result.OrderBy(x=>x.priceBook).ToPagedList(pageNumber, pageSize));
            else if(sortc == 3) return PartialView(result.OrderByDescending(x => x.priceBook).ToPagedList(pageNumber, pageSize));
            return PartialView(result.OrderBy(x => x.C_id).ToPagedList(pageNumber, pageSize));
        }

        // Single Book
        [isLoginController]
        public ActionResult SingleBook(String _id)
        {
            var idInfor = Session["user"];
            var result = db.BOOKs.Find(_id);
            ViewBag.book = result;
            int count = result.REVIEWS.Count == 0 ? 1 : result.REVIEWS.Count;
            float star = (float)(result.REVIEWS.Sum(t => t.star))/(count);
           
            ViewBag.star = Math.Round(star,2);
            ViewBag.countReview = result.REVIEWS.Count;
            ViewBag.count5Star = result.REVIEWS.Count(s => s.star == 5);
            ViewBag.count4Star = result.REVIEWS.Count(s => s.star == 4);
            ViewBag.count3Star = result.REVIEWS.Count(s => s.star == 3);
            ViewBag.count2Star = result.REVIEWS.Count(s => s.star == 2);
            ViewBag.count1Star = result.REVIEWS.Count(s => s.star == 1);
            if(idInfor is null)
            {
                return View();
            }
            var user=  db.INFORMATION.Find(idInfor.ToString());
            ViewBag.nameUser = user.nameInformation;
            ViewBag.emailUser = user.C_id;
            return View();
        }

        
    }
}