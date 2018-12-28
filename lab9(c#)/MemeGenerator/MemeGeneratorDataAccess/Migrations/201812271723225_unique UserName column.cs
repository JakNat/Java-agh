namespace MemeGeneratorDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class uniqueUserNamecolumn : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "UserName", c => c.String(nullable: false, maxLength: 450));
            CreateIndex("dbo.Users", "UserName", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", new[] { "UserName" });
            AlterColumn("dbo.Users", "UserName", c => c.String(nullable: false));
        }
    }
}
