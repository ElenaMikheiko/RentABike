namespace RentABike.DataProvider.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserInfoForUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserInfoes",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(maxLength: 30),
                        Patronymic = c.String(maxLength: 50),
                        Surname = c.String(maxLength: 50),
                        Phone = c.String(maxLength: 20),
                        Email = c.String(maxLength: 30),
                        Photo = c.Binary(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserInfoes", "Id", "dbo.Users");
            DropIndex("dbo.UserInfoes", new[] { "Id" });
            DropTable("dbo.UserInfoes");
        }
    }
}
