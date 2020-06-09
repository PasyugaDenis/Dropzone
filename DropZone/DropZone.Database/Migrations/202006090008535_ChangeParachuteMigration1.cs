namespace DropZone.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeParachuteMigration1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ParachuteSystems", "HashBlockId", "dbo.HashBlocks");
            DropForeignKey("dbo.ParachuteSystems", "UserId", "dbo.Users");
            DropIndex("dbo.ParachuteSystems", new[] { "UserId" });
            DropIndex("dbo.ParachuteSystems", new[] { "HashBlockId" });
            AlterColumn("dbo.ParachuteSystems", "AADId", c => c.Long());
            AlterColumn("dbo.ParachuteSystems", "SatchelId", c => c.Long());
            AlterColumn("dbo.ParachuteSystems", "UserId", c => c.Long());
            AlterColumn("dbo.ParachuteSystems", "HashBlockId", c => c.Long());
            CreateIndex("dbo.ParachuteSystems", "UserId");
            CreateIndex("dbo.ParachuteSystems", "HashBlockId");
            AddForeignKey("dbo.ParachuteSystems", "HashBlockId", "dbo.HashBlocks", "Id");
            AddForeignKey("dbo.ParachuteSystems", "UserId", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ParachuteSystems", "UserId", "dbo.Users");
            DropForeignKey("dbo.ParachuteSystems", "HashBlockId", "dbo.HashBlocks");
            DropIndex("dbo.ParachuteSystems", new[] { "HashBlockId" });
            DropIndex("dbo.ParachuteSystems", new[] { "UserId" });
            AlterColumn("dbo.ParachuteSystems", "HashBlockId", c => c.Long(nullable: false));
            AlterColumn("dbo.ParachuteSystems", "UserId", c => c.Long(nullable: false));
            AlterColumn("dbo.ParachuteSystems", "SatchelId", c => c.Long(nullable: false));
            AlterColumn("dbo.ParachuteSystems", "AADId", c => c.Long(nullable: false));
            CreateIndex("dbo.ParachuteSystems", "HashBlockId");
            CreateIndex("dbo.ParachuteSystems", "UserId");
            AddForeignKey("dbo.ParachuteSystems", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ParachuteSystems", "HashBlockId", "dbo.HashBlocks", "Id", cascadeDelete: true);
        }
    }
}
