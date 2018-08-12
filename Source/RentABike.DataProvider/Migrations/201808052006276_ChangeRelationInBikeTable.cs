namespace RentABike.DataProvider.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeRelationInBikeTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bikes", "BikeType_Id", "dbo.BikeTypes");
            DropIndex("dbo.Bikes", new[] { "BikeType_Id" });
            RenameColumn(table: "dbo.Bikes", name: "BikeType_Id", newName: "BikeTypeId");
            AlterColumn("dbo.Bikes", "BikeTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Bikes", "BikeTypeId");
            AddForeignKey("dbo.Bikes", "BikeTypeId", "dbo.BikeTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bikes", "BikeTypeId", "dbo.BikeTypes");
            DropIndex("dbo.Bikes", new[] { "BikeTypeId" });
            AlterColumn("dbo.Bikes", "BikeTypeId", c => c.Int());
            RenameColumn(table: "dbo.Bikes", name: "BikeTypeId", newName: "BikeType_Id");
            CreateIndex("dbo.Bikes", "BikeType_Id");
            AddForeignKey("dbo.Bikes", "BikeType_Id", "dbo.BikeTypes", "Id");
        }
    }
}
