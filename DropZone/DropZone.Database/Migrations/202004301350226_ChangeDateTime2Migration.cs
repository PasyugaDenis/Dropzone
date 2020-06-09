namespace DropZone.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDateTime2Migration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AADs", "MaintenanceDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.AADs", "ModifiedAt", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.HashBlocks", "CreatedOn", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.HashBlocks", "ModifiedAt", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Users", "Birthday", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Users", "ModifiedAt", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.DropZones", "ModifiedAt", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Aircrafts", "ModifiedAt", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Roles", "ModifiedAt", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Manufacturers", "ModifiedAt", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.ParachuteSystems", "ModifiedAt", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Parachutes", "LayingDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Parachutes", "MaintenanceDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Parachutes", "ModifiedAt", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Satchels", "MaintenanceDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Satchels", "ModifiedAt", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.JumpBooks", "ModifiedAt", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Jumps", "Date", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Jumps", "ModifiedAt", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Jumps", "ModifiedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Jumps", "Date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.JumpBooks", "ModifiedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Satchels", "ModifiedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Satchels", "MaintenanceDate", c => c.DateTime());
            AlterColumn("dbo.Parachutes", "ModifiedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Parachutes", "MaintenanceDate", c => c.DateTime());
            AlterColumn("dbo.Parachutes", "LayingDate", c => c.DateTime());
            AlterColumn("dbo.ParachuteSystems", "ModifiedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Manufacturers", "ModifiedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Roles", "ModifiedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Aircrafts", "ModifiedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.DropZones", "ModifiedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Users", "ModifiedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Users", "Birthday", c => c.DateTime(nullable: false));
            AlterColumn("dbo.HashBlocks", "ModifiedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.HashBlocks", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.AADs", "ModifiedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.AADs", "MaintenanceDate", c => c.DateTime());
        }
    }
}
