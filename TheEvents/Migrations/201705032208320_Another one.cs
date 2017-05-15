namespace TheEvents.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Anotherone : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "StartTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "StartTime", c => c.DateTime());
        }
    }
}
