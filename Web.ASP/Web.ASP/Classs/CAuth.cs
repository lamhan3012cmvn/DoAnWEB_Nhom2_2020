using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.ASP.models;

namespace Web.ASP.Classs
{
    public class CAuth
    {
        private Manager_BookEntities db = new Manager_BookEntities();
        public Object insertAuth(AUTH auth)
        {
            try
            {
                db.AUTHs.Add(auth);
                db.SaveChanges();
                var result = new
                {
                    status = true,
                    link = new
                    {
                        actionName = "Login",
                        controllerName = "Home"
                    },
                    message = "Đăng kí thành công"
                };
                return result;
            }
            catch
            {
                var result = new
                {
                    status = false,
                    message = "Đăng kí không thành công"
                };
                return result;
            }
        }
    }
}