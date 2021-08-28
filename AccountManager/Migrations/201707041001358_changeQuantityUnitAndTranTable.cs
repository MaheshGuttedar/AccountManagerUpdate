namespace AccountManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeQuantityUnitAndTranTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.QuantityUnit", "Title", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.QuantityUnit", "Title", c => c.Int(nullable: false));
        }
    }
}
