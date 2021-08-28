using AccountManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace AccountManager.Maping
{
    public class AccountHoldersMap : EntityTypeConfiguration<AccountHolders> 
    {
        public AccountHoldersMap()
        {
             
            HasKey(o => o.Id);
            Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(o => o.FirstName).HasMaxLength(100);
            Property(o => o.LastName).HasMaxLength(100);
            Property(o => o.CompanyId);
            Property(o => o.Email).HasMaxLength(500);
            //Property(o => o.Address).HasMaxLength(500);
            //Property(o => o.Cell).HasMaxLength(50);
            //Property(o => o.RegNo).HasMaxLength(100);
            //Property(o => o.Model).HasMaxLength(150);
            //Property(o => o.Mobile).HasMaxLength(10);
            //Property(o => o.Make).HasMaxLength(200);
            //Property(o => o.GuarantorName).HasMaxLength(150);
            //Property(o => o.GuarantorAddress).HasMaxLength(500);
            //Property(o => o.GuarantorMobile).HasMaxLength(10);
            //Property(o => o.ChassisNo).HasMaxLength(200);
            //Property(o => o.EngineNo).HasMaxLength(200);
            //Property(o => o.InsuranceUpto).HasMaxLength(15);
            //Property(o => o.DueDate).HasMaxLength(15);
            Property(o => o.IsActive);
            //Property(o => o.CreatedDate);
            //Property(o => o.CreatedBy);
            //Property(o => o.LedAccountId);
            ToTable("AccountHolders");


        }
    }
}
