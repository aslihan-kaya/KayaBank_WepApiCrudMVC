using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace KayaBank_WepApiCrudMVC.Models
{
    public class Debt
    {
        [Key]
        public int DebtNumber { get; set; }

        [Required]
        public decimal DebtAmount { get; set; }
        [Required]
        public int DebtMaturity { get; set; }
        [Required]
        public int CustomerNumber { get; set; }
    }
}