using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using RentABike.DataProvider.Migrations;
using RentABike.Models;

namespace RentABike.DataProvider
{
    public class RentABikeDbContext : IdentityDbContext<ApplicationUser>
    {
        public RentABikeDbContext() : base("RentABike")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<RentABikeDbContext, Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Configurations.Add(/*new OrderConfig()*/);

            modelBuilder.Entity<ApplicationUser>()
                .ToTable("Users");

            modelBuilder.Entity<IdentityRole>()
                .ToTable("Roles");

            modelBuilder.Entity<IdentityUserRole>()
                .ToTable("UserRoles");

            modelBuilder.Entity<IdentityUserClaim>()
                .ToTable("UserClaims");

            modelBuilder.Entity<IdentityUserLogin>()
                .ToTable("UserLogins");
        }
    }
}
