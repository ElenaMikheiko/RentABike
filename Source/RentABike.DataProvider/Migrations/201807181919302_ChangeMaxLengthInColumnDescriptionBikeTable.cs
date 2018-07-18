namespace RentABike.DataProvider.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeMaxLengthInColumnDescriptionBikeTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Bikes", "Description", c => c.String(maxLength: 1000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Bikes", "Description", c => c.String(maxLength: 250));
        }
    }
}
