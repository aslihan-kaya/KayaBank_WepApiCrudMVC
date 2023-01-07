using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KayaBank_WepApiCrudMVC.Models
{
    public class Customer
    {
        [Key]
        public int CustomerNumber { get; set; }

        [Required(ErrorMessage = "Müşteri Adı girilmesi zorunludur!!!")]
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "Şifre girilmesi zorunludur!!!")]
        public string CustomerPassword { get; set; }
        [Required(ErrorMessage = "İletişim bilgisi girilmesi zorunludur!!!")]
        public string CustomerPhone { get; set; }
        public string CustomerMail { get; set; }

        public string CustomerAdres { get; set; }
    }
}