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
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        Name = c.String(maxLength: 30),
                        Patronymic = c.String(maxLength: 50),
                        Surname = c.String(maxLength: 50),
                        Phone = c.String(maxLength: 20),
                        Email = c.String(maxLength: 30),
                        Photo = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Users", "UserInfoId", c => c.Int());
            AddColumn("dbo.Users", "UserId", c => c.Int());
            CreateIndex("dbo.Users", "UserInfoId");
            CreateIndex("dbo.Users", "UserId");
            AddForeignKey("dbo.Users", "UserInfoId", "dbo.UserInfoes", "Id");
            AddForeignKey("dbo.Users", "UserId", "dbo.UserInfoes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "UserId", "dbo.UserInfoes");
            DropForeignKey("dbo.Users", "UserInfoId", "dbo.UserInfoes");
            DropIndex("dbo.Users", new[] { "UserId" });
            DropIndex("dbo.Users", new[] { "UserInfoId" });
            DropColumn("dbo.Users", "UserId");
            DropColumn("dbo.Users", "UserInfoId");
            DropTable("dbo.UserInfoes");
        }
    }
}
