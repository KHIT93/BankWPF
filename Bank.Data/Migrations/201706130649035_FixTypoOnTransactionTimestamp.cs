namespace Bank.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixTypoOnTransactionTimestamp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transactions", "Timestamp", c => c.DateTime(nullable: false));
            DropColumn("dbo.Transactions", "Timstamp");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transactions", "Timstamp", c => c.DateTime(nullable: false));
            DropColumn("dbo.Transactions", "Timestamp");
        }
    }
}
