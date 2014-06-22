namespace KeepFit.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.IndividualRoles", "RoleId", "dbo.Roles");
            DropPrimaryKey("dbo.Roles");
            AlterColumn("dbo.Addresses", "AddressLine1", c => c.String());
            AlterColumn("dbo.Addresses", "AddressLine2", c => c.String());
            AlterColumn("dbo.Addresses", "City", c => c.String());
            AlterColumn("dbo.Addresses", "Zip", c => c.String());
            AlterColumn("dbo.Addresses", "CreatedBy", c => c.String());
            AlterColumn("dbo.Addresses", "UpdatedBy", c => c.String());
            AlterColumn("dbo.Countries", "Name", c => c.String());
            AlterColumn("dbo.Countries", "ShortName", c => c.String());
            AlterColumn("dbo.Countries", "CreatedBy", c => c.String());
            AlterColumn("dbo.Countries", "UpdatedBy", c => c.String());
            AlterColumn("dbo.States", "Name", c => c.String());
            AlterColumn("dbo.States", "CreatedBy", c => c.String());
            AlterColumn("dbo.States", "UpdatedBy", c => c.String());
            AlterColumn("dbo.Individuals", "FirstName", c => c.String());
            AlterColumn("dbo.Individuals", "MiddleName", c => c.String());
            AlterColumn("dbo.Individuals", "LastName", c => c.String());
            AlterColumn("dbo.Individuals", "EmailAddress", c => c.String());
            AlterColumn("dbo.Individuals", "CreatedBy", c => c.String());
            AlterColumn("dbo.Individuals", "UpdatedBy", c => c.String());
            AlterColumn("dbo.IndividualRoles", "CreatedBy", c => c.String());
            AlterColumn("dbo.IndividualRoles", "UpdatedBy", c => c.String());
            AlterColumn("dbo.Roles", "RoleId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Roles", "RoleName", c => c.String());
            AlterColumn("dbo.Roles", "CreatedBy", c => c.String());
            AlterColumn("dbo.Roles", "UpdatedBy", c => c.String());
            AlterColumn("dbo.Users", "Username", c => c.String());
            AlterColumn("dbo.Users", "CreatedBy", c => c.String());
            AlterColumn("dbo.Users", "UpdatedBy", c => c.String());
            AlterColumn("dbo.BodyCompositions", "CreatedBy", c => c.String());
            AlterColumn("dbo.BodyCompositions", "UpdatedBy", c => c.String());
            AlterColumn("dbo.Ingestions", "CreatedBy", c => c.String());
            AlterColumn("dbo.Ingestions", "UpdatedBy", c => c.String());
            AlterColumn("dbo.Pictures", "CreatedBy", c => c.String());
            AlterColumn("dbo.Pictures", "UpdatedBy", c => c.String());
            AlterColumn("dbo.Excercises", "CreatedBy", c => c.String());
            AlterColumn("dbo.Excercises", "UpdatedBy", c => c.String());
            AlterColumn("dbo.ExcerciseCategories", "CreatedBy", c => c.String());
            AlterColumn("dbo.ExcerciseCategories", "UpdatedBy", c => c.String());
            AlterColumn("dbo.Reps", "CreatedBy", c => c.String());
            AlterColumn("dbo.Reps", "UpdatedBy", c => c.String());
            AlterColumn("dbo.Sets", "CreatedBy", c => c.String());
            AlterColumn("dbo.Sets", "UpdatedBy", c => c.String());
            AlterColumn("dbo.Workouts", "CreatedBy", c => c.String());
            AlterColumn("dbo.Workouts", "UpdatedBy", c => c.String());
            AlterColumn("dbo.Menus", "CreatedBy", c => c.String());
            AlterColumn("dbo.Menus", "UpdatedBy", c => c.String());
            AlterColumn("dbo.PasswordChanges", "NewPassword", c => c.String());
            AlterColumn("dbo.PasswordChanges", "CreatedBy", c => c.String());
            AlterColumn("dbo.PasswordChanges", "UpdatedBy", c => c.String());
            AlterColumn("dbo.ProgressPhotoes", "CreatedBy", c => c.String());
            AlterColumn("dbo.ProgressPhotoes", "UpdatedBy", c => c.String());
            AddPrimaryKey("dbo.Roles", "RoleId");
            AddForeignKey("dbo.IndividualRoles", "RoleId", "dbo.Roles", "RoleId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IndividualRoles", "RoleId", "dbo.Roles");
            DropPrimaryKey("dbo.Roles");
            AlterColumn("dbo.ProgressPhotoes", "UpdatedBy", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.ProgressPhotoes", "CreatedBy", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.PasswordChanges", "UpdatedBy", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.PasswordChanges", "CreatedBy", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.PasswordChanges", "NewPassword", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Menus", "UpdatedBy", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Menus", "CreatedBy", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Workouts", "UpdatedBy", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Workouts", "CreatedBy", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Sets", "UpdatedBy", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Sets", "CreatedBy", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Reps", "UpdatedBy", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Reps", "CreatedBy", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.ExcerciseCategories", "UpdatedBy", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.ExcerciseCategories", "CreatedBy", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Excercises", "UpdatedBy", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Excercises", "CreatedBy", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Pictures", "UpdatedBy", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Pictures", "CreatedBy", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Ingestions", "UpdatedBy", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Ingestions", "CreatedBy", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.BodyCompositions", "UpdatedBy", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.BodyCompositions", "CreatedBy", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Users", "UpdatedBy", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Users", "CreatedBy", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Users", "Username", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Roles", "UpdatedBy", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Roles", "CreatedBy", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Roles", "RoleName", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Roles", "RoleId", c => c.Int(nullable: false));
            AlterColumn("dbo.IndividualRoles", "UpdatedBy", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.IndividualRoles", "CreatedBy", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Individuals", "UpdatedBy", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Individuals", "CreatedBy", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Individuals", "EmailAddress", c => c.String(maxLength: 200));
            AlterColumn("dbo.Individuals", "LastName", c => c.String(maxLength: 200));
            AlterColumn("dbo.Individuals", "MiddleName", c => c.String(maxLength: 200));
            AlterColumn("dbo.Individuals", "FirstName", c => c.String(maxLength: 200));
            AlterColumn("dbo.States", "UpdatedBy", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.States", "CreatedBy", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.States", "Name", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Countries", "UpdatedBy", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Countries", "CreatedBy", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Countries", "ShortName", c => c.String(nullable: false, maxLength: 4));
            AlterColumn("dbo.Countries", "Name", c => c.String(nullable: false, maxLength: 400));
            AlterColumn("dbo.Addresses", "UpdatedBy", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Addresses", "CreatedBy", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Addresses", "Zip", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Addresses", "City", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Addresses", "AddressLine2", c => c.String(maxLength: 200));
            AlterColumn("dbo.Addresses", "AddressLine1", c => c.String(nullable: false, maxLength: 200));
            AddPrimaryKey("dbo.Roles", "RoleId");
            AddForeignKey("dbo.IndividualRoles", "RoleId", "dbo.Roles", "RoleId");
        }
    }
}
