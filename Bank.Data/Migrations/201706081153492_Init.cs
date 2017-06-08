namespace Bank.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        AccountId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Balance = c.Double(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Customer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.AccountId)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .Index(t => t.Customer_Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        CompanyName = c.String(),
                        VATNo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Double(nullable: false),
                        Timstamp = c.DateTime(nullable: false),
                        Account_AccountId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.Account_AccountId)
                .Index(t => t.Account_AccountId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "Account_AccountId", "dbo.Accounts");
            DropForeignKey("dbo.Accounts", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Transactions", new[] { "Account_AccountId" });
            DropIndex("dbo.Accounts", new[] { "Customer_Id" });
            DropTable("dbo.Transactions");
            DropTable("dbo.Customers");
            DropTable("dbo.Accounts");
        }
    }
}
