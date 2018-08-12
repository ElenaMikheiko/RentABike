using RentABike.DataProvider.Initializers;

namespace RentABike.DataProvider.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<RentABikeDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RentABikeDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            DefaultAdminInitializer.Initialize(context);
            BikeTypesInitializer.Initialize(context);
            StatusInitializer.Initialize(context);
            KindOfRentInitializer.Initialize(context);
            TarriffInitializer.Initialize(context);
            context.SaveChanges();
        }
    }
}
