namespace KeepFit.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Excercises : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExcerciseCategories",
                c => new
                    {
                        ExcerciseCategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(nullable: false, maxLength: 200),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.ExcerciseCategoryId);
            
            CreateTable(
                "dbo.Excercises",
                c => new
                    {
                        ExcerciseId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        ExcerciseCategoryId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(nullable: false, maxLength: 200),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.ExcerciseId)
                .ForeignKey("dbo.ExcerciseCategories", t => t.ExcerciseCategoryId)
                .Index(t => t.ExcerciseCategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Excercises", "ExcerciseCategoryId", "dbo.ExcerciseCategories");
            DropIndex("dbo.Excercises", new[] { "ExcerciseCategoryId" });
            DropTable("dbo.Excercises");
            DropTable("dbo.ExcerciseCategories");
        }
    }
}
