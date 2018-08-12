namespace RentABike.DataProvider.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAmountAndQuantityColumnIntoTarriffsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tarriffs", "Amount", c => c.Double(nullable: false));
            AddColumn("dbo.Tarriffs", "Quantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tarriffs", "Quantity");
            DropColumn("dbo.Tarriffs", "Amount");
        }
    }
}
