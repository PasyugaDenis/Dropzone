namespace DropZone.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDropZonRegistrationDateMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DropZones", "RegistrationDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DropZones", "RegistrationDate");
        }
    }
}
