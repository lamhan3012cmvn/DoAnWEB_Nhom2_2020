﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Manager_BookEntities : DbContext
    {
        public Manager_BookEntities()
            : base("name=Manager_BookEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AUTH> AUTHs { get; set; }
        public virtual DbSet<AUTHOR> AUTHORs { get; set; }
        public virtual DbSet<BILL> BILLs { get; set; }
        public virtual DbSet<BOOK> BOOKs { get; set; }
        public virtual DbSet<CART> CARTs { get; set; }
        public virtual DbSet<CATEGORY> CATEGORies { get; set; }
        public virtual DbSet<DISCOUNT_BOOK> DISCOUNT_BOOK { get; set; }
        public virtual DbSet<IMAGE_BOOK> IMAGE_BOOK { get; set; }
        public virtual DbSet<IMPORT_BOOK> IMPORT_BOOK { get; set; }
        public virtual DbSet<INFORMATION> INFORMATION { get; set; }
        public virtual DbSet<PUBLISHING_HOUSE> PUBLISHING_HOUSE { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
    }
}
