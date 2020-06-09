namespace DropZone.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeManufacturerMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Manufacturers",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(),
                        Country = c.String(),
                        ModifiedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AADs", "ManufacturerId", c => c.Long(nullable: false));
            AddColumn("dbo.DropZones", "RunwayType", c => c.String());
            AddColumn("dbo.DropZones", "RunwayLength", c => c.Double(nullable: false));
            AddColumn("dbo.DropZones", "Square", c => c.Double(nullable: false));
            AddColumn("dbo.DropZones", "Latitude", c => c.Double(nullable: false));
            AddColumn("dbo.DropZones", "Longitude", c => c.Double(nullable: false));
            AddColumn("dbo.Parachutes", "LayingCount", c => c.Int(nullable: false));
            AddColumn("dbo.Parachutes", "ManufacturerId", c => c.Long(nullable: false));
            AddColumn("dbo.Satchels", "Manufacturerid", c => c.Long(nullable: false));
            CreateIndex("dbo.AADs", "ManufacturerId");
            CreateIndex("dbo.Parachutes", "ManufacturerId");
            CreateIndex("dbo.Satchels", "Manufacturerid");
            AddForeignKey("dbo.AADs", "ManufacturerId", "dbo.Manufacturers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Parachutes", "ManufacturerId", "dbo.Manufacturers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Satchels", "Manufacturerid", "dbo.Manufacturers", "Id", cascadeDelete: true);
            DropColumn("dbo.AADs", "Manufacturer");
            DropColumn("dbo.DropZones", "Location");
            DropColumn("dbo.Parachutes", "Manufacturer");
            DropColumn("dbo.Satchels", "Manufacturer");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Satchels", "Manufacturer", c => c.String());
            AddColumn("dbo.Parachutes", "Manufacturer", c => c.String());
            AddColumn("dbo.DropZones", "Location", c => c.String());
            AddColumn("dbo.AADs", "Manufacturer", c => c.String());
            DropForeignKey("dbo.Satchels", "Manufacturerid", "dbo.Manufacturers");
            DropForeignKey("dbo.Parachutes", "ManufacturerId", "dbo.Manufacturers");
            DropForeignKey("dbo.AADs", "ManufacturerId", "dbo.Manufacturers");
            DropIndex("dbo.Satchels", new[] { "Manufacturerid" });
            DropIndex("dbo.Parachutes", new[] { "ManufacturerId" });
            DropIndex("dbo.AADs", new[] { "ManufacturerId" });
            DropColumn("dbo.Satchels", "Manufacturerid");
            DropColumn("dbo.Parachutes", "ManufacturerId");
            DropColumn("dbo.Parachutes", "LayingCount");
            DropColumn("dbo.DropZones", "Longitude");
            DropColumn("dbo.DropZones", "Latitude");
            DropColumn("dbo.DropZones", "Square");
            DropColumn("dbo.DropZones", "RunwayLength");
            DropColumn("dbo.DropZones", "RunwayType");
            DropColumn("dbo.AADs", "ManufacturerId");
            DropTable("dbo.Manufacturers");
        }
    }
}
