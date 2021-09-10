namespace AccountManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TransactionTable : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.Transaction", "CreditAccount", "dbo.LedgerAccountType");
            //DropForeignKey("dbo.Transaction", "DebitAccount", "dbo.LedgerAccountType");
            //DropIndex("dbo.Transaction", new[] { "CreditAccount" });
            //DropIndex("dbo.Transaction", new[] { "DebitAccount" });
            //AlterColumn("dbo.Transaction", "DebitAccount", c => c.Int());
            //AlterColumn("dbo.Transaction", "CreditAccount", c => c.Int());
            //CreateIndex("dbo.Transaction", "CreditAccount");
            //CreateIndex("dbo.Transaction", "DebitAccount");
            //AddForeignKey("dbo.Transaction", "CreditAccount", "dbo.LedgerAccountType", "Id");
            //AddForeignKey("dbo.Transaction", "DebitAccount", "dbo.LedgerAccountType", "Id");
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.Transaction", "DebitAccount", "dbo.LedgerAccountType");
            //DropForeignKey("dbo.Transaction", "CreditAccount", "dbo.LedgerAccountType");
            //DropIndex("dbo.Transaction", new[] { "DebitAccount" });
            //DropIndex("dbo.Transaction", new[] { "CreditAccount" });
            //AlterColumn("dbo.Transaction", "CreditAccount", c => c.Int(nullable: false));
            //AlterColumn("dbo.Transaction", "DebitAccount", c => c.Int(nullable: false));
            //CreateIndex("dbo.Transaction", "DebitAccount");
            //CreateIndex("dbo.Transaction", "CreditAccount");
            //AddForeignKey("dbo.Transaction", "DebitAccount", "dbo.LedgerAccountType", "Id");
            //AddForeignKey("dbo.Transaction", "CreditAccount", "dbo.LedgerAccountType", "Id");
        }
    }
}
