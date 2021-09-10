using AccountManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace AccountManager.Maping
{
    public class TransactionMap : EntityTypeConfiguration<Transaction> 
    {
        public TransactionMap()
        {
             HasKey(o => o.Id);
             Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
             Property(o => o.Title).HasMaxLength(200);
            // HasRequired(c => c.CompanyOffice_OfficeId).WithMany(o => o.Transaction_OfficeIds).HasForeignKey(o => o.OfficeId).WillCascadeOnDelete(false);
            // HasOptional(c => c.LedgerAccountType_DebitAccount).WithMany(o => o.Transaction_DebitAccounts).HasForeignKey(o => o.DebitAccount).WillCascadeOnDelete(false);
           // HasOptional(c => c.LedgerAccountType_CreditAccount).WithMany(o => o.Transaction_CreditAccounts).HasForeignKey(o => o.CreditAccount).WillCascadeOnDelete(false);
             ToTable("Transaction");
 

        }
    }
}
