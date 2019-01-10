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
                        MemeId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.Binary(),
                        CreatedDate = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MemeId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 450),
                        Password = c.String(nullable: false),
                        Email = c.String(),
                        CreatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.UserId);
            
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
