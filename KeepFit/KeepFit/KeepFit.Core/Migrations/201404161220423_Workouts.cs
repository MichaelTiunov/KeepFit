namespace KeepFit.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Workouts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Workouts",
                c => new
                    {
                        WorkoutId = c.Int(nullable: false, identity: true),
                        WorkoutDate = c.DateTime(nullable: false),
                        Name = c.String(),
                        IsPublic = c.Boolean(nullable: false),
                        Duration = c.Double(nullable: false),
                        UserId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(nullable: false, maxLength: 200),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.WorkoutId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Workouts", "UserId", "dbo.Users");
            DropIndex("dbo.Workouts", new[] { "UserId" });
            DropTable("dbo.Workouts");
        }
    }
}
