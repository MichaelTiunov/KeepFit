namespace KeepFit.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Improve : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.States", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.IndividualRoles", "IndividualId", "dbo.Individuals");
            DropForeignKey("dbo.Sites", "IndividualRoleId", "dbo.IndividualRoles");
            DropForeignKey("dbo.PasswordChanges", "UserId", "dbo.Users");
            DropForeignKey("dbo.Posts", "BlogId", "dbo.Blogs");
            DropForeignKey("dbo.IndividualRoles", "RoleId", "dbo.Roles");
            DropIndex("dbo.States", new[] { "CountryId" });
            DropIndex("dbo.IndividualRoles", new[] { "IndividualId" });
            DropIndex("dbo.Sites", new[] { "IndividualRoleId" });
            DropIndex("dbo.PasswordChanges", new[] { "UserId" });
            DropIndex("dbo.Posts", new[] { "BlogId" });
            DropIndex("dbo.IndividualRoles", new[] { "RoleId" });
            AlterColumn("dbo.Addresses", "AddressLine1", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Addresses", "AddressLine2", c => c.String(maxLength: 200));
            AlterColumn("dbo.Addresses", "City", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Addresses", "Zip", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Addresses", "CreatedBy", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Addresses", "UpdatedBy", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Countries", "Name", c => c.String(nullable: false, maxLength: 400));
            AlterColumn("dbo.Countries", "ShortName", c => c.String(nullable: false, maxLength: 4));
            AlterColumn("dbo.Countries", "CreatedBy", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Countries", "UpdatedBy", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.States", "Name", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.States", "CreatedBy", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.States", "UpdatedBy", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Individuals", "FirstName", c => c.String(maxLength: 200));
            AlterColumn("dbo.Individuals", "MiddleName", c => c.String(maxLength: 200));
            AlterColumn("dbo.Individuals", "LastName", c => c.String(maxLength: 200));
            AlterColumn("dbo.Individuals", "EmailAddress", c => c.String(maxLength: 200));
            AlterColumn("dbo.Individuals", "CreatedBy", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Individuals", "UpdatedBy", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.IndividualRoles", "CreatedBy", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.IndividualRoles", "UpdatedBy", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Roles", "RoleId", c => c.Int(nullable: false));
            AlterColumn("dbo.Roles", "RoleName", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Roles", "CreatedBy", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Roles", "UpdatedBy", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Users", "Username", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Users", "CreatedBy", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Users", "UpdatedBy", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.PasswordChanges", "NewPassword", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.PasswordChanges", "CreatedBy", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.PasswordChanges", "UpdatedBy", c => c.String(nullable: false, maxLength: 200));
            CreateIndex("dbo.States", "CountryId");
            CreateIndex("dbo.IndividualRoles", "IndividualId");
            CreateIndex("dbo.Sites", "IndividualRoleId");
            CreateIndex("dbo.PasswordChanges", "UserId");
            CreateIndex("dbo.Posts", "BlogId");
            CreateIndex("dbo.IndividualRoles", "RoleId");
            AddForeignKey("dbo.States", "CountryId", "dbo.Countries", "CountryId");
            AddForeignKey("dbo.IndividualRoles", "IndividualId", "dbo.Individuals", "IndividualId");
            AddForeignKey("dbo.Sites", "IndividualRoleId", "dbo.IndividualRoles", "IndividualRoleId");
            AddForeignKey("dbo.PasswordChanges", "UserId", "dbo.Users", "UserId");
            AddForeignKey("dbo.Posts", "BlogId", "dbo.Blogs", "BlogId");
            AddForeignKey("dbo.IndividualRoles", "RoleId", "dbo.Roles", "RoleId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IndividualRoles", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Posts", "BlogId", "dbo.Blogs");
            DropForeignKey("dbo.PasswordChanges", "UserId", "dbo.Users");
            DropForeignKey("dbo.Sites", "IndividualRoleId", "dbo.IndividualRoles");
            DropForeignKey("dbo.IndividualRoles", "IndividualId", "dbo.Individuals");
            DropForeignKey("dbo.States", "CountryId", "dbo.Countries");
            DropIndex("dbo.IndividualRoles", new[] { "RoleId" });
            DropIndex("dbo.Posts", new[] { "BlogId" });
            DropIndex("dbo.PasswordChanges", new[] { "UserId" });
            DropIndex("dbo.Sites", new[] { "IndividualRoleId" });
            DropIndex("dbo.IndividualRoles", new[] { "IndividualId" });
            DropIndex("dbo.States", new[] { "CountryId" });
            AlterColumn("dbo.PasswordChanges", "UpdatedBy", c => c.String());
            AlterColumn("dbo.PasswordChanges", "CreatedBy", c => c.String());
            AlterColumn("dbo.PasswordChanges", "NewPassword", c => c.String());
            AlterColumn("dbo.Users", "UpdatedBy", c => c.String());
            AlterColumn("dbo.Users", "CreatedBy", c => c.String());
            AlterColumn("dbo.Users", "Username", c => c.String());
            AlterColumn("dbo.Roles", "UpdatedBy", c => c.String());
            AlterColumn("dbo.Roles", "CreatedBy", c => c.String());
            AlterColumn("dbo.Roles", "RoleName", c => c.String());
            AlterColumn("dbo.Roles", "RoleId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.IndividualRoles", "UpdatedBy", c => c.String());
            AlterColumn("dbo.IndividualRoles", "CreatedBy", c => c.String());
            AlterColumn("dbo.Individuals", "UpdatedBy", c => c.String());
            AlterColumn("dbo.Individuals", "CreatedBy", c => c.String());
            AlterColumn("dbo.Individuals", "EmailAddress", c => c.String());
            AlterColumn("dbo.Individuals", "LastName", c => c.String());
            AlterColumn("dbo.Individuals", "MiddleName", c => c.String());
            AlterColumn("dbo.Individuals", "FirstName", c => c.String());
            AlterColumn("dbo.States", "UpdatedBy", c => c.String());
            AlterColumn("dbo.States", "CreatedBy", c => c.String());
            AlterColumn("dbo.States", "Name", c => c.String());
            AlterColumn("dbo.Countries", "UpdatedBy", c => c.String());
            AlterColumn("dbo.Countries", "CreatedBy", c => c.String());
            AlterColumn("dbo.Countries", "ShortName", c => c.String());
            AlterColumn("dbo.Countries", "Name", c => c.String());
            AlterColumn("dbo.Addresses", "UpdatedBy", c => c.String());
            AlterColumn("dbo.Addresses", "CreatedBy", c => c.String());
            AlterColumn("dbo.Addresses", "Zip", c => c.String());
            AlterColumn("dbo.Addresses", "City", c => c.String());
            AlterColumn("dbo.Addresses", "AddressLine2", c => c.String());
            AlterColumn("dbo.Addresses", "AddressLine1", c => c.String());
            CreateIndex("dbo.IndividualRoles", "RoleId");
            CreateIndex("dbo.Posts", "BlogId");
            CreateIndex("dbo.PasswordChanges", "UserId");
            CreateIndex("dbo.Sites", "IndividualRoleId");
            CreateIndex("dbo.IndividualRoles", "IndividualId");
            CreateIndex("dbo.States", "CountryId");
            AddForeignKey("dbo.IndividualRoles", "RoleId", "dbo.Roles", "RoleId", cascadeDelete: true);
            AddForeignKey("dbo.Posts", "BlogId", "dbo.Blogs", "BlogId", cascadeDelete: true);
            AddForeignKey("dbo.PasswordChanges", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.Sites", "IndividualRoleId", "dbo.IndividualRoles", "IndividualRoleId", cascadeDelete: true);
            AddForeignKey("dbo.IndividualRoles", "IndividualId", "dbo.Individuals", "IndividualId", cascadeDelete: true);
            AddForeignKey("dbo.States", "CountryId", "dbo.Countries", "CountryId", cascadeDelete: true);
        }
    }
}
