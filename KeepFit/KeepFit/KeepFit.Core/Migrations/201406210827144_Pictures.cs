namespace KeepFit.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Pictures : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pictures",
                c => new
                    {
                        PictureId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(),
                        ExcerciseId = c.Int(),
                        Photo = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(nullable: false, maxLength: 200),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.PictureId)
                .ForeignKey("dbo.Excercises", t => t.ExcerciseId)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .Index(t => t.ProductId)
                .Index(t => t.ExcerciseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pictures", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Pictures", "ExcerciseId", "dbo.Excercises");
            DropIndex("dbo.Pictures", new[] { "ExcerciseId" });
            DropIndex("dbo.Pictures", new[] { "ProductId" });
            DropTable("dbo.Pictures");
        }
    }
}
