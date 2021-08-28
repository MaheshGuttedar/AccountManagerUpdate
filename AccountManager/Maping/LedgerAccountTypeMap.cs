using AccountManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace AccountManager.Maping
{
    public class LedgerAccountTypeMap : EntityTypeConfiguration<LedgerAccountType> 
    {
        public LedgerAccountTypeMap()
        {
             HasKey(o => o.Id);
             Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
             Property(o => o.Title).HasMaxLength(50);
             HasOptional(c => c.LedgerAccountType2).WithMany(o => o.LedgerAccountType_ParentIds).HasForeignKey(o => o.ParentId);
             ToTable("LedgerAccountType");
 

        }
    }
}
