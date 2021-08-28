namespace AccountManager.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AccountManager.Models.SIContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

//        protected override void Seed(AccountManager.Models.SIContext context)
//        {
//             string query = string.Format(@"if not exists(select * from [Menu])
//begin 
//declare @RoleM int=null
//insert into Menu (MenuText,MenuURL,ParentId) values('Role','root',NULL) SET @RoleM= (SELECT SCOPE_IDENTITY())
//declare @2 int=null
//insert into Menu (MenuText,MenuURL,ParentId) values('List Role','Role',@RoleM) SET @2= (SELECT SCOPE_IDENTITY())
//declare @UserM int=null
//insert into Menu (MenuText,MenuURL,ParentId) values('User','root',NULL) SET @UserM= (SELECT SCOPE_IDENTITY())
//declare @4 int=null
//insert into Menu (MenuText,MenuURL,ParentId) values('List User','User',@UserM) SET @4= (SELECT SCOPE_IDENTITY())
//declare @RoleUserM int=null
//insert into Menu (MenuText,MenuURL,ParentId) values('RoleUser','root',NULL) SET @RoleUserM= (SELECT SCOPE_IDENTITY())
//declare @6 int=null
//insert into Menu (MenuText,MenuURL,ParentId) values('List Role User','RoleUser',@RoleUserM) SET @6= (SELECT SCOPE_IDENTITY())
//declare @MenuM int=null
//insert into Menu (MenuText,MenuURL,ParentId) values('Menu','root',NULL) SET @MenuM= (SELECT SCOPE_IDENTITY())
//declare @8 int=null
//insert into Menu (MenuText,MenuURL,ParentId) values('List Menu','Menu',@MenuM) SET @8= (SELECT SCOPE_IDENTITY())
//declare @MenuPermissionM int=null
//insert into Menu (MenuText,MenuURL,ParentId) values('MenuPermission','root',NULL) SET @MenuPermissionM= (SELECT SCOPE_IDENTITY())
//declare @10 int=null
//insert into Menu (MenuText,MenuURL,ParentId) values('List Menu Permission','MenuPermission',@MenuPermissionM) SET @10= (SELECT SCOPE_IDENTITY())
//declare @CompanyClientM int=null
//insert into Menu (MenuText,MenuURL,ParentId) values('CompanyClient','root',NULL) SET @CompanyClientM= (SELECT SCOPE_IDENTITY())
//declare @12 int=null
//insert into Menu (MenuText,MenuURL,ParentId) values('List Company Client','CompanyClient',@CompanyClientM) SET @12= (SELECT SCOPE_IDENTITY())
//declare @CurrencyM int=null
//insert into Menu (MenuText,MenuURL,ParentId) values('Currency','root',NULL) SET @CurrencyM= (SELECT SCOPE_IDENTITY())
//declare @14 int=null
//insert into Menu (MenuText,MenuURL,ParentId) values('List Currency','Currency',@CurrencyM) SET @14= (SELECT SCOPE_IDENTITY())
//declare @FinancialYearM int=null
//insert into Menu (MenuText,MenuURL,ParentId) values('FinancialYear','root',NULL) SET @FinancialYearM= (SELECT SCOPE_IDENTITY())
//declare @16 int=null
//insert into Menu (MenuText,MenuURL,ParentId) values('List Financial Year','FinancialYear',@FinancialYearM) SET @16= (SELECT SCOPE_IDENTITY())
//declare @InvoiceM int=null
//insert into Menu (MenuText,MenuURL,ParentId) values('Invoice','root',NULL) SET @InvoiceM= (SELECT SCOPE_IDENTITY())
//declare @18 int=null
//insert into Menu (MenuText,MenuURL,ParentId) values('List Invoice','Invoice',@InvoiceM) SET @18= (SELECT SCOPE_IDENTITY())
//declare @PaymentStatusM int=null
//insert into Menu (MenuText,MenuURL,ParentId) values('PaymentStatus','root',NULL) SET @PaymentStatusM= (SELECT SCOPE_IDENTITY())
//declare @20 int=null
//insert into Menu (MenuText,MenuURL,ParentId) values('List Payment Status','PaymentStatus',@PaymentStatusM) SET @20= (SELECT SCOPE_IDENTITY())
//declare @CompanyM int=null
//insert into Menu (MenuText,MenuURL,ParentId) values('Company','root',NULL) SET @CompanyM= (SELECT SCOPE_IDENTITY())
//declare @22 int=null
//insert into Menu (MenuText,MenuURL,ParentId) values('List Company','Company',@CompanyM) SET @22= (SELECT SCOPE_IDENTITY())
//declare @CompanyAccountM int=null
//insert into Menu (MenuText,MenuURL,ParentId) values('CompanyAccount','root',NULL) SET @CompanyAccountM= (SELECT SCOPE_IDENTITY())
//declare @24 int=null
//insert into Menu (MenuText,MenuURL,ParentId) values('List Company Account','CompanyAccount',@CompanyAccountM) SET @24= (SELECT SCOPE_IDENTITY())
//declare @InvoiceItemM int=null
//insert into Menu (MenuText,MenuURL,ParentId) values('InvoiceItem','root',NULL) SET @InvoiceItemM= (SELECT SCOPE_IDENTITY())
//declare @26 int=null
//insert into Menu (MenuText,MenuURL,ParentId) values('List Invoice Item','InvoiceItem',@InvoiceItemM) SET @26= (SELECT SCOPE_IDENTITY())
//declare @QuantityUnitM int=null
//insert into Menu (MenuText,MenuURL,ParentId) values('QuantityUnit','root',NULL) SET @QuantityUnitM= (SELECT SCOPE_IDENTITY())
//declare @28 int=null
//insert into Menu (MenuText,MenuURL,ParentId) values('List Quantity Unit','QuantityUnit',@QuantityUnitM) SET @28= (SELECT SCOPE_IDENTITY())
//declare @LedgerAccountTypeM int=null
//insert into Menu (MenuText,MenuURL,ParentId) values('LedgerAccountType','root',NULL) SET @LedgerAccountTypeM= (SELECT SCOPE_IDENTITY())
//declare @30 int=null
//insert into Menu (MenuText,MenuURL,ParentId) values('List Ledger Account Type','LedgerAccountType',@LedgerAccountTypeM) SET @30= (SELECT SCOPE_IDENTITY())
//declare @ProductCategoryM int=null
//insert into Menu (MenuText,MenuURL,ParentId) values('ProductCategory','root',NULL) SET @ProductCategoryM= (SELECT SCOPE_IDENTITY())
//declare @32 int=null
//insert into Menu (MenuText,MenuURL,ParentId) values('List Product Category','ProductCategory',@ProductCategoryM) SET @32= (SELECT SCOPE_IDENTITY())
//declare @ProductM int=null
//insert into Menu (MenuText,MenuURL,ParentId) values('Product','root',NULL) SET @ProductM= (SELECT SCOPE_IDENTITY())
//declare @34 int=null
//insert into Menu (MenuText,MenuURL,ParentId) values('List Product','Product',@ProductM) SET @34= (SELECT SCOPE_IDENTITY())
//declare @InvoiceTransactionM int=null
//insert into Menu (MenuText,MenuURL,ParentId) values('InvoiceTransaction','root',NULL) SET @InvoiceTransactionM= (SELECT SCOPE_IDENTITY())
//declare @36 int=null
//insert into Menu (MenuText,MenuURL,ParentId) values('List Invoice Transaction','InvoiceTransaction',@InvoiceTransactionM) SET @36= (SELECT SCOPE_IDENTITY())
//declare @TransactionM int=null
//insert into Menu (MenuText,MenuURL,ParentId) values('Transaction','root',NULL) SET @TransactionM= (SELECT SCOPE_IDENTITY())
//declare @38 int=null
//insert into Menu (MenuText,MenuURL,ParentId) values('List Transaction','Transaction',@TransactionM) SET @38= (SELECT SCOPE_IDENTITY())
//declare @OfficeTypeM int=null
//insert into Menu (MenuText,MenuURL,ParentId) values('OfficeType','root',NULL) SET @OfficeTypeM= (SELECT SCOPE_IDENTITY())
//declare @40 int=null
//insert into Menu (MenuText,MenuURL,ParentId) values('List Office Type','OfficeType',@OfficeTypeM) SET @40= (SELECT SCOPE_IDENTITY())
//declare @CompanyOfficeM int=null
//insert into Menu (MenuText,MenuURL,ParentId) values('CompanyOffice','root',NULL) SET @CompanyOfficeM= (SELECT SCOPE_IDENTITY())
//declare @42 int=null
//insert into Menu (MenuText,MenuURL,ParentId) values('List Company Office','CompanyOffice',@CompanyOfficeM) SET @42= (SELECT SCOPE_IDENTITY())
//declare @rolew int=null
//insert into Role (RoleName,IsActive) values('Admin',1) SET @rolew= (SELECT SCOPE_IDENTITY())
//end
//"); context.Database.ExecuteSqlCommand(query);
//        }
    }
}
