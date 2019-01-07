namespace MemeGeneratorDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Memes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MemeTitle = c.String(),
                        Content = c.Binary(),
                        CreatedDate = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 450),
                        Password = c.String(nullable: false),
                        Email = c.String(),
                        CreatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Memes", "UserId", "dbo.Users");
            DropIndex("dbo.Memes", new[] { "UserId" });
            DropTable("dbo.Users");
            DropTable("dbo.Memes");
        }
    }
}
