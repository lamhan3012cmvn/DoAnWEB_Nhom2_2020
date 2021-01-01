using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.ASP.models;
using OfficeOpenXml;
using System.Data.OleDb;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace Web.ASP.Controllers
{
    public class AdminController : Controller
    {
        private Manager_BookEntities db = new Manager_BookEntities();
        // GET: Admin
        [isLoginController]
        [isAdmin]
        public ActionResult Index()
        {
            ViewBag.categoryBook = new SelectList(db.CATEGORies, "C_id", "nameCategory");
            //viewBag.discountBook_ID = new SelectList(db.DISCOUNT_BOOK, "C_id", "C_id");
            ViewBag.publishingHouseBook = new SelectList(db.PUBLISHING_HOUSE, "C_id", "namePublishingHouse");
            var admin = Session["user"];
            ViewBag.admin = db.INFORMATION.Find(admin.ToString()).nameInformation;
            return View();
        }
        [isLoginController]
        [isAdmin]
        [HttpGet]
        public ActionResult viewBook()
        {
            return PartialView(db.BOOKs.ToList());
        }
        // Add Book
        [isLoginController]
        [isAdmin]
        [HttpGet]
        public ActionResult AddBook()
        {

            ViewBag.categoryBook = new SelectList(db.CATEGORies, "C_id", "nameCategory");
            //viewBag.discountBook_ID = new SelectList(db.DISCOUNT_BOOK, "C_id", "C_id");
            ViewBag.publishingHouseBook = new SelectList(db.PUBLISHING_HOUSE, "C_id", "namePublishingHouse");
            ViewBag.authorBook = new SelectList(db.AUTHORs, "C_id", "nameAuthor");
            return PartialView();
        }


        [isLoginController]
        [isAdmin]
        [HttpPost]
        public ActionResult ValidateBook(string nameBook, string contentBook, string categoryBook_ID,
                                    string publishingHouseBook_ID, string authorBook_ID, string countBook, string priceBook, string size, string numberOfPage)
        {
            if (String.IsNullOrEmpty(nameBook))
            {
                var result = new
                {
                    status = false,
                    message = "Vui lòng nhập tên sách"
                };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            if (String.IsNullOrEmpty(contentBook))
            {
                var result = new
                {
                    status = false,
                    message = "Vui lòng nhập mô tả sách"
                };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            if (String.IsNullOrEmpty(contentBook))
            {
                var result = new
                {
                    status = false,
                    message = "Vui lòng nhập mô tả sách"
                };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            if (String.IsNullOrEmpty(categoryBook_ID))
            {
                var result = new
                {
                    status = false,
                    message = "Vui lòng chọn thể loại sách"
                };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            if (String.IsNullOrEmpty(publishingHouseBook_ID))
            {
                var result = new
                {
                    status = false,
                    message = "Vui lòng chọn nhà xuất bản"
                };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            if (String.IsNullOrEmpty(authorBook_ID))
            {
                var result = new
                {
                    status = false,
                    message = "Vui lòng chọn tác giả"
                };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            if (String.IsNullOrEmpty(countBook))
            {
                var result = new
                {
                    status = false,
                    message = "Vui lòng nhập số lượng sách"
                };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            if (String.IsNullOrEmpty(priceBook))
            {
                var result = new
                {
                    status = false,
                    message = "Vui lòng nhập giá sách"
                };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            if (String.IsNullOrEmpty(size))
            {
                var result = new
                {
                    status = false,
                    message = "Vui lòng nhập kích thước sách"
                };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            if (String.IsNullOrEmpty(numberOfPage))
            {
                var result = new
                {
                    status = false,
                    message = "Vui lòng số trang sách"
                };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            var book = db.BOOKs.Where(n => n.nameBook.Equals(nameBook)).SingleOrDefault();
            if (!(book is null))
            {
                var result = new
                {
                    status = false,
                    link = new
                    {
                        actionName = "AddBook",
                        controllerName = "Admin"
                    },
                    message = "Nhập sách không thành công"
                };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                try
                {
                    var _id = "MS" + System.Guid.NewGuid().ToString();
                    var addbook = new BOOK()
                    {
                        C_id = _id,
                        nameBook = nameBook,
                        priceBook = Int32.Parse(priceBook),
                        contentBook = contentBook,
                        countBook = Int32.Parse(countBook),
                        imgBook_ID = "img01",
                        categoryBook_ID = categoryBook_ID,
                        publishingHouseBook_ID = publishingHouseBook_ID,
                        author_id = authorBook_ID

                    };
                    var import_date = new IMPORT_BOOK()
                    {
                        book_ID = _id,
                        import_date = DateTime.Now
                    };
                    db.IMPORT_BOOK.Add(import_date);
                    db.BOOKs.Add(addbook);
                    db.SaveChanges();
                }
                catch
                {
                    var error = new
                    {
                        status = false,
                        link = new
                        {
                            actionName = "AddBook",
                            controllerName = "Admin"
                        },
                        message = "Nhập sách không thành công"
                    };
                    return Json(error, JsonRequestBehavior.AllowGet);
                }
                var result = new
                {
                    status = true,
                    link = new
                    {
                        actionName = "AddBook",
                        controllerName = "Admin"
                    },
                    message = "Nhập sách thành công"
                };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }
        [isLoginController]
        [isAdmin]
        public ActionResult BillManagement()
        {
            //Tất cả
            //var cart= db.CARTs.OrderByDescending(t => t.order_date).GroupBy(b => b.).Select(grp => grp.ToList()).ToList();
            var bill = db.BILLs.OrderByDescending(t => t.order_date).GroupBy(b => b.order_id).Select(grp => grp.ToList()).ToList();
            //ViewBag.carts = cart;
            //ViewBag.cartsCount = cart.Count;
            ViewBag.bills = bill;
            ViewBag.billsCount = bill.Count;

            //Chờ xác nhận
            var bill_WaitConfirm = db.BILLs.Where(t => t.status_bill.Contains("Chờ xác nhận")).OrderByDescending(t => t.order_date).GroupBy(b => b.order_id).Select(grp => grp.ToList()).ToList();
            ViewBag.bill_WaitConfirms = bill_WaitConfirm;
            ViewBag.bill_WaitConfirms_Count = bill_WaitConfirm.Count;

            //Chờ lấy hàng
            var bill_WaitingFordelivery = db.BILLs.Where(t => t.status_bill.Contains("Chờ lấy hàng")).OrderByDescending(t => t.confirm_date).GroupBy(b => b.order_id).Select(grp => grp.ToList()).ToList();
            ViewBag.bill_WaitingFordelivery = bill_WaitingFordelivery;
            ViewBag.bill_WaitingFordelivery_Count = bill_WaitingFordelivery.Count;

            //Đang giao
            var bill_OnDelivery = db.BILLs.Where(t => t.status_bill.Contains("Đang giao")).OrderByDescending(t => t.gettingBook_date).GroupBy(b => b.order_id).Select(grp => grp.ToList()).ToList();
            ViewBag.bill_OnDelivery = bill_OnDelivery;
            ViewBag.bill_OnDelivery_Count = bill_OnDelivery.Count;

            //Chờ nhận hàng
            var bill_WaitingForDelivery_k = db.BILLs.Where(t => t.status_bill.Contains("Chờ nhận hàng")).OrderByDescending(t => t.onDelivery_date).GroupBy(b => b.order_id).Select(grp => grp.ToList()).ToList();
            ViewBag.bill_WaitingForDelivery_k = bill_WaitingForDelivery_k;
            ViewBag.bill_WaitingForDelivery_k_Count = bill_WaitingForDelivery_k.Count;

            //Đã Hủy or Giao Không thành công
            var bill_Cancel = db.BILLs.Where(t => t.status_bill.Contains("Đã hủy")).OrderByDescending(t => t.cancel_date).GroupBy(b => b.order_id).Select(grp => grp.ToList()).ToList();
            ViewBag.bill_Cancel = bill_Cancel;
            ViewBag.bill_Cancel_Count = bill_Cancel.Count;

            //Đã giao
            var bill_isDone = db.BILLs.Where(t => t.status_bill.Contains("Đã giao")).GroupBy(b => b.receivedBook_date).Select(grp => grp.ToList()).ToList();
            ViewBag.bill_isDone = bill_isDone;
            ViewBag.bill_isDone_count = bill_isDone.Count;

            return View();
        }
        [isLoginController]
        [isAdmin]
        public ActionResult loadBills()
        {
            return PartialView(db.BILLs.ToList());
        }
        [isLoginController]
        [isAdmin]
        [HttpGet]
        public ActionResult ChangeStatus(string order_id, string information_id, string status, string actionChange)
        {
            try
            {
                var bill = db.BILLs.Where(t => t.order_id == order_id && t.information_id == information_id).ToList();
                bill.ForEach(b =>
                {
                    b.status_bill = status;
                    if (b.status_bill == "Chờ lấy hàng")
                    {
                        b.confirm_date = DateTime.Now;

                    }
                    else if (b.status_bill == "Đang giao")
                    {
                        b.gettingBook_date = DateTime.Now;
                        b.onDelivery_date = DateTime.Now;
                    }
                    else if (b.status_bill == "Đã giao")
                    {
                        b.receivedBook_date = DateTime.Now;
                    }

                });
                db.SaveChanges();

                return RedirectToAction(actionName: actionChange, controllerName: "Admin");
            }
            catch
            {
                var result = new
                {
                    status = false,
                    message = "Xác nhận không thành công"
                };
                return Json(result, JsonRequestBehavior.AllowGet);
            }

        }
        [isLoginController]
        [isAdmin]
        public ActionResult LoadWaitingProduct()
        {
            var bill_WaitingFordelivery = db.BILLs.Where(t => t.status_bill.Contains("Chờ lấy hàng")).OrderByDescending(t => t.order_date).GroupBy(b => b.order_id).Select(grp => grp.ToList()).ToList();
            ViewBag.bill_WaitingFordelivery = bill_WaitingFordelivery;
            ViewBag.bill_WaitingFordelivery_Count = bill_WaitingFordelivery.Count;
            return PartialView();
        }
        [isLoginController]
        [isAdmin]
        public ActionResult LoadOnDelivery()
        {
            var bill_OnDelivery = db.BILLs.Where(t => t.status_bill.Contains("Đang giao")).OrderByDescending(t => t.order_date).GroupBy(b => b.order_id).Select(grp => grp.ToList()).ToList();
            ViewBag.bill_OnDelivery = bill_OnDelivery;
            ViewBag.bill_OnDelivery_Count = bill_OnDelivery.Count;
            return PartialView();
        }

        [isLoginController]
        [isAdmin]
        public ActionResult LoadChartJs()
        {
            var bill = db.BILLs.Where(b => b.status_bill.Equals("Đã giao") && b.order_date.Year == DateTime.Now.Year).ToList();
            //Doanh thu theo từng tháng trên 1 năm
            var revenueMonth = bill.GroupBy(t => t.order_date.Month).Select(grp => new { month = grp.Key, data = grp.ToList() }).ToList();

            List<int> revenueMonthArr = new List<int>();
            for (int i = 1; i <= 12; i++)
            {
                int revenue = 0;
                for (int j = 0; j < revenueMonth.Count; j++)
                {
                    if (i == revenueMonth[j].month)
                    {

                        revenueMonth[j].data.ForEach(b =>
                        {
                            revenue += (int)b.total * (int)b.BOOK.priceBook;
                        });

                    }
                }
                revenueMonthArr.Add(revenue);

            }
            ViewBag.revenueMonthArr = revenueMonthArr;

            //Top 10 loại sách bán chạy nhất trong năm
            List<string> lableRankBookInMonth = new List<string>();
            List<int> valueRankBookInMonth = new List<int>();
            var rankBookInMonth = bill.GroupBy(t => t.book_id).Select(grp => new { bookID = grp.Key, data = grp.ToList() }).ToList();
            int count = rankBookInMonth.Count > 10 ? 10 : rankBookInMonth.Count;
            for (int i = 0; i < count; i++)
            {
                lableRankBookInMonth.Add(rankBookInMonth[i].data[0].BOOK.nameBook);
                int total = 0;
                rankBookInMonth[i].data.ForEach(r =>
                {
                    total += (int)r.total;
                });
                valueRankBookInMonth.Add(total);
            }
            var rankBook = new
            {
                lbl = lableRankBookInMonth,
                val = valueRankBookInMonth
            };
            ViewBag.rankBook = JsonConvert.SerializeObject(rankBook);
            return PartialView();
        }

        [isLoginController]
        [isAdmin]
        public ActionResult LoadChartJsOfUser()
        {
            var bill = db.BILLs.Where(b => b.status_bill.Equals("Đã giao") && b.order_date.Year == DateTime.Now.Year).ToList();


            //Top 10 loại sách bán chạy nhất trong năm
            List<string> lableRankUserInYear = new List<string>();
            List<int> valueRankUserInYear = new List<int>();
            var rankUserBuy = bill.GroupBy(t => t.information_id).Select(grp => new { user = grp.Key, data = grp.ToList() }).ToList();
            int count = rankUserBuy.Count > 10 ? 10 : rankUserBuy.Count;
            for (int i = 0; i < count; i++)
            {
                lableRankUserInYear.Add(rankUserBuy[i].data[0].information_id);
                int total = 0;
                rankUserBuy[i].data.ForEach(r =>
                {
                    total += (int)r.total;
                });
                valueRankUserInYear.Add(total);
            }
            var rankUser = new
            {
                lbl = lableRankUserInYear,
                val = valueRankUserInYear
            };
            ViewBag.rankUser = JsonConvert.SerializeObject(rankUser);
            return PartialView();
        }
        [isLoginController]
        [isAdmin]
        public ActionResult LoadSingleBook(string id)
        {
            var result = db.BOOKs.Find(id);
            ViewBag.book = result;
            return PartialView();
        }
        [isLoginController]
        [isAdmin]
        public ActionResult viewUser()
        {
            
            var result = db.INFORMATION.Where(b => b.AUTH.powers == "0").ToList();
            return PartialView(result);
        }
        public void ExportExcel()
        {
            var bookList = db.IMPORT_BOOK.ToList();
            ExcelPackage.LicenseContext = LicenseContext.Commercial;

            // If you use EPPlus in a noncommercial context
            // according to the Polyform Noncommercial license:
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            //ExcelPackage ep = new ExcelPackage();
            using (var ep = new ExcelPackage())
            {
                ExcelWorksheet Sheet = ep.Workbook.Worksheets.Add("BOOK");

                Sheet.Cells["A1"].Value = "BookID";
                Sheet.Cells["B1"].Value = "NameOfBook";
                Sheet.Cells["C1"].Value = "PriceOfBook";
                Sheet.Cells["D1"].Value = "CountOfBook";
                Sheet.Cells["E1"].Value = "Author";
                Sheet.Cells["F1"].Value = "Category";
                Sheet.Cells["G1"].Value = "Pubishing";
                Sheet.Cells["H1"].Value = "ImportDate";
                int row = 2;
                foreach (var item in bookList)
                {
                    Sheet.Cells[string.Format("A{0}", row)].Value = item.BOOK.C_id;
                    Sheet.Cells[string.Format("B{0}", row)].Value = item.BOOK.nameBook;
                    Sheet.Cells[string.Format("C{0}", row)].Value = item.BOOK.priceBook;
                    Sheet.Cells[string.Format("D{0}", row)].Value = item.BOOK.countBook;
                    Sheet.Cells[string.Format("E{0}", row)].Value = item.BOOK.AUTHOR.nameAuthor;
                    Sheet.Cells[string.Format("F{0}", row)].Value = item.BOOK.CATEGORY.nameCategory;
                    Sheet.Cells[string.Format("G{0}", row)].Value = item.BOOK.PUBLISHING_HOUSE.namePublishingHouse;
                    var date = item.import_date.ToString();
                    Sheet.Cells[string.Format("H{0}", row)].Value = date;

                    row++;
                }
                Sheet.Cells["A:Az"].AutoFitColumns();
                Response.Clear();
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment: filename=" + "ReportOfBook.xlsx");
                Response.BinaryWrite(ep.GetAsByteArray());
                Response.End();
            }
        }

        public FileResult DownloadExcel()
        {
            string path = "~/excel/MauNhapSach.xlsx";
            return File(path, "application/vnd.ms-excel", "MauNhapSach.xlsx");
        }
        [HttpPost]
        public ActionResult ImportBook(HttpPostedFileBase postedFile)
        {
            try
            {
                string filePath = string.Empty;
                if (postedFile != null)
                {
                    string path = Server.MapPath("~/excel/");

                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    filePath = path + Path.GetFileName(postedFile.FileName);
                    string extension = Path.GetExtension(postedFile.FileName);
                    postedFile.SaveAs(filePath);
                    string conString = "data source=.;initial catalog=Manager_Book;user id=sa;password=quýnhql2017;MultipleActiveResultSets=True;App=EntityFramework&quot;";
                    SqlConnection con = new SqlConnection(conString);
                    con.Open();
                    switch (extension)
                    {
                        case ".xls": //Excel 97-03.
                            conString = ConfigurationManager.ConnectionStrings["Manager_BookEntities"].ConnectionString;
                            break;
                        case ".xlsx": //Excel 07 and above.
                            conString = ConfigurationManager.ConnectionStrings["Manager_BookEntities"].ConnectionString;
                            break;
                    }
                    string excelConnectionString = @"Provider='Microsoft.ACE.OLEDB.12.0';Data Source='" + filePath + "';Extended Properties='Excel 12.0 Xml;IMEX=1'";
                    OleDbConnection excelConnection = new OleDbConnection(excelConnectionString);

                    excelConnection.Open();
                    string tableName = excelConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null).Rows[1]["TABLE_NAME"].ToString();


                    OleDbCommand cmd = new OleDbCommand("Select * from [" + tableName + "]", excelConnection);

                    DataSet excel = new DataSet();


                    using (OleDbDataAdapter oda = new OleDbDataAdapter())
                    {
                        oda.SelectCommand = cmd;

                        oda.Fill(excel);
                    }
                    excelConnection.Close();
                    var n = excel.Tables[0].Rows.Count;

                    for (int i = 0; i < n; i++)
                    {
                        var newBook = new BOOK()
                        {
                            C_id = "MS" + System.Guid.NewGuid().ToString(),
                            nameBook = excel.Tables[0].Rows[i]["nameBook"].ToString(),
                            priceBook = Double.Parse(excel.Tables[0].Rows[i]["priceBook"].ToString()),
                            contentBook = excel.Tables[0].Rows[i]["contentBook"].ToString(),
                            countBook = Int32.Parse(excel.Tables[0].Rows[i]["priceBook"].ToString()),
                            imgBook_ID = "img01",
                            categoryBook_ID = excel.Tables[0].Rows[i]["categoryBook_ID"].ToString(),
                            publishingHouseBook_ID = excel.Tables[0].Rows[i]["publishingHouseBook_ID"].ToString(),
                            author_id = excel.Tables[0].Rows[i]["author_id"].ToString(),
                            size = excel.Tables[0].Rows[i]["size"].ToString(),
                            numberOfPages = Int32.Parse(excel.Tables[0].Rows[i]["numberOfPages"].ToString())


                        };
                        db.BOOKs.Add(newBook);
                    }
                    db.SaveChanges();

                    var result = new
                    {
                        status = true,
                        message = "Cập nhật thành công"
                    };
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
                var resultfalse = new
                {
                    status = false,
                    message = "Cập nhật không thành công"
                };
                return Json(resultfalse, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                var result = new
                {
                    status = false,
                    message = "Cập nhật không thành công"
                };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult ProfileUser()
        {
            var idInfor = Session["user"].ToString();
            var infor = db.INFORMATION.Find(idInfor);
            var str = infor.birthday.ToString("yyyy-MM-dd");
            if(infor != null)
            {
                ViewBag.infor = infor;
                ViewBag.birth = str;
            }    
            return PartialView();
        }
        [HttpGet]
        public ActionResult UpdateBook(string id)
        {
            ViewBag.categoryBook = new SelectList(db.CATEGORies, "C_id", "nameCategory");
            //viewBag.discountBook_ID = new SelectList(db.DISCOUNT_BOOK, "C_id", "C_id");
            ViewBag.publishingHouseBook = new SelectList(db.PUBLISHING_HOUSE, "C_id", "namePublishingHouse");
            ViewBag.authorBook = new SelectList(db.AUTHORs, "C_id", "nameAuthor");
            var book= db.BOOKs.Find(id);
            ViewBag.book = book;
            ViewBag.author_id = book.author_id;
            ViewBag.publish_id = book.publishingHouseBook_ID;
            ViewBag.cate_id = book.categoryBook_ID;
            ViewBag.content = book.contentBook;
            return PartialView();

        }
        [HttpPost]
        public ActionResult UpdateBook(string idBook,string nameBook, string contentBook, string categoryBook_ID,
                                    string publishingHouseBook_ID, string authorBook_ID, string countBook, string priceBook, string size, string numberOfPage)
        {
            if (String.IsNullOrEmpty(nameBook))
            {
                var result = new
                {
                    status = false,
                    message = "Vui lòng nhập tên sách"
                };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            if (String.IsNullOrEmpty(contentBook))
            {
                var result = new
                {
                    status = false,
                    message = "Vui lòng nhập mô tả sách"
                };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            if (String.IsNullOrEmpty(categoryBook_ID))
            {
                var result = new
                {
                    status = false,
                    message = "Vui lòng chọn thể loại sách"
                };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            if (String.IsNullOrEmpty(publishingHouseBook_ID))
            {
                var result = new
                {
                    status = false,
                    message = "Vui lòng chọn nhà xuất bản"
                };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            if (String.IsNullOrEmpty(authorBook_ID))
            {
                var result = new
                {
                    status = false,
                    message = "Vui lòng chọn tác giả"
                };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            if (String.IsNullOrEmpty(countBook))
            {
                var result = new
                {
                    status = false,
                    message = "Vui lòng nhập số lượng sách"
                };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            if (String.IsNullOrEmpty(priceBook))
            {
                var result = new
                {
                    status = false,
                    message = "Vui lòng nhập giá sách"
                };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            if (String.IsNullOrEmpty(size))
            {
                var result = new
                {
                    status = false,
                    message = "Vui lòng nhập kích thước sách"
                };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            if (String.IsNullOrEmpty(numberOfPage))
            {
                var result = new
                {
                    status = false,
                    message = "Vui lòng số trang sách"
                };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            try
            {
                var bookUpdate = db.BOOKs.Find(idBook);
                if (bookUpdate is null)
                {
                    var result = new
                    {
                        status = false,
                        message = "Không tìm thấy sách để cập nhật"
                    };
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    bookUpdate.nameBook = nameBook;
                    bookUpdate.priceBook = Int32.Parse(priceBook);
                    bookUpdate.contentBook = contentBook;
                    bookUpdate.countBook = Int32.Parse(countBook);
                    bookUpdate.imgBook_ID = "img01";
                    bookUpdate.categoryBook_ID = categoryBook_ID;
                    bookUpdate.publishingHouseBook_ID = publishingHouseBook_ID;
                    bookUpdate.author_id = authorBook_ID;
                    db.SaveChanges();
                    var result = new
                    {
                        status = true,
                        message = "Cập nhật sách thành công"
                    };
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
                
            }
            catch
            {
                var error = new
                {
                    status = false,
                    link = new
                    {
                        actionName = "AddBook",
                        controllerName = "Admin"
                    },
                    message = "Nhập sách không thành công"
                };
                return Json(error, JsonRequestBehavior.AllowGet);
            }
        }
    }
}