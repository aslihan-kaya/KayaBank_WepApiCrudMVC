using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KayaBank_WepApiCrudMVC.Models
{
    public class Branch
    {
        public int BranchNo { get; set; }

        [Required(ErrorMessage = "Şube Adı girilmesi zorunludur!!!")]
        public string BranchName { get; set; }
        [Required(ErrorMessage = "Şube İli girilmesi zorunludur!!!")]
        public string BranchCity { get; set; }
        [Required(ErrorMessage = "Şube İlçesi girilmesi zorunludur!!!")]
        public string BranchDistrict { get; set; }
        public string BranchManager { get; set; }

        public string BranchContact { get; set; }

       

       
    }
}