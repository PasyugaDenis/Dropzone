namespace DropZone.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeParachuteMigration2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AADs", "Id", "dbo.ParachuteSystems");
            DropForeignKey("dbo.ParachuteSystems", "MainParachuteId", "dbo.Parachutes");
            DropForeignKey("dbo.ParachuteSystems", "ReserveParachuteId", "dbo.Parachutes");
            DropForeignKey("dbo.Satchels", "Id", "dbo.ParachuteSystems");
            DropIndex("dbo.AADs", new[] { "Id" });
            DropIndex("dbo.ParachuteSystems", new[] { "MainParachuteId" });
            DropIndex("dbo.ParachuteSystems", new[] { "ReserveParachuteId" });
            DropIndex("dbo.Satchels", new[] { "Id" });
            DropPrimaryKey("dbo.AADs");
            DropPrimaryKey("dbo.Satchels");
            AlterColumn("dbo.AADs", "Id", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.ParachuteSystems", "MainParachuteId", c => c.Long());
            AlterColumn("dbo.ParachuteSystems", "ReserveParachuteId", c => c.Long());
            AlterColumn("dbo.Satchels", "Id", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.AADs", "Id");
            AddPrimaryKey("dbo.Satchels", "Id");
            CreateIndex("dbo.ParachuteSystems", "MainParachuteId");
            CreateIndex("dbo.ParachuteSystems", "ReserveParachuteId");
            CreateIndex("dbo.ParachuteSystems", "AADId");
            CreateIndex("dbo.ParachuteSystems", "SatchelId");
            AddForeignKey("dbo.ParachuteSystems", "AADId", "dbo.AADs", "Id");
            AddForeignKey("dbo.ParachuteSystems", "MainParachuteId", "dbo.Parachutes", "Id");
            AddForeignKey("dbo.ParachuteSystems", "ReserveParachuteId", "dbo.Parachutes", "Id");
            AddForeignKey("dbo.ParachuteSystems", "SatchelId", "dbo.Satchels", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ParachuteSystems", "SatchelId", "dbo.Satchels");
            DropForeignKey("dbo.ParachuteSystems", "ReserveParachuteId", "dbo.Parachutes");
            DropForeignKey("dbo.ParachuteSystems", "MainParachuteId", "dbo.Parachutes");
            DropForeignKey("dbo.ParachuteSystems", "AADId", "dbo.AADs");
            DropIndex("dbo.ParachuteSystems", new[] { "SatchelId" });
            DropIndex("dbo.ParachuteSystems", new[] { "AADId" });
            DropIndex("dbo.ParachuteSystems", new[] { "ReserveParachuteId" });
            DropIndex("dbo.ParachuteSystems", new[] { "MainParachuteId" });
            DropPrimaryKey("dbo.Satchels");
            DropPrimaryKey("dbo.AADs");
            AlterColumn("dbo.Satchels", "Id", c => c.Long(nullable: false));
            AlterColumn("dbo.ParachuteSystems", "ReserveParachuteId", c => c.Long(nullable: false));
            AlterColumn("dbo.ParachuteSystems", "MainParachuteId", c => c.Long(nullable: false));
            AlterColumn("dbo.AADs", "Id", c => c.Long(nullable: false));
            AddPrimaryKey("dbo.Satchels", "Id");
            AddPrimaryKey("dbo.AADs", "Id");
            CreateIndex("dbo.Satchels", "Id");
            CreateIndex("dbo.ParachuteSystems", "ReserveParachuteId");
            CreateIndex("dbo.ParachuteSystems", "MainParachuteId");
            CreateIndex("dbo.AADs", "Id");
            AddForeignKey("dbo.Satchels", "Id", "dbo.ParachuteSystems", "Id");
            AddForeignKey("dbo.ParachuteSystems", "ReserveParachuteId", "dbo.Parachutes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ParachuteSystems", "MainParachuteId", "dbo.Parachutes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AADs", "Id", "dbo.ParachuteSystems", "Id");
        }
    }
}
