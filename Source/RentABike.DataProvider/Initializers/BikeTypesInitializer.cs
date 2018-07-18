using System.Collections.Generic;
using System.Data.Entity.Migrations;
using RentABike.Models;

namespace RentABike.DataProvider.Initializers
{
    public static class BikeTypesInitializer
    {
        public static void Initialize(RentABikeDbContext context)
        {
            var bikeTypes = new List<BikeType>
            {
                new BikeType
                {
                    Type = "Sports bike"
                },
                new BikeType
                {
                    Type = "Cruiser bike"
                },
                new BikeType
                {
                    Type = "On-road bike"
                },
                new BikeType
                {
                    Type = "Custom bike"
                }
            };

            foreach (var bikeType in bikeTypes)
            {
                context.BikeTypes.AddOrUpdate(bikeType);
            }
        }
    }
}