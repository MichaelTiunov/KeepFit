namespace KeepFit.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class useringestions : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ingestions", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Ingestions", "UserId");
            AddForeignKey("dbo.Ingestions", "UserId", "dbo.Users", "UserId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ingestions", "UserId", "dbo.Users");
            DropIndex("dbo.Ingestions", new[] { "UserId" });
            DropColumn("dbo.Ingestions", "UserId");
        }
    }
}
