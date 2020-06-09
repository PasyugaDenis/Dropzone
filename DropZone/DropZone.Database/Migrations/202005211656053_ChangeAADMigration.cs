namespace DropZone.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeAADMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AADs", "ManufacturerId", "dbo.Manufacturers");
            DropIndex("dbo.AADs", new[] { "ManufacturerId" });
            CreateTable(
                "dbo.AADTypes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Type = c.String(),
                        Height = c.Double(nullable: false),
                        Speed = c.Double(nullable: false),
                        ManufacturerId = c.Long(nullable: false),
                        ModifiedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Manufacturers", t => t.ManufacturerId, cascadeDelete: true)
                .Index(t => t.ManufacturerId);
            
            AddColumn("dbo.AADs", "AADTypeId", c => c.Long(nullable: false));
            CreateIndex("dbo.AADs", "AADTypeId");
            AddForeignKey("dbo.AADs", "AADTypeId", "dbo.AADTypes", "Id", cascadeDelete: true);
            DropColumn("dbo.AADs", "Name");
            DropColumn("dbo.AADs", "Height");
            DropColumn("dbo.AADs", "Speed");
            DropColumn("dbo.AADs", "ManufacturerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AADs", "ManufacturerId", c => c.Long(nullable: false));
            AddColumn("dbo.AADs", "Speed", c => c.Double(nullable: false));
            AddColumn("dbo.AADs", "Height", c => c.Double(nullable: false));
            AddColumn("dbo.AADs", "Name", c => c.String());
            DropForeignKey("dbo.AADs", "AADTypeId", "dbo.AADTypes");
            DropForeignKey("dbo.AADTypes", "ManufacturerId", "dbo.Manufacturers");
            DropIndex("dbo.AADTypes", new[] { "ManufacturerId" });
            DropIndex("dbo.AADs", new[] { "AADTypeId" });
            DropColumn("dbo.AADs", "AADTypeId");
            DropTable("dbo.AADTypes");
            CreateIndex("dbo.AADs", "ManufacturerId");
            AddForeignKey("dbo.AADs", "ManufacturerId", "dbo.Manufacturers", "Id", cascadeDelete: true);
        }
    }
}
