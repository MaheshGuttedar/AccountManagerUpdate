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
            Property(o => o.Name).HasMaxLength(150);
            Property(o => o.Address).HasMaxLength(1050);
            Property(o => o.Mobile).HasMaxLength(13);
            Property(o => o.GuarantorName).HasMaxLength(150);
            Property(o => o.GuarantorAddress).HasMaxLength(1050);
            Property(o => o.GuarantorMobile).HasMaxLength(13);          
            Property(o => o.Cell).HasMaxLength(100);
            Property(o => o.RegNo).HasMaxLength(100);
            Property(o => o.Model).HasMaxLength(100);            
            Property(o => o.Make).HasMaxLength(100);      
            Property(o => o.ChassisNo).HasMaxLength(100);
            Property(o => o.EngineNo).HasMaxLength(100);
            Property(o => o.InsuranceUpto).HasMaxLength(10);
            Property(o => o.DueDate).HasMaxLength(10);
            Property(o => o.LoanAdvanceDate).HasMaxLength(10);
            Property(o => o.IsActive);
            Property(o => o.CompanyId);
            Property(o => o.AccountId);
            Property(o => o.CreatedDate);
            Property(o => o.CreatedBy);
            Property(o => o.YearId);
            Property(o => o.TotalInstallments);
            Property(o => o.LoanAdvance);
            Property(o => o.InstallmentAmount);
            Property(o => o.Status);
            Property(o => o.AccountNoFromRegister);
            Property(o => o.CustomerPhoto);
            ToTable("AccountHolders");


        }
    }
}
