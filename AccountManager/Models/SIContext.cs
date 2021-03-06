using AccountManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace AccountManager.Models
{
    public class SIContext : DbContext
    {
	 
        public SIContext(): base("name=SIConnectionString")
        {
        }

         
		public virtual DbSet<Role> Roles { get; set; }
		public virtual DbSet<User> Users { get; set; }
		public virtual DbSet<RoleUser> RoleUsers { get; set; }
		public virtual DbSet<Menu> Menus { get; set; }
		public virtual DbSet<MenuPermission> MenuPermissions { get; set; }
		public virtual DbSet<Currency> Currencys { get; set; }
		public virtual DbSet<FinancialYear> FinancialYears { get; set; }
		public virtual DbSet<Invoice> Invoices { get; set; }
		public virtual DbSet<PaymentStatus> PaymentStatuss { get; set; }
		public virtual DbSet<InvoiceItem> InvoiceItems { get; set; }
		public virtual DbSet<QuantityUnit> QuantityUnits { get; set; }
		public virtual DbSet<InvoiceTransaction> InvoiceTransactions { get; set; }
		public virtual DbSet<Transaction> Transactions { get; set; }
		public virtual DbSet<AccountHolders> AccountHolders { get; set; }


		
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
			//Database.SetInitializer<SIContext>(null);
			modelBuilder.Configurations.Add(new AccountManager.Maping.RoleMap());
			modelBuilder.Configurations.Add(new AccountManager.Maping.UserMap());
			modelBuilder.Configurations.Add(new AccountManager.Maping.RoleUserMap());
			modelBuilder.Configurations.Add(new AccountManager.Maping.MenuMap());
			modelBuilder.Configurations.Add(new AccountManager.Maping.MenuPermissionMap());	
			modelBuilder.Configurations.Add(new AccountManager.Maping.CurrencyMap());
			modelBuilder.Configurations.Add(new AccountManager.Maping.FinancialYearMap());
			modelBuilder.Configurations.Add(new AccountManager.Maping.InvoiceMap());
			modelBuilder.Configurations.Add(new AccountManager.Maping.PaymentStatusMap());
			modelBuilder.Configurations.Add(new AccountManager.Maping.InvoiceItemMap());
			modelBuilder.Configurations.Add(new AccountManager.Maping.QuantityUnitMap());
			modelBuilder.Configurations.Add(new AccountManager.Maping.InvoiceTransactionMap());
			modelBuilder.Configurations.Add(new AccountManager.Maping.TransactionMap());
			modelBuilder.Configurations.Add(new AccountManager.Maping.AccountHoldersMap());


			base.OnModelCreating(modelBuilder);
        }

        
    }
}
 
