using AccountManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace AccountManager.Maping
{
    public class InvoiceItemMap : EntityTypeConfiguration<InvoiceItem> 
    {
        public InvoiceItemMap()
        {
             HasKey(o => o.Id);
             Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
             HasRequired(c => c.Invoice_InvoiceId).WithMany(o => o.InvoiceItem_InvoiceIds).HasForeignKey(o => o.InvoiceId).WillCascadeOnDelete(false);
             Property(o => o.Description).HasMaxLength(200);
             Property(o => o.Title).HasMaxLength(50);
             HasRequired(c => c.QuantityUnit_UnitName).WithMany(o => o.InvoiceItem_UnitNames).HasForeignKey(o => o.UnitName).WillCascadeOnDelete(false);
             ToTable("InvoiceItem");
 

        }
    }
}
