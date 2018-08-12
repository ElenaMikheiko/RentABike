namespace RentABike.DataProvider.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeMaxLengthForPhone : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BikeTypes", "Type", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.RentPoints", "Phone", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RentPoints", "Phone", c => c.String(maxLength: 13));
            AlterColumn("dbo.BikeTypes", "Type", c => c.String(maxLength: 30));
        }
    }
}
