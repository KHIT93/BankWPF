namespace Bank.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Transactions", "User_Id", c => c.Int());
            CreateIndex("dbo.Transactions", "User_Id");
            AddForeignKey("dbo.Transactions", "User_Id", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "User_Id", "dbo.Users");
            DropIndex("dbo.Transactions", new[] { "User_Id" });
            DropColumn("dbo.Transactions", "User_Id");
            DropTable("dbo.Users");
        }
    }
}
