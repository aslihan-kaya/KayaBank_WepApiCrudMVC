using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KayaBank_WepApiCrudMVC.Models
{
    public class Payment
    {
        [Key]
        public int PaymentNumber { get; set; }

        [Required]
        public string PaymentType { get; set; }
        [Required]
        public decimal PaymentTotal { get; set; }
        [Required]
        public int DebtNumber { get; set; }
    }
}