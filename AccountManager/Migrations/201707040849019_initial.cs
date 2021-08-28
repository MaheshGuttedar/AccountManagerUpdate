namespace AccountManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CompanyAccount",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false, maxLength: 50),
                        URL = c.String(maxLength: 150),
                        Usename = c.String(nullable: false, maxLength: 100),
                        Password = c.String(nullable: false, maxLength: 50),
                        CompanyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Company", t => t.CompanyId)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.Company",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        About = c.String(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Website = c.String(maxLength: 100),
                        Phone = c.String(maxLength: 13),
                        Fax = c.String(maxLength: 15),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CompanyClient",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyId = c.Int(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        IsActive = c.Boolean(nullable: false),
                        Email = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Company", t => t.CompanyId)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.CompanyOffice",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        Code = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        OfficeTypeId = c.Int(nullable: false),
                        CompanyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Company", t => t.CompanyId)
                .ForeignKey("dbo.OfficeType", t => t.OfficeTypeId)
                .Index(t => t.CompanyId)
                .Index(t => t.OfficeTypeId);
            
            CreateTable(
                "dbo.Invoice",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BillDate = c.DateTime(nullable: false),
                        DueDate = c.DateTime(),
                        Status = c.Int(nullable: false),
                        LastEmailed = c.DateTime(),
                        OtherInvoiceCode = c.String(maxLength: 50),
                        ClientId = c.Int(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        OfficeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CompanyOffice", t => t.OfficeId)
                .ForeignKey("dbo.PaymentStatus", t => t.Status)
                .ForeignKey("dbo.User", t => t.ClientId)
                .Index(t => t.OfficeId)
                .Index(t => t.Status)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.InvoiceItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InvoiceId = c.Int(nullable: false),
                        Description = c.String(maxLength: 200),
                        Title = c.String(nullable: false, maxLength: 50),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnitName = c.Int(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Invoice", t => t.InvoiceId)
                .ForeignKey("dbo.QuantityUnit", t => t.UnitName)
                .Index(t => t.InvoiceId)
                .Index(t => t.UnitName);
            
            CreateTable(
                "dbo.QuantityUnit",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.InvoiceTransaction",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TransactionId = c.Int(nullable: false),
                        InvoiceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Invoice", t => t.InvoiceId)
                .ForeignKey("dbo.Transaction", t => t.TransactionId)
                .Index(t => t.InvoiceId)
                .Index(t => t.TransactionId);
            
            CreateTable(
                "dbo.Transaction",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        DateAdded = c.DateTime(nullable: false),
                        AddedBy = c.Int(nullable: false),
                        OfficeId = c.Int(nullable: false),
                        DebitAccount = c.Int(nullable: false),
                        DebitAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreditAccount = c.Int(nullable: false),
                        CreditAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TransactionDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CompanyOffice", t => t.OfficeId)
                .ForeignKey("dbo.LedgerAccountType", t => t.CreditAccount)
                .ForeignKey("dbo.LedgerAccountType", t => t.DebitAccount)
                .Index(t => t.OfficeId)
                .Index(t => t.CreditAccount)
                .Index(t => t.DebitAccount);
            
            CreateTable(
                "dbo.LedgerAccountType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        ParentId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LedgerAccountType", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.PaymentStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 100),
                        Password = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MenuPermission",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MenuId = c.Int(),
                        RoleId = c.Int(nullable: false),
                        UserId = c.Int(),
                        SortOrder = c.Int(),
                        IsCreate = c.Boolean(nullable: false),
                        IsRead = c.Boolean(nullable: false),
                        IsUpdate = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Menu", t => t.MenuId)
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.MenuId)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Menu",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MenuText = c.String(nullable: false, maxLength: 100),
                        MenuURL = c.String(nullable: false, maxLength: 400),
                        ParentId = c.Int(),
                        SortOrder = c.Int(),
                        MenuIcon = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Menu", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleName = c.String(nullable: false, maxLength: 50),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RoleUser",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.OfficeType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Level = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        PurchaseCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SalePrice = c.Decimal(precision: 18, scale: 2),
                        OfficeId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        ProductImage = c.String(maxLength: 200),
                        BareCode = c.String(maxLength: 50),
                        Description = c.String(),
                        ReOrderValue = c.Int(),
                        Stock = c.Int(nullable: false),
                        MinStockValue = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CompanyOffice", t => t.OfficeId)
                .Index(t => t.OfficeId);
            
            CreateTable(
                "dbo.Currency",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Code = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FinancialYear",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        ParentId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductCategory", t => t.ParentId)
                .Index(t => t.ParentId);

            CreateTable(
       "dbo.AccountHolders",
       c => new
       {
           Id = c.Int(nullable: false, identity: true),
           CompanyId = c.Int(nullable: true),
           FirstName = c.String(nullable: true),
           LastName = c.String(nullable: true),
           Email = c.String(nullable: true),
           IsActive = c.Boolean(nullable: true),
       })
       .PrimaryKey(t => t.Id);

        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductCategory", "ParentId", "dbo.ProductCategory");
            DropForeignKey("dbo.CompanyAccount", "CompanyId", "dbo.Company");
            DropForeignKey("dbo.Product", "OfficeId", "dbo.CompanyOffice");
            DropForeignKey("dbo.CompanyOffice", "OfficeTypeId", "dbo.OfficeType");
            DropForeignKey("dbo.Invoice", "ClientId", "dbo.User");
            DropForeignKey("dbo.MenuPermission", "UserId", "dbo.User");
            DropForeignKey("dbo.MenuPermission", "RoleId", "dbo.Role");
            DropForeignKey("dbo.RoleUser", "UserId", "dbo.User");
            DropForeignKey("dbo.RoleUser", "RoleId", "dbo.Role");
            DropForeignKey("dbo.MenuPermission", "MenuId", "dbo.Menu");
            DropForeignKey("dbo.Menu", "ParentId", "dbo.Menu");
            DropForeignKey("dbo.Invoice", "Status", "dbo.PaymentStatus");
            DropForeignKey("dbo.InvoiceTransaction", "TransactionId", "dbo.Transaction");
            DropForeignKey("dbo.Transaction", "DebitAccount", "dbo.LedgerAccountType");
            DropForeignKey("dbo.Transaction", "CreditAccount", "dbo.LedgerAccountType");
            DropForeignKey("dbo.LedgerAccountType", "ParentId", "dbo.LedgerAccountType");
            DropForeignKey("dbo.Transaction", "OfficeId", "dbo.CompanyOffice");
            DropForeignKey("dbo.InvoiceTransaction", "InvoiceId", "dbo.Invoice");
            DropForeignKey("dbo.InvoiceItem", "UnitName", "dbo.QuantityUnit");
            DropForeignKey("dbo.InvoiceItem", "InvoiceId", "dbo.Invoice");
            DropForeignKey("dbo.Invoice", "OfficeId", "dbo.CompanyOffice");
            DropForeignKey("dbo.CompanyOffice", "CompanyId", "dbo.Company");
            DropForeignKey("dbo.CompanyClient", "CompanyId", "dbo.Company");
            DropIndex("dbo.ProductCategory", new[] { "ParentId" });
            DropIndex("dbo.CompanyAccount", new[] { "CompanyId" });
            DropIndex("dbo.Product", new[] { "OfficeId" });
            DropIndex("dbo.CompanyOffice", new[] { "OfficeTypeId" });
            DropIndex("dbo.Invoice", new[] { "ClientId" });
            DropIndex("dbo.MenuPermission", new[] { "UserId" });
            DropIndex("dbo.MenuPermission", new[] { "RoleId" });
            DropIndex("dbo.RoleUser", new[] { "UserId" });
            DropIndex("dbo.RoleUser", new[] { "RoleId" });
            DropIndex("dbo.MenuPermission", new[] { "MenuId" });
            DropIndex("dbo.Menu", new[] { "ParentId" });
            DropIndex("dbo.Invoice", new[] { "Status" });
            DropIndex("dbo.InvoiceTransaction", new[] { "TransactionId" });
            DropIndex("dbo.Transaction", new[] { "DebitAccount" });
            DropIndex("dbo.Transaction", new[] { "CreditAccount" });
            DropIndex("dbo.LedgerAccountType", new[] { "ParentId" });
            DropIndex("dbo.Transaction", new[] { "OfficeId" });
            DropIndex("dbo.InvoiceTransaction", new[] { "InvoiceId" });
            DropIndex("dbo.InvoiceItem", new[] { "UnitName" });
            DropIndex("dbo.InvoiceItem", new[] { "InvoiceId" });
            DropIndex("dbo.Invoice", new[] { "OfficeId" });
            DropIndex("dbo.CompanyOffice", new[] { "CompanyId" });
            DropIndex("dbo.CompanyClient", new[] { "CompanyId" });
            DropTable("dbo.ProductCategory");
            DropTable("dbo.FinancialYear");
            DropTable("dbo.Currency");
            DropTable("dbo.Product");
            DropTable("dbo.OfficeType");
            DropTable("dbo.RoleUser");
            DropTable("dbo.Role");
            DropTable("dbo.Menu");
            DropTable("dbo.MenuPermission");
            DropTable("dbo.User");
            DropTable("dbo.PaymentStatus");
            DropTable("dbo.LedgerAccountType");
            DropTable("dbo.Transaction");
            DropTable("dbo.InvoiceTransaction");
            DropTable("dbo.QuantityUnit");
            DropTable("dbo.InvoiceItem");
            DropTable("dbo.Invoice");
            DropTable("dbo.CompanyOffice");
            DropTable("dbo.CompanyClient");
            DropTable("dbo.Company");
            DropTable("dbo.CompanyAccount");
        }
    }
}
