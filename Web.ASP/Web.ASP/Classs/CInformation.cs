using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.ASP.models;

namespace Web.ASP.Classs
{
    public class CInformation
    {
        private Manager_BookEntities db = new Manager_BookEntities();
        public Object insertInfo(INFORMATION info)
        {
            try
            {
                db.INFORMATION.Add(info);
                db.SaveChanges();
                var result = new
                {
                    status = true,
                    link = new
                    {
                        actionName = "Index",
                        controllerName = "Home"
                    },
                    message = "Nhập thông tin thành công"
                };
                return result;
            }
            catch
            {
                var result = new
                {
                    status = false,
                    message = "Nhập thông tin không thành công"
                };
                return result;
            }
        }
    }
}