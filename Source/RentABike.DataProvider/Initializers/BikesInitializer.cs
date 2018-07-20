using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using RentABike.Models;

namespace RentABike.DataProvider.Initializers
{
    public static class BikesInitializer
    {
        public static void Initialize(RentABikeDbContext context)
        {
            if (!context.Bikes.Any())
            {
                var bikes = new List<Bike>
                {
                    new Bike
                    {
                        BikeType = context.BikeTypes.FirstOrDefault(t=>t.Type=="Sports Bike"),
                        Description = "Женский горный велосипед любительского уровня для перемещения по городу и пересеченной местности. Велосипед сконструирован специально для девушек. Рама велосипеда выполнена из алюминиевого сплава, передняя амортизационная вилка, на велосипеде устновлены тормоза типа V-brake, прочные алюминиевые обода, навесное оборудование Shimano на 18 скоростей.",
                        Model = "Stels Miss 6000",
                    }
                };

                foreach (var bike in bikes)
                {
                    context.Bikes.Add(bike);
                }
            }
        }
    }
}
