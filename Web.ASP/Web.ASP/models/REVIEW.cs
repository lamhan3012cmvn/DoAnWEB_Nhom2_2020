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
    
    public partial class REVIEW
    {
        public string book_id { get; set; }
        public string information_id { get; set; }
        public string review1 { get; set; }
        public int star { get; set; }
        public System.DateTime DateOfReview { get; set; }
    
        public virtual BOOK BOOK { get; set; }
        public virtual INFORMATION INFORMATION { get; set; }
    }
}
