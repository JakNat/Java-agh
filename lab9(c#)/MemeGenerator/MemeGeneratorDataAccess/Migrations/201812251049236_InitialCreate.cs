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
                        MemeTitle = c.String(),
                        Content = c.Binary(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedById = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MemeId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Memes");
        }
    }
}
