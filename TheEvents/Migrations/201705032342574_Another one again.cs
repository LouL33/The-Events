namespace TheEvents.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Anotheroneagain : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Events", name: "VenueId", newName: "VenuesId");
            RenameIndex(table: "dbo.Events", name: "IX_VenueId", newName: "IX_VenuesId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Events", name: "IX_VenuesId", newName: "IX_VenueId");
            RenameColumn(table: "dbo.Events", name: "VenuesId", newName: "VenueId");
        }
    }
}
