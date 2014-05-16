namespace KeepFit.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductTypes",
                c => new
                    {
                        ProductTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                    })
                .PrimaryKey(t => t.ProductTypeId);
            
            AddColumn("dbo.Products", "ProductTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "ProductTypeId");
            AddForeignKey("dbo.Products", "ProductTypeId", "dbo.ProductTypes", "ProductTypeId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "ProductTypeId", "dbo.ProductTypes");
            DropIndex("dbo.Products", new[] { "ProductTypeId" });
            DropColumn("dbo.Products", "ProductTypeId");
            DropTable("dbo.ProductTypes");
        }
    }
}
