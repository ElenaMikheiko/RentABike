namespace RentABike.DataProvider.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCreationDateTimeIntoOrderTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "DateTimeCreationOrder", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "DateTimeCreationOrder");
        }
    }
}
