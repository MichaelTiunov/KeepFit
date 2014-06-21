namespace KeepFit.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductTypeDescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductTypes", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductTypes", "Description");
        }
    }
}
