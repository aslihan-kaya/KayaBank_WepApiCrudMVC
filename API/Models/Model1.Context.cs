﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace API.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class KayaBankEntities2 : DbContext
    {
        public KayaBankEntities2()
            : base("name=KayaBankEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BrachInformation> BrachInformations { get; set; }
        public virtual DbSet<CustomerInformation> CustomerInformations { get; set; }
        public virtual DbSet<DebtInformation> DebtInformations { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
    }
}
