namespace RentABike.DataProvider.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTariffsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tarriffs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KindOfRentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.KindOfRents", t => t.KindOfRentId, cascadeDelete: true)
                .Index(t => t.KindOfRentId);
            
            CreateTable(
                "dbo.KindOfRents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Kind = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TarriffBikeTypes",
                c => new
                    {
                        Tarriff_Id = c.Int(nullable: false),
                        BikeType_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tarriff_Id, t.BikeType_Id })
                .ForeignKey("dbo.Tarriffs", t => t.Tarriff_Id, cascadeDelete: true)
                .ForeignKey("dbo.BikeTypes", t => t.BikeType_Id, cascadeDelete: true)
                .Index(t => t.Tarriff_Id)
                .Index(t => t.BikeType_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tarriffs", "KindOfRentId", "dbo.KindOfRents");
            DropForeignKey("dbo.TarriffBikeTypes", "BikeType_Id", "dbo.BikeTypes");
            DropForeignKey("dbo.TarriffBikeTypes", "Tarriff_Id", "dbo.Tarriffs");
            DropIndex("dbo.TarriffBikeTypes", new[] { "BikeType_Id" });
            DropIndex("dbo.TarriffBikeTypes", new[] { "Tarriff_Id" });
            DropIndex("dbo.Tarriffs", new[] { "KindOfRentId" });
            DropTable("dbo.TarriffBikeTypes");
            DropTable("dbo.KindOfRents");
            DropTable("dbo.Tarriffs");
        }
    }
}
