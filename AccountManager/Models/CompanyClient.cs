using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AccountManager.Models
{
    public class CompanyClient
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [DisplayName("Company")] 
        public int? CompanyId { get; set; }
        public virtual Company Company_CompanyId { get; set; }
        [Required]
        [StringLength(50)] 
        [DisplayName("First Name")] 
        public string FirstName { get; set; }
        [StringLength(50)] 
        [DisplayName("Last Name")] 
        public string LastName { get; set; }
        [Required]
        [DisplayName("Is Active")] 
        public bool IsActive { get; set; }
[RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter correct email")]        [StringLength(50)] 
        [DisplayName("Email")] 

        public string Email { get; set; }

    }
}
