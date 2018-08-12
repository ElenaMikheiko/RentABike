namespace RentABike.DataProvider.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeRelationsInOrderTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "Bike_Id", "dbo.Bikes");
            DropForeignKey("dbo.Orders", "RentPoint_Id", "dbo.RentPoints");
            DropForeignKey("dbo.Orders", "ReturnPoint_Id", "dbo.RentPoints");
            DropForeignKey("dbo.Orders", "Status_Id", "dbo.Status");
            DropIndex("dbo.Orders", new[] { "Bike_Id" });
            DropIndex("dbo.Orders", new[] { "RentPoint_Id" });
            DropIndex("dbo.Orders", new[] { "ReturnPoint_Id" });
            DropIndex("dbo.Orders", new[] { "Status_Id" });
            RenameColumn(table: "dbo.Orders", name: "Bike_Id", newName: "BikeId");
            RenameColumn(table: "dbo.Orders", name: "RentPoint_Id", newName: "RentPointId");
            RenameColumn(table: "dbo.Orders", name: "ReturnPoint_Id", newName: "ReturnPointId");
            RenameColumn(table: "dbo.Orders", name: "Status_Id", newName: "StatusId");
            RenameColumn(table: "dbo.Orders", name: "User_Id", newName: "UserId");
            RenameIndex(table: "dbo.Orders", name: "IX_User_Id", newName: "IX_UserId");
            AlterColumn("dbo.Orders", "BikeId", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "RentPointId", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "ReturnPointId", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "StatusId", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "StatusId");
            CreateIndex("dbo.Orders", "BikeId");
            CreateIndex("dbo.Orders", "RentPointId");
            CreateIndex("dbo.Orders", "ReturnPointId");
            AddForeignKey("dbo.Orders", "BikeId", "dbo.Bikes", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Orders", "RentPointId", "dbo.RentPoints", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Orders", "ReturnPointId", "dbo.RentPoints", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Orders", "StatusId", "dbo.Status", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Orders", "ReturnPointId", "dbo.RentPoints");
            DropForeignKey("dbo.Orders", "RentPointId", "dbo.RentPoints");
            DropForeignKey("dbo.Orders", "BikeId", "dbo.Bikes");
            DropIndex("dbo.Orders", new[] { "ReturnPointId" });
            DropIndex("dbo.Orders", new[] { "RentPointId" });
            DropIndex("dbo.Orders", new[] { "BikeId" });
            DropIndex("dbo.Orders", new[] { "StatusId" });
            AlterColumn("dbo.Orders", "StatusId", c => c.Int());
            AlterColumn("dbo.Orders", "ReturnPointId", c => c.Int());
            AlterColumn("dbo.Orders", "RentPointId", c => c.Int());
            AlterColumn("dbo.Orders", "BikeId", c => c.Int());
            RenameIndex(table: "dbo.Orders", name: "IX_UserId", newName: "IX_User_Id");
            RenameColumn(table: "dbo.Orders", name: "UserId", newName: "User_Id");
            RenameColumn(table: "dbo.Orders", name: "StatusId", newName: "Status_Id");
            RenameColumn(table: "dbo.Orders", name: "ReturnPointId", newName: "ReturnPoint_Id");
            RenameColumn(table: "dbo.Orders", name: "RentPointId", newName: "RentPoint_Id");
            RenameColumn(table: "dbo.Orders", name: "BikeId", newName: "Bike_Id");
            CreateIndex("dbo.Orders", "Status_Id");
            CreateIndex("dbo.Orders", "ReturnPoint_Id");
            CreateIndex("dbo.Orders", "RentPoint_Id");
            CreateIndex("dbo.Orders", "Bike_Id");
            AddForeignKey("dbo.Orders", "Status_Id", "dbo.Status", "Id");
            AddForeignKey("dbo.Orders", "ReturnPoint_Id", "dbo.RentPoints", "Id");
            AddForeignKey("dbo.Orders", "RentPoint_Id", "dbo.RentPoints", "Id");
            AddForeignKey("dbo.Orders", "Bike_Id", "dbo.Bikes", "Id");
        }
    }
}
