//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Web.ASP.models
{
    using System;
    using System.Collections.Generic;
    
    public partial class BILL
    {
        public string order_id { get; set; }
        public string information_id { get; set; }
        public string book_id { get; set; }
        public Nullable<double> total { get; set; }
        public System.DateTime order_date { get; set; }
        public string status_bill { get; set; }
        public Nullable<System.DateTime> confirm_date { get; set; }
        public Nullable<System.DateTime> gettingBook_date { get; set; }
        public Nullable<System.DateTime> onDelivery_date { get; set; }
        public Nullable<System.DateTime> receivedBook_date { get; set; }
        public Nullable<System.DateTime> cancel_date { get; set; }
    
        public virtual BOOK BOOK { get; set; }
        public virtual INFORMATION INFORMATION { get; set; }
    }
}
