namespace RentABike.DataProvider.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDescriptionColumnIntoStatusTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Status", "Description", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Status", "Description");
        }
    }
}
