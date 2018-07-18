namespace RentABike.DataProvider.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRelatedTablesForRentABike : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bikes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Model = c.String(maxLength: 100),
                        Description = c.String(maxLength: 250),
                        Image = c.Binary(),
                        BikeType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BikeTypes", t => t.BikeType_Id)
                .Index(t => t.BikeType_Id);
            
            CreateTable(
                "dbo.BikeTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RentPoints",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        Address = c.String(maxLength: 250),
                        Phone = c.String(maxLength: 13),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDateTimeRent = c.DateTime(nullable: false),
                        Amount = c.Double(nullable: false),
                        EndDateTimeRent = c.DateTime(nullable: false),
                        Bike_Id = c.Int(),
                        RentPoint_Id = c.Int(),
                        ReturnPoint_Id = c.Int(),
                        Status_Id = c.Int(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bikes", t => t.Bike_Id)
                .ForeignKey("dbo.RentPoints", t => t.RentPoint_Id)
                .ForeignKey("dbo.RentPoints", t => t.ReturnPoint_Id)
                .ForeignKey("dbo.Status", t => t.Status_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Bike_Id)
                .Index(t => t.RentPoint_Id)
                .Index(t => t.ReturnPoint_Id)
                .Index(t => t.Status_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StatusName = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RentPointBikes",
                c => new
                    {
                        RentPoint_Id = c.Int(nullable: false),
                        Bike_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RentPoint_Id, t.Bike_Id })
                .ForeignKey("dbo.RentPoints", t => t.RentPoint_Id, cascadeDelete: true)
                .ForeignKey("dbo.Bikes", t => t.Bike_Id, cascadeDelete: true)
                .Index(t => t.RentPoint_Id)
                .Index(t => t.Bike_Id);
            
            AddColumn("dbo.Roles", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Users", "RentPoint_Id", c => c.Int());
            CreateIndex("dbo.Users", "RentPoint_Id");
            AddForeignKey("dbo.Users", "RentPoint_Id", "dbo.RentPoints", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Orders", "Status_Id", "dbo.Status");
            DropForeignKey("dbo.Orders", "ReturnPoint_Id", "dbo.RentPoints");
            DropForeignKey("dbo.Orders", "RentPoint_Id", "dbo.RentPoints");
            DropForeignKey("dbo.Orders", "Bike_Id", "dbo.Bikes");
            DropForeignKey("dbo.Users", "RentPoint_Id", "dbo.RentPoints");
            DropForeignKey("dbo.RentPointBikes", "Bike_Id", "dbo.Bikes");
            DropForeignKey("dbo.RentPointBikes", "RentPoint_Id", "dbo.RentPoints");
            DropForeignKey("dbo.Bikes", "BikeType_Id", "dbo.BikeTypes");
            DropIndex("dbo.RentPointBikes", new[] { "Bike_Id" });
            DropIndex("dbo.RentPointBikes", new[] { "RentPoint_Id" });
            DropIndex("dbo.Orders", new[] { "User_Id" });
            DropIndex("dbo.Orders", new[] { "Status_Id" });
            DropIndex("dbo.Orders", new[] { "ReturnPoint_Id" });
            DropIndex("dbo.Orders", new[] { "RentPoint_Id" });
            DropIndex("dbo.Orders", new[] { "Bike_Id" });
            DropIndex("dbo.Users", new[] { "RentPoint_Id" });
            DropIndex("dbo.Bikes", new[] { "BikeType_Id" });
            DropColumn("dbo.Users", "RentPoint_Id");
            DropColumn("dbo.Roles", "Discriminator");
            DropTable("dbo.RentPointBikes");
            DropTable("dbo.Status");
            DropTable("dbo.Orders");
            DropTable("dbo.RentPoints");
            DropTable("dbo.BikeTypes");
            DropTable("dbo.Bikes");
        }
    }
}
