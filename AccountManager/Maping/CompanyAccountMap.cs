using AccountManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace AccountManager.Maping
{
    public class CompanyAccountMap : EntityTypeConfiguration<CompanyAccount> 
    {
        public CompanyAccountMap()
        {
             HasKey(o => o.Id);
             Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
             Property(o => o.Type).HasMaxLength(50);
             Property(o => o.URL).HasMaxLength(150);
             Property(o => o.Usename).HasMaxLength(100);
             Property(o => o.Password).HasMaxLength(50);
             HasRequired(c => c.Company_CompanyId).WithMany(o => o.CompanyAccount_CompanyIds).HasForeignKey(o => o.CompanyId).WillCascadeOnDelete(false);
             ToTable("CompanyAccount");
 

        }
    }
}
