using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
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

        public DbSet<BikeType> BikeTypes { get; set; }

        public DbSet<RentPoint> RentPoints { get; set; }

        public DbSet<Bike> Bikes { get; set; }

        public DbSet<Status> Statuses { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<UserInfo> UserInfos { get; set; }

        public DbSet<KindOfRent> KindOfRents { get; set; }

        public DbSet<Tarriff> Tarriffs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Identity

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

            #endregion
        }
    }
}