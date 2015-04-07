namespace App.BluePrint.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class Metadata_Definition : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Config.ExProperties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DataType = c.String(),
                        PropertyType = c.Int(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Authentication.Users", t => t.CreatorUserId)
                .Index(t => t.CreatorUserId);
            
            CreateTable(
                "Metadata.MetadataExProperties",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        MetadataVersionId = c.Long(),
                        PropertyValue = c.String(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        Properties_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Metadata.MetadataVersion", t => t.MetadataVersionId)
                .ForeignKey("Config.ExProperties", t => t.Properties_Id)
                .Index(t => t.MetadataVersionId)
                .Index(t => t.Properties_Id);
            
            CreateTable(
                "Metadata.MetadataVersion",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        MetadataId = c.Int(nullable: false),
                        VersionDescription = c.String(),
                        BehaviourAssembly = c.String(),
                        BehaviourClass = c.String(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Authentication.Users", t => t.CreatorUserId)
                .ForeignKey("Metadata.MetadataDefinition", t => t.MetadataId, cascadeDelete: true)
                .ForeignKey("Config.VersionGenerator", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.MetadataId)
                .Index(t => t.CreatorUserId);
            
            CreateTable(
                "Metadata.MetadataDefinition",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InternalName = c.String(maxLength: 20),
                        Name = c.String(),
                        Description = c.String(),
                        EffectiveDate = c.DateTime(nullable: false),
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
                .Index(t => t.InternalName)
                .Index(t => t.DeleterUserId)
                .Index(t => t.LastModifierUserId)
                .Index(t => t.CreatorUserId);
            
            CreateTable(
                "Config.VersionGenerator",
                c => new
                    {
                        Major = c.Int(nullable: false),
                        Minor = c.Int(nullable: false),
                        Revision = c.Int(nullable: false),
                        Build = c.Int(nullable: false),
                        Id = c.Long(nullable: false, identity: true),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Authentication.Users", t => t.CreatorUserId)
                .Index(t => t.CreatorUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Metadata.MetadataExProperties", "Properties_Id", "Config.ExProperties");
            DropForeignKey("Metadata.MetadataVersion", "Id", "Config.VersionGenerator");
            DropForeignKey("Config.VersionGenerator", "CreatorUserId", "Authentication.Users");
            DropForeignKey("Metadata.MetadataExProperties", "MetadataVersionId", "Metadata.MetadataVersion");
            DropForeignKey("Metadata.MetadataVersion", "MetadataId", "Metadata.MetadataDefinition");
            DropForeignKey("Metadata.MetadataDefinition", "LastModifierUserId", "Authentication.Users");
            DropForeignKey("Metadata.MetadataDefinition", "DeleterUserId", "Authentication.Users");
            DropForeignKey("Metadata.MetadataDefinition", "CreatorUserId", "Authentication.Users");
            DropForeignKey("Metadata.MetadataVersion", "CreatorUserId", "Authentication.Users");
            DropForeignKey("Config.ExProperties", "CreatorUserId", "Authentication.Users");
            DropIndex("Config.VersionGenerator", new[] { "CreatorUserId" });
            DropIndex("Metadata.MetadataDefinition", new[] { "CreatorUserId" });
            DropIndex("Metadata.MetadataDefinition", new[] { "LastModifierUserId" });
            DropIndex("Metadata.MetadataDefinition", new[] { "DeleterUserId" });
            DropIndex("Metadata.MetadataDefinition", new[] { "InternalName" });
            DropIndex("Metadata.MetadataVersion", new[] { "CreatorUserId" });
            DropIndex("Metadata.MetadataVersion", new[] { "MetadataId" });
            DropIndex("Metadata.MetadataVersion", new[] { "Id" });
            DropIndex("Metadata.MetadataExProperties", new[] { "Properties_Id" });
            DropIndex("Metadata.MetadataExProperties", new[] { "MetadataVersionId" });
            DropIndex("Config.ExProperties", new[] { "CreatorUserId" });
            DropTable("Config.VersionGenerator");
            DropTable("Metadata.MetadataDefinition",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "Abp_SoftDelete", "True" },
                });
            DropTable("Metadata.MetadataVersion");
            DropTable("Metadata.MetadataExProperties");
            DropTable("Config.ExProperties");
        }
    }
}
