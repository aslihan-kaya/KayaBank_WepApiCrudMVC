//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Payment
    {
        public int PaymentNumber { get; set; }
        public string PaymentType { get; set; }
        public Nullable<decimal> PaymentTotal { get; set; }
        public Nullable<int> DebtNumber { get; set; }
    
        public virtual DebtInformation DebtInformation { get; set; }
    }
}
