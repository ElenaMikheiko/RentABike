using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentABike.Models;

namespace RentABike.DataProvider.Initializers
{
    public static class KindOfRentInitializer
    {
        public static void Initialize(RentABikeDbContext context)
        {
            if (!context.KindOfRents.Any())
            {
                var kinds = new List<KindOfRent>
                {
                    new KindOfRent
                    {
                        Kind = "hour(s)",
                    },
                    new KindOfRent
                    {
                        Kind = "day(s)",
                    }
                };

                foreach (var kind in kinds)
                {
                    context.KindOfRents.Add(kind);
                }

                context.SaveChanges();
            }
        }
    }
}
