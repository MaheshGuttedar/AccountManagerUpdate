using AccountManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace AccountManager.Maping
{
    public class CompanyClientMap : EntityTypeConfiguration<CompanyClient> 
    {
        public CompanyClientMap()
        {
             HasKey(o => o.Id);
             Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
             HasRequired(c => c.Company_CompanyId).WithMany(o => o.CompanyClient_CompanyIds).HasForeignKey(o => o.CompanyId).WillCascadeOnDelete(false);
             Property(o => o.FirstName).HasMaxLength(50);
             Property(o => o.LastName).HasMaxLength(50);
             Property(o => o.Email).HasMaxLength(50);
             ToTable("CompanyClient");
 

        }
    }
}
