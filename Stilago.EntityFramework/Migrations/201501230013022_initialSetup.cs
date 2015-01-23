namespace Stilago.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class initialSetup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brand",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        CountryId = c.Guid(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreationTime = c.DateTimeOffset(nullable: false, precision: 7),
                        LastModificationTime = c.DateTimeOffset(nullable: false, precision: 7),
                        CreatedById = c.Guid(nullable: false),
                        ModifiedById = c.Guid(nullable: false),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "Abp_SoftDelete", "True" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Country", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.BrandComputerRelationships",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ComputerId = c.Guid(nullable: false),
                        BrandId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Brand", t => t.BrandId, cascadeDelete: true)
                .ForeignKey("dbo.Computer", t => t.ComputerId, cascadeDelete: true)
                .Index(t => t.ComputerId)
                .Index(t => t.BrandId);
            
            CreateTable(
                "dbo.Computer",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Model = c.String(nullable: false, maxLength: 15),
                        DiskCapacity = c.Long(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreationTime = c.DateTimeOffset(nullable: false, precision: 7),
                        LastModificationTime = c.DateTimeOffset(nullable: false, precision: 7),
                        CreatedById = c.Guid(nullable: false),
                        ModifiedById = c.Guid(nullable: false),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "Abp_SoftDelete", "True" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ComputerInfo",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Price = c.Long(nullable: false),
                        Description = c.String(),
                        CountryId = c.Guid(nullable: false),
                        ComputerId = c.Guid(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreationTime = c.DateTimeOffset(nullable: false, precision: 7),
                        LastModificationTime = c.DateTimeOffset(nullable: false, precision: 7),
                        CreatedById = c.Guid(nullable: false),
                        ModifiedById = c.Guid(nullable: false),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "Abp_SoftDelete", "True" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Computer", t => t.ComputerId, cascadeDelete: true)
                .ForeignKey("dbo.Country", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.CountryId)
                .Index(t => t.ComputerId);
            
            CreateTable(
                "dbo.Country",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        Culture = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        CountryId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Country", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.CountryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User", "CountryId", "dbo.Country");
            DropForeignKey("dbo.Brand", "CountryId", "dbo.Country");
            DropForeignKey("dbo.BrandComputerRelationships", "ComputerId", "dbo.Computer");
            DropForeignKey("dbo.ComputerInfo", "CountryId", "dbo.Country");
            DropForeignKey("dbo.ComputerInfo", "ComputerId", "dbo.Computer");
            DropForeignKey("dbo.BrandComputerRelationships", "BrandId", "dbo.Brand");
            DropIndex("dbo.User", new[] { "CountryId" });
            DropIndex("dbo.ComputerInfo", new[] { "ComputerId" });
            DropIndex("dbo.ComputerInfo", new[] { "CountryId" });
            DropIndex("dbo.BrandComputerRelationships", new[] { "BrandId" });
            DropIndex("dbo.BrandComputerRelationships", new[] { "ComputerId" });
            DropIndex("dbo.Brand", new[] { "CountryId" });
            DropTable("dbo.User");
            DropTable("dbo.Country");
            DropTable("dbo.ComputerInfo",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "Abp_SoftDelete", "True" },
                });
            DropTable("dbo.Computer",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "Abp_SoftDelete", "True" },
                });
            DropTable("dbo.BrandComputerRelationships");
            DropTable("dbo.Brand",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "Abp_SoftDelete", "True" },
                });
        }
    }
}
