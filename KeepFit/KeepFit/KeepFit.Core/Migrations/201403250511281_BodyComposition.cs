namespace KeepFit.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BodyComposition : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BodyCompositions",
                c => new
                    {
                        BodyCompositionId = c.Int(nullable: false, identity: true),
                        Height = c.Double(nullable: false),
                        Weight = c.Double(nullable: false),
                        UserId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(nullable: false, maxLength: 200),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.BodyCompositionId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BodyCompositions", "UserId", "dbo.Users");
            DropIndex("dbo.BodyCompositions", new[] { "UserId" });
            DropTable("dbo.BodyCompositions");
        }
    }
}
