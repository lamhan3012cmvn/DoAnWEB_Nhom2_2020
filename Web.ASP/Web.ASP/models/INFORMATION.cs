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
    
    public partial class INFORMATION
    {
        public string C_id { get; set; }
        public string nameInformation { get; set; }
        public string maleInformation { get; set; }
        public string phoneInformation { get; set; }
        public string addressInformation { get; set; }
        public System.DateTime birthday { get; set; }
    
        public virtual AUTH AUTH { get; set; }
    }
}
