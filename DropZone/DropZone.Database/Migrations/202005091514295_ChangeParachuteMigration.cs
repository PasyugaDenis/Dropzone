namespace DropZone.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeParachuteMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Parachutes", "Shape", c => c.String());
            AddColumn("dbo.Parachutes", "Material", c => c.String());
            AddColumn("dbo.Parachutes", "SliderType", c => c.String());
            AddColumn("dbo.Parachutes", "Height", c => c.Double(nullable: false));
            AddColumn("dbo.Parachutes", "Scope", c => c.Double(nullable: false));
            AddColumn("dbo.Parachutes", "Chord", c => c.Double(nullable: false));
            AddColumn("dbo.Parachutes", "Incline", c => c.Double(nullable: false));
            AddColumn("dbo.Parachutes", "ControlLineLength", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Parachutes", "ControlLineLength");
            DropColumn("dbo.Parachutes", "Incline");
            DropColumn("dbo.Parachutes", "Chord");
            DropColumn("dbo.Parachutes", "Scope");
            DropColumn("dbo.Parachutes", "Height");
            DropColumn("dbo.Parachutes", "SliderType");
            DropColumn("dbo.Parachutes", "Material");
            DropColumn("dbo.Parachutes", "Shape");
        }
    }
}
