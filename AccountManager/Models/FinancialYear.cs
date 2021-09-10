using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AccountManager.Models
{
    public class FinancialYear
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [DisplayName("Start Year")]
    
        public int StartDate { get; set; }
        [Required]
        [DisplayName("End Year")]
  
        public int EndDate { get; set; }

    }
}
