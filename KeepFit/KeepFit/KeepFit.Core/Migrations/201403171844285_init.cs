namespace KeepFit.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        AddressLine1 = c.String(),
                        AddressLine2 = c.String(),
                        CountryId = c.Int(),
                        City = c.String(),
                        StateId = c.Int(),
                        Zip = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                    })
                .PrimaryKey(t => t.AddressId)
                .ForeignKey("dbo.Countries", t => t.CountryId)
                .ForeignKey("dbo.States", t => t.StateId)
                .Index(t => t.CountryId)
                .Index(t => t.StateId);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        CountryId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ShortName = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                    })
                .PrimaryKey(t => t.CountryId);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        StateId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ShortName = c.String(),
                        CountryId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                    })
                .PrimaryKey(t => t.StateId)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Individuals",
                c => new
                    {
                        IndividualId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        CellPhoneNumber = c.String(),
                        WorkPhoneNumber = c.String(),
                        AddressId = c.Int(),
                        OrganizationId = c.Int(),
                        EmailAddress = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                    })
                .PrimaryKey(t => t.IndividualId)
                .ForeignKey("dbo.Addresses", t => t.AddressId)
                .Index(t => t.AddressId);
            
            CreateTable(
                "dbo.IndividualRoles",
                c => new
                    {
                        IndividualRoleId = c.Int(nullable: false, identity: true),
                        RoleId = c.Int(nullable: false),
                        IndividualId = c.Int(nullable: false),
                        IsCurrentSelected = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                    })
                .PrimaryKey(t => t.IndividualRoleId)
                .ForeignKey("dbo.Individuals", t => t.IndividualId, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.IndividualId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.Sites",
                c => new
                    {
                        SiteId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IndividualRoleId = c.Int(nullable: false),
                        ParentSiteId = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        ParentSite_SiteId = c.Int(),
                        Individual_IndividualId = c.Int(),
                    })
                .PrimaryKey(t => t.SiteId)
                .ForeignKey("dbo.IndividualRoles", t => t.IndividualRoleId, cascadeDelete: true)
                .ForeignKey("dbo.Sites", t => t.ParentSite_SiteId)
                .ForeignKey("dbo.Individuals", t => t.Individual_IndividualId)
                .Index(t => t.IndividualRoleId)
                .Index(t => t.ParentSite_SiteId)
                .Index(t => t.Individual_IndividualId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        Username = c.String(),
                        IndividualId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Individuals", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.PasswordChanges",
                c => new
                    {
                        PasswordChangeId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        NewPassword = c.String(),
                        PasswordSalt = c.String(),
                        ChangeDateTime = c.DateTime(nullable: false),
                        ForseReseted = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                    })
                .PrimaryKey(t => t.PasswordChangeId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        BlogId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.BlogId);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        BlogId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PostId)
                .ForeignKey("dbo.Blogs", t => t.BlogId, cascadeDelete: true)
                .Index(t => t.BlogId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "BlogId", "dbo.Blogs");
            DropForeignKey("dbo.PasswordChanges", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "UserId", "dbo.Individuals");
            DropForeignKey("dbo.Sites", "Individual_IndividualId", "dbo.Individuals");
            DropForeignKey("dbo.Sites", "ParentSite_SiteId", "dbo.Sites");
            DropForeignKey("dbo.Sites", "IndividualRoleId", "dbo.IndividualRoles");
            DropForeignKey("dbo.IndividualRoles", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.IndividualRoles", "IndividualId", "dbo.Individuals");
            DropForeignKey("dbo.Individuals", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.States", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Addresses", "StateId", "dbo.States");
            DropForeignKey("dbo.Addresses", "CountryId", "dbo.Countries");
            DropIndex("dbo.Posts", new[] { "BlogId" });
            DropIndex("dbo.PasswordChanges", new[] { "UserId" });
            DropIndex("dbo.Users", new[] { "UserId" });
            DropIndex("dbo.Sites", new[] { "Individual_IndividualId" });
            DropIndex("dbo.Sites", new[] { "ParentSite_SiteId" });
            DropIndex("dbo.Sites", new[] { "IndividualRoleId" });
            DropIndex("dbo.IndividualRoles", new[] { "RoleId" });
            DropIndex("dbo.IndividualRoles", new[] { "IndividualId" });
            DropIndex("dbo.Individuals", new[] { "AddressId" });
            DropIndex("dbo.States", new[] { "CountryId" });
            DropIndex("dbo.Addresses", new[] { "StateId" });
            DropIndex("dbo.Addresses", new[] { "CountryId" });
            DropTable("dbo.Posts");
            DropTable("dbo.Blogs");
            DropTable("dbo.PasswordChanges");
            DropTable("dbo.Users");
            DropTable("dbo.Sites");
            DropTable("dbo.Roles");
            DropTable("dbo.IndividualRoles");
            DropTable("dbo.Individuals");
            DropTable("dbo.States");
            DropTable("dbo.Countries");
            DropTable("dbo.Addresses");
        }
    }
}
