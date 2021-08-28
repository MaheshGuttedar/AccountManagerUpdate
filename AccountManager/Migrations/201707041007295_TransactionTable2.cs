namespace AccountManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TransactionTable2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Transaction", "DebitAmount", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Transaction", "CreditAmount", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Transaction", "CreditAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Transaction", "DebitAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
