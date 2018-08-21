namespace RentABike.DataProvider.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _123 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bikes", "BikeTypeId", "dbo.BikeTypes");
            DropIndex("dbo.Bikes", new[] { "BikeTypeId" });
            AlterColumn("dbo.Bikes", "BikeTypeId", c => c.Int());
            CreateIndex("dbo.Bikes", "BikeTypeId");
            AddForeignKey("dbo.Bikes", "BikeTypeId", "dbo.BikeTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bikes", "BikeTypeId", "dbo.BikeTypes");
            DropIndex("dbo.Bikes", new[] { "BikeTypeId" });
            AlterColumn("dbo.Bikes", "BikeTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Bikes", "BikeTypeId");
            AddForeignKey("dbo.Bikes", "BikeTypeId", "dbo.BikeTypes", "Id", cascadeDelete: true);
        }
    }
}
