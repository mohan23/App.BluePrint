namespace App.BluePrint.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class InitialSetup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Administration.MenuConfiguration",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MenuName = c.String(),
                        DisplayName = c.String(),
                        Description = c.String(),
                        LinkUrl = c.String(),
                        SortOrder = c.Int(nullable: false),
                        ImageIconUrl = c.String(),
                        ImageIconClass = c.String(),
                        IsAction = c.Boolean(nullable: false),
                        LookupId = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "Abp_SoftDelete", "True" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Administration.Lookup", t => t.LookupId)
                .ForeignKey("Authentication.Users", t => t.CreatorUserId)
                .ForeignKey("Authentication.Users", t => t.DeleterUserId)
                .ForeignKey("Authentication.Users", t => t.LastModifierUserId)
                .Index(t => t.LookupId)
                .Index(t => t.DeleterUserId)
                .Index(t => t.LastModifierUserId)
                .Index(t => t.CreatorUserId);
            
            CreateTable(
                "Administration.Lookup",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                        Value = c.String(),
                        Description = c.String(),
                        IconCss = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "Abp_SoftDelete", "True" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Authentication.Users", t => t.CreatorUserId)
                .ForeignKey("Authentication.Users", t => t.DeleterUserId)
                .ForeignKey("Authentication.Users", t => t.LastModifierUserId)
                .Index(t => t.DeleterUserId)
                .Index(t => t.LastModifierUserId)
                .Index(t => t.CreatorUserId);
            
            CreateTable(
                "Authentication.Users",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TenantId = c.Int(),
                        Name = c.String(nullable: false, maxLength: 32),
                        Surname = c.String(nullable: false, maxLength: 32),
                        UserName = c.String(nullable: false, maxLength: 32),
                        Password = c.String(nullable: false, maxLength: 128),
                        EmailAddress = c.String(nullable: false, maxLength: 256),
                        IsEmailConfirmed = c.Boolean(nullable: false),
                        EmailConfirmationCode = c.String(maxLength: 16),
                        PasswordResetCode = c.String(maxLength: 32),
                        LastLoginTime = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "Abp_SoftDelete", "True" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Authentication.Users", t => t.CreatorUserId)
                .ForeignKey("Authentication.Users", t => t.DeleterUserId)
                .ForeignKey("Authentication.Users", t => t.LastModifierUserId)
                .ForeignKey("Tenant.TenantDefinition", t => t.TenantId)
                .Index(t => t.TenantId)
                .Index(t => t.DeleterUserId)
                .Index(t => t.LastModifierUserId)
                .Index(t => t.CreatorUserId);
            
            CreateTable(
                "Authentication.UserLogins",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        UserId = c.Long(nullable: false),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Authentication.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "Authentication.UserManager",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        UserId = c.Long(),
                        ManagerId = c.Long(nullable: false),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Authentication.Users", t => t.CreatorUserId)
                .ForeignKey("Authentication.Users", t => t.LastModifierUserId)
                .ForeignKey("Authentication.Users", t => t.ManagerId)
                .ForeignKey("Authentication.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ManagerId)
                .Index(t => t.LastModifierUserId)
                .Index(t => t.CreatorUserId);
            
            CreateTable(
                "Authentication.Permissions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 128),
                        IsGranted = c.Boolean(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        UserId = c.Long(),
                        RoleId = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Authentication.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("Authentication.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "Authentication.UserRoles",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        UserId = c.Long(nullable: false),
                        RoleId = c.Int(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Authentication.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "Application.Settings",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TenantId = c.Int(),
                        UserId = c.Long(),
                        Name = c.String(),
                        Value = c.String(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Authentication.Users", t => t.UserId)
                .ForeignKey("Tenant.TenantDefinition", t => t.TenantId)
                .Index(t => t.TenantId)
                .Index(t => t.UserId);
            
            CreateTable(
                "Tenant.TenantDefinition",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TenancyName = c.String(),
                        Name = c.String(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Authentication.Users", t => t.CreatorUserId)
                .ForeignKey("Authentication.Users", t => t.LastModifierUserId)
                .Index(t => t.LastModifierUserId)
                .Index(t => t.CreatorUserId);
            
            CreateTable(
                "Administration.MenuRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MenuId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Administration.MenuConfiguration", t => t.MenuId, cascadeDelete: true)
                .Index(t => t.MenuId);
            
            CreateTable(
                "Authentication.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TenantId = c.Int(),
                        Name = c.String(nullable: false, maxLength: 32),
                        DisplayName = c.String(nullable: false, maxLength: 64),
                        IsStatic = c.Boolean(nullable: false),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Authentication.Users", t => t.CreatorUserId)
                .ForeignKey("Authentication.Users", t => t.LastModifierUserId)
                .ForeignKey("Tenant.TenantDefinition", t => t.TenantId)
                .Index(t => t.TenantId)
                .Index(t => t.LastModifierUserId)
                .Index(t => t.CreatorUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Authentication.Roles", "TenantId", "Tenant.TenantDefinition");
            DropForeignKey("Authentication.Permissions", "RoleId", "Authentication.Roles");
            DropForeignKey("Authentication.Roles", "LastModifierUserId", "Authentication.Users");
            DropForeignKey("Authentication.Roles", "CreatorUserId", "Authentication.Users");
            DropForeignKey("Administration.MenuRoles", "MenuId", "Administration.MenuConfiguration");
            DropForeignKey("Administration.MenuConfiguration", "LastModifierUserId", "Authentication.Users");
            DropForeignKey("Administration.MenuConfiguration", "DeleterUserId", "Authentication.Users");
            DropForeignKey("Administration.MenuConfiguration", "CreatorUserId", "Authentication.Users");
            DropForeignKey("Administration.MenuConfiguration", "LookupId", "Administration.Lookup");
            DropForeignKey("Administration.Lookup", "LastModifierUserId", "Authentication.Users");
            DropForeignKey("Administration.Lookup", "DeleterUserId", "Authentication.Users");
            DropForeignKey("Administration.Lookup", "CreatorUserId", "Authentication.Users");
            DropForeignKey("Authentication.Users", "TenantId", "Tenant.TenantDefinition");
            DropForeignKey("Application.Settings", "TenantId", "Tenant.TenantDefinition");
            DropForeignKey("Tenant.TenantDefinition", "LastModifierUserId", "Authentication.Users");
            DropForeignKey("Tenant.TenantDefinition", "CreatorUserId", "Authentication.Users");
            DropForeignKey("Application.Settings", "UserId", "Authentication.Users");
            DropForeignKey("Authentication.UserRoles", "UserId", "Authentication.Users");
            DropForeignKey("Authentication.Permissions", "UserId", "Authentication.Users");
            DropForeignKey("Authentication.UserManager", "UserId", "Authentication.Users");
            DropForeignKey("Authentication.UserManager", "ManagerId", "Authentication.Users");
            DropForeignKey("Authentication.UserManager", "LastModifierUserId", "Authentication.Users");
            DropForeignKey("Authentication.UserManager", "CreatorUserId", "Authentication.Users");
            DropForeignKey("Authentication.UserLogins", "UserId", "Authentication.Users");
            DropForeignKey("Authentication.Users", "LastModifierUserId", "Authentication.Users");
            DropForeignKey("Authentication.Users", "DeleterUserId", "Authentication.Users");
            DropForeignKey("Authentication.Users", "CreatorUserId", "Authentication.Users");
            DropIndex("Authentication.Roles", new[] { "CreatorUserId" });
            DropIndex("Authentication.Roles", new[] { "LastModifierUserId" });
            DropIndex("Authentication.Roles", new[] { "TenantId" });
            DropIndex("Administration.MenuRoles", new[] { "MenuId" });
            DropIndex("Tenant.TenantDefinition", new[] { "CreatorUserId" });
            DropIndex("Tenant.TenantDefinition", new[] { "LastModifierUserId" });
            DropIndex("Application.Settings", new[] { "UserId" });
            DropIndex("Application.Settings", new[] { "TenantId" });
            DropIndex("Authentication.UserRoles", new[] { "UserId" });
            DropIndex("Authentication.Permissions", new[] { "RoleId" });
            DropIndex("Authentication.Permissions", new[] { "UserId" });
            DropIndex("Authentication.UserManager", new[] { "CreatorUserId" });
            DropIndex("Authentication.UserManager", new[] { "LastModifierUserId" });
            DropIndex("Authentication.UserManager", new[] { "ManagerId" });
            DropIndex("Authentication.UserManager", new[] { "UserId" });
            DropIndex("Authentication.UserLogins", new[] { "UserId" });
            DropIndex("Authentication.Users", new[] { "CreatorUserId" });
            DropIndex("Authentication.Users", new[] { "LastModifierUserId" });
            DropIndex("Authentication.Users", new[] { "DeleterUserId" });
            DropIndex("Authentication.Users", new[] { "TenantId" });
            DropIndex("Administration.Lookup", new[] { "CreatorUserId" });
            DropIndex("Administration.Lookup", new[] { "LastModifierUserId" });
            DropIndex("Administration.Lookup", new[] { "DeleterUserId" });
            DropIndex("Administration.MenuConfiguration", new[] { "CreatorUserId" });
            DropIndex("Administration.MenuConfiguration", new[] { "LastModifierUserId" });
            DropIndex("Administration.MenuConfiguration", new[] { "DeleterUserId" });
            DropIndex("Administration.MenuConfiguration", new[] { "LookupId" });
            DropTable("Authentication.Roles");
            DropTable("Administration.MenuRoles");
            DropTable("Tenant.TenantDefinition");
            DropTable("Application.Settings");
            DropTable("Authentication.UserRoles");
            DropTable("Authentication.Permissions");
            DropTable("Authentication.UserManager");
            DropTable("Authentication.UserLogins");
            DropTable("Authentication.Users",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "Abp_SoftDelete", "True" },
                });
            DropTable("Administration.Lookup",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "Abp_SoftDelete", "True" },
                });
            DropTable("Administration.MenuConfiguration",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "Abp_SoftDelete", "True" },
                });
        }
    }
}
