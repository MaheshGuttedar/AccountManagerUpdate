using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AccountManager.Models
{
    public class CompanyAccount
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [StringLength(50)] 
        [DisplayName("Type")] 
        public string Type { get; set; }
        [StringLength(150)] 
        [DisplayName("U R L")] 
        public string URL { get; set; }
        [Required]
        [StringLength(100)] 
        [DisplayName("Usename")] 
        public string Usename { get; set; }
        [Required]
        [StringLength(50)] 
        [DisplayName("Password")] 
        public string Password { get; set; }
        [Required]
        [DisplayName("Company")] 
        public int? CompanyId { get; set; }
        public virtual Company Company_CompanyId { get; set; }

    }
}
