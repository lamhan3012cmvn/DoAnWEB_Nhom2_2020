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
    
    public partial class PUBLISHING_HOUSE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PUBLISHING_HOUSE()
        {
            this.BOOKs = new HashSet<BOOK>();
        }
    
        public string C_id { get; set; }
        public string namePublishingHouse { get; set; }
        public string phonePublishingHouse { get; set; }
        public string address { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BOOK> BOOKs { get; set; }
    }
}
