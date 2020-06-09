namespace DropZone.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDbMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AADs",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Manufacturer = c.String(),
                        Name = c.String(),
                        Height = c.Double(nullable: false),
                        Speed = c.Double(nullable: false),
                        MaintenanceDate = c.DateTime(),
                        HashBlockId = c.Long(nullable: false),
                        ModifiedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HashBlocks", t => t.HashBlockId, cascadeDelete: false)
                .ForeignKey("dbo.ParachuteSystems", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.HashBlockId);
            
            CreateTable(
                "dbo.HashBlocks",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Value = c.String(),
                        Hash = c.String(),
                        PreviousHash = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        UserId = c.Long(nullable: false),
                        PreviousHashBlockId = c.Long(),
                        ModifiedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HashBlocks", t => t.PreviousHashBlockId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId)
                .Index(t => t.PreviousHashBlockId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Phone = c.String(),
                        Address = c.String(),
                        Birthday = c.DateTime(nullable: false),
                        RoleId = c.Long(nullable: false),
                        DropZoneId = c.Long(),
                        ModifiedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DropZones", t => t.DropZoneId)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: false)
                .Index(t => t.RoleId)
                .Index(t => t.DropZoneId);
            
            CreateTable(
                "dbo.DropZones",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(),
                        Location = c.String(),
                        Country = c.String(),
                        ModifiedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Aircrafts",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Type = c.String(),
                        Capacity = c.Int(nullable: false),
                        IsAvailable = c.Boolean(nullable: false),
                        DropZoneId = c.Long(nullable: false),
                        ModifiedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DropZones", t => t.DropZoneId, cascadeDelete: false)
                .Index(t => t.DropZoneId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Value = c.String(),
                        ModifiedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ParachuteSystems",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        MainParachuteId = c.Long(nullable: false),
                        ReserveParachuteId = c.Long(nullable: false),
                        AADId = c.Long(nullable: false),
                        SatchelId = c.Long(nullable: false),
                        UserId = c.Long(nullable: false),
                        HashBlockId = c.Long(nullable: false),
                        ModifiedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HashBlocks", t => t.HashBlockId, cascadeDelete: false)
                .ForeignKey("dbo.Parachutes", t => t.MainParachuteId, cascadeDelete: false)
                .ForeignKey("dbo.Parachutes", t => t.ReserveParachuteId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
                .Index(t => t.MainParachuteId)
                .Index(t => t.ReserveParachuteId)
                .Index(t => t.UserId)
                .Index(t => t.HashBlockId);
            
            CreateTable(
                "dbo.Parachutes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Area = c.Double(nullable: false),
                        LayingVolume = c.Double(nullable: false),
                        Weight = c.Double(nullable: false),
                        SectionCount = c.Int(nullable: false),
                        Manufacturer = c.String(),
                        IsReserve = c.Boolean(nullable: false),
                        LayingDate = c.DateTime(),
                        MaintenanceDate = c.DateTime(),
                        HashBlockId = c.Long(nullable: false),
                        ModifiedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HashBlocks", t => t.HashBlockId, cascadeDelete: false)
                .Index(t => t.HashBlockId);
            
            CreateTable(
                "dbo.Satchels",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        MainParachuteArea = c.Double(nullable: false),
                        ReserveParachuteArea = c.Double(nullable: false),
                        Manufacturer = c.String(),
                        MaintenanceDate = c.DateTime(),
                        HashBlockId = c.Long(nullable: false),
                        ModifiedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HashBlocks", t => t.HashBlockId, cascadeDelete: false)
                .ForeignKey("dbo.ParachuteSystems", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.HashBlockId);
            
            CreateTable(
                "dbo.JumpBooks",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Category = c.String(),
                        SportsmanId = c.Long(nullable: false),
                        ModifiedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.SportsmanId, cascadeDelete: false)
                .Index(t => t.SportsmanId);
            
            CreateTable(
                "dbo.Jumps",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Task = c.String(),
                        Height = c.Double(nullable: false),
                        FallTime = c.Double(nullable: false),
                        JumpBookId = c.Long(nullable: false),
                        DropZoneId = c.Long(nullable: false),
                        ParachuteSystemId = c.Long(nullable: false),
                        AircraftId = c.Long(nullable: false),
                        ModifiedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Aircrafts", t => t.AircraftId, cascadeDelete: false)
                .ForeignKey("dbo.DropZones", t => t.DropZoneId, cascadeDelete: false)
                .ForeignKey("dbo.JumpBooks", t => t.JumpBookId, cascadeDelete: false)
                .ForeignKey("dbo.ParachuteSystems", t => t.ParachuteSystemId, cascadeDelete: false)
                .Index(t => t.JumpBookId)
                .Index(t => t.DropZoneId)
                .Index(t => t.ParachuteSystemId)
                .Index(t => t.AircraftId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JumpBooks", "SportsmanId", "dbo.Users");
            DropForeignKey("dbo.Jumps", "ParachuteSystemId", "dbo.ParachuteSystems");
            DropForeignKey("dbo.Jumps", "JumpBookId", "dbo.JumpBooks");
            DropForeignKey("dbo.Jumps", "DropZoneId", "dbo.DropZones");
            DropForeignKey("dbo.Jumps", "AircraftId", "dbo.Aircrafts");
            DropForeignKey("dbo.ParachuteSystems", "UserId", "dbo.Users");
            DropForeignKey("dbo.Satchels", "Id", "dbo.ParachuteSystems");
            DropForeignKey("dbo.Satchels", "HashBlockId", "dbo.HashBlocks");
            DropForeignKey("dbo.ParachuteSystems", "ReserveParachuteId", "dbo.Parachutes");
            DropForeignKey("dbo.ParachuteSystems", "MainParachuteId", "dbo.Parachutes");
            DropForeignKey("dbo.Parachutes", "HashBlockId", "dbo.HashBlocks");
            DropForeignKey("dbo.ParachuteSystems", "HashBlockId", "dbo.HashBlocks");
            DropForeignKey("dbo.AADs", "Id", "dbo.ParachuteSystems");
            DropForeignKey("dbo.AADs", "HashBlockId", "dbo.HashBlocks");
            DropForeignKey("dbo.HashBlocks", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Users", "DropZoneId", "dbo.DropZones");
            DropForeignKey("dbo.Aircrafts", "DropZoneId", "dbo.DropZones");
            DropForeignKey("dbo.HashBlocks", "PreviousHashBlockId", "dbo.HashBlocks");
            DropIndex("dbo.Jumps", new[] { "AircraftId" });
            DropIndex("dbo.Jumps", new[] { "ParachuteSystemId" });
            DropIndex("dbo.Jumps", new[] { "DropZoneId" });
            DropIndex("dbo.Jumps", new[] { "JumpBookId" });
            DropIndex("dbo.JumpBooks", new[] { "SportsmanId" });
            DropIndex("dbo.Satchels", new[] { "HashBlockId" });
            DropIndex("dbo.Satchels", new[] { "Id" });
            DropIndex("dbo.Parachutes", new[] { "HashBlockId" });
            DropIndex("dbo.ParachuteSystems", new[] { "HashBlockId" });
            DropIndex("dbo.ParachuteSystems", new[] { "UserId" });
            DropIndex("dbo.ParachuteSystems", new[] { "ReserveParachuteId" });
            DropIndex("dbo.ParachuteSystems", new[] { "MainParachuteId" });
            DropIndex("dbo.Aircrafts", new[] { "DropZoneId" });
            DropIndex("dbo.Users", new[] { "DropZoneId" });
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropIndex("dbo.HashBlocks", new[] { "PreviousHashBlockId" });
            DropIndex("dbo.HashBlocks", new[] { "UserId" });
            DropIndex("dbo.AADs", new[] { "HashBlockId" });
            DropIndex("dbo.AADs", new[] { "Id" });
            DropTable("dbo.Jumps");
            DropTable("dbo.JumpBooks");
            DropTable("dbo.Satchels");
            DropTable("dbo.Parachutes");
            DropTable("dbo.ParachuteSystems");
            DropTable("dbo.Roles");
            DropTable("dbo.Aircrafts");
            DropTable("dbo.DropZones");
            DropTable("dbo.Users");
            DropTable("dbo.HashBlocks");
            DropTable("dbo.AADs");
        }
    }
}
