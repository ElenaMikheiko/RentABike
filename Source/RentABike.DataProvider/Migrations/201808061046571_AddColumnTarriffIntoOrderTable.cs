namespace RentABike.DataProvider.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnTarriffIntoOrderTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "TarriffId", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "TarriffId");
            AddForeignKey("dbo.Orders", "TarriffId", "dbo.Tarriffs", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "TarriffId", "dbo.Tarriffs");
            DropIndex("dbo.Orders", new[] { "TarriffId" });
            DropColumn("dbo.Orders", "TarriffId");
        }
    }
}
