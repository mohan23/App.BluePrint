namespace App.BluePrint.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class Metadata_GroupSection : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Metadata.MetadataGroup",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        InternalName = c.String(maxLength: 20),
                        Name = c.String(),
                        Description = c.String(),
                        Sequence = c.Int(nullable: false),
                        MetadataVersionId = c.Long(nullable: false),
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
                .ForeignKey("Metadata.MetadataVersion", t => t.MetadataVersionId, cascadeDelete: true)
                .Index(t => t.InternalName)
                .Index(t => t.MetadataVersionId)
                .Index(t => t.DeleterUserId)
                .Index(t => t.LastModifierUserId)
                .Index(t => t.CreatorUserId);
            
            CreateTable(
                "Metadata.MetadataSection",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        InternalName = c.String(maxLength: 20),
                        Name = c.String(),
                        Description = c.String(),
                        Sequence = c.Int(nullable: false),
                        MetadataGroupId = c.Long(nullable: false),
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
                .ForeignKey("Metadata.MetadataGroup", t => t.MetadataGroupId, cascadeDelete: true)
                .Index(t => t.InternalName)
                .Index(t => t.MetadataGroupId)
                .Index(t => t.DeleterUserId)
                .Index(t => t.LastModifierUserId)
                .Index(t => t.CreatorUserId);
            
            AddColumn("Metadata.MetadataExProperties", "MetadataGroupId", c => c.Long());
            AddColumn("Metadata.MetadataExProperties", "MetadataSectionId", c => c.Long());
            CreateIndex("Metadata.MetadataExProperties", "MetadataGroupId");
            CreateIndex("Metadata.MetadataExProperties", "MetadataSectionId");
            AddForeignKey("Metadata.MetadataExProperties", "MetadataGroupId", "Metadata.MetadataGroup", "Id");
            AddForeignKey("Metadata.MetadataExProperties", "MetadataSectionId", "Metadata.MetadataSection", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("Metadata.MetadataSection", "MetadataGroupId", "Metadata.MetadataGroup");
            DropForeignKey("Metadata.MetadataSection", "LastModifierUserId", "Authentication.Users");
            DropForeignKey("Metadata.MetadataExProperties", "MetadataSectionId", "Metadata.MetadataSection");
            DropForeignKey("Metadata.MetadataSection", "DeleterUserId", "Authentication.Users");
            DropForeignKey("Metadata.MetadataSection", "CreatorUserId", "Authentication.Users");
            DropForeignKey("Metadata.MetadataGroup", "MetadataVersionId", "Metadata.MetadataVersion");
            DropForeignKey("Metadata.MetadataGroup", "LastModifierUserId", "Authentication.Users");
            DropForeignKey("Metadata.MetadataExProperties", "MetadataGroupId", "Metadata.MetadataGroup");
            DropForeignKey("Metadata.MetadataGroup", "DeleterUserId", "Authentication.Users");
            DropForeignKey("Metadata.MetadataGroup", "CreatorUserId", "Authentication.Users");
            DropIndex("Metadata.MetadataSection", new[] { "CreatorUserId" });
            DropIndex("Metadata.MetadataSection", new[] { "LastModifierUserId" });
            DropIndex("Metadata.MetadataSection", new[] { "DeleterUserId" });
            DropIndex("Metadata.MetadataSection", new[] { "MetadataGroupId" });
            DropIndex("Metadata.MetadataSection", new[] { "InternalName" });
            DropIndex("Metadata.MetadataGroup", new[] { "CreatorUserId" });
            DropIndex("Metadata.MetadataGroup", new[] { "LastModifierUserId" });
            DropIndex("Metadata.MetadataGroup", new[] { "DeleterUserId" });
            DropIndex("Metadata.MetadataGroup", new[] { "MetadataVersionId" });
            DropIndex("Metadata.MetadataGroup", new[] { "InternalName" });
            DropIndex("Metadata.MetadataExProperties", new[] { "MetadataSectionId" });
            DropIndex("Metadata.MetadataExProperties", new[] { "MetadataGroupId" });
            DropColumn("Metadata.MetadataExProperties", "MetadataSectionId");
            DropColumn("Metadata.MetadataExProperties", "MetadataGroupId");
            DropTable("Metadata.MetadataSection",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "Abp_SoftDelete", "True" },
                });
            DropTable("Metadata.MetadataGroup",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "Abp_SoftDelete", "True" },
                });
        }
    }
}
