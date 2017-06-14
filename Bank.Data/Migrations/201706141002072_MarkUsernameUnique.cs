namespace Bank.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MarkUsernameUnique : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Username", c => c.String(maxLength: 450));
            CreateIndex("dbo.Users", "Username", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", new[] { "Username" });
            AlterColumn("dbo.Users", "Username", c => c.String());
        }
    }
}
