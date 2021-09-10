using AccountManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace AccountManager.Maping
{
    public class InvoiceMap : EntityTypeConfiguration<Invoice> 
    {
        public InvoiceMap()
        {
             HasKey(o => o.Id);
             Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
             HasRequired(c => c.PaymentStatus_Status).WithMany(o => o.Invoice_Statuss).HasForeignKey(o => o.Status).WillCascadeOnDelete(false);
             Property(o => o.OtherInvoiceCode).HasMaxLength(50);
             HasRequired(c => c.User_ClientId).WithMany(o => o.Invoice_ClientIds).HasForeignKey(o => o.ClientId).WillCascadeOnDelete(false);
            // HasRequired(c => c.CompanyOffice_OfficeId).WithMany(o => o.Invoice_OfficeIds).HasForeignKey(o => o.OfficeId).WillCascadeOnDelete(false);
             ToTable("Invoice");
 

        }
    }
}
