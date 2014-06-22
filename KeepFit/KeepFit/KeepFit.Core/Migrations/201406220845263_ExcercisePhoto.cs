namespace KeepFit.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExcercisePhoto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Excercises", "ExcercisePhoto", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Excercises", "ExcercisePhoto");
        }
    }
}
