using AccountManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace AccountManager.Maping
{
    public class CompanyOfficeMap : EntityTypeConfiguration<CompanyOffice> 
    {
        public CompanyOfficeMap()
        {
             HasKey(o => o.Id);
             Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
             Property(o => o.Title).HasMaxLength(100);
             Property(o => o.Code);
             HasRequired(c => c.OfficeType_OfficeTypeId).WithMany(o => o.CompanyOffice_OfficeTypeIds).HasForeignKey(o => o.OfficeTypeId).WillCascadeOnDelete(false);
             HasRequired(c => c.Company_CompanyId).WithMany(o => o.CompanyOffice_CompanyIds).HasForeignKey(o => o.CompanyId).WillCascadeOnDelete(false);
             ToTable("CompanyOffice");
 

        }
    }
}
