using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentABike.Models;

namespace RentABike.DataProvider.Initializers
{
    public static class TarriffInitializer
    {
        public static void Initialize(RentABikeDbContext context)
        {
            if (!context.Tarriffs.Any())
            {
                var tarriffs = new List<Tarriff>
                {
                    /*Tarriffs for sports bike*/

                    //hour(s)
                    new Tarriff
                    {
                        Quantity = 1,
                        KindOfRent = context.KindOfRents.FirstOrDefault(k=>k.Kind == "hour(s)"),
                        Amount = 5,
                        BikeTypes = new List<BikeType>{context.BikeTypes.FirstOrDefault(t=>t.Type == "Sports bike") }
                    },
                    new Tarriff
                    {
                        Quantity = 2,
                        KindOfRent = context.KindOfRents.FirstOrDefault(k=>k.Kind == "hour(s)"),
                        Amount = 7,
                        BikeTypes = new List<BikeType>{context.BikeTypes.FirstOrDefault(t=>t.Type == "Sports bike") }
                    },
                    new Tarriff
                    {
                        Quantity = 3,
                        KindOfRent = context.KindOfRents.FirstOrDefault(k=>k.Kind == "hour(s)"),
                        Amount = 9,
                        BikeTypes = new List<BikeType>{context.BikeTypes.FirstOrDefault(t=>t.Type == "Sports bike") }
                    },
                    new Tarriff
                    {
                        Quantity = 4,
                        KindOfRent = context.KindOfRents.FirstOrDefault(k=>k.Kind == "hour(s)"),
                        Amount = 11,
                        BikeTypes = new List<BikeType>{context.BikeTypes.FirstOrDefault(t=>t.Type == "Sports bike") }
                    },
                    new Tarriff
                    {
                        Quantity = 5,
                        KindOfRent = context.KindOfRents.FirstOrDefault(k=>k.Kind == "hour(s)"),
                        Amount = 13,
                        BikeTypes = new List<BikeType>{context.BikeTypes.FirstOrDefault(t=>t.Type == "Sports bike") }
                    },

                    //day(s)

                    new Tarriff
                    {
                        Quantity = 1,
                        KindOfRent = context.KindOfRents.FirstOrDefault(k=>k.Kind == "day(s)"),
                        Amount = 15,
                        BikeTypes = new List<BikeType>{context.BikeTypes.FirstOrDefault(t=>t.Type == "Sports bike") }
                    },
                    new Tarriff
                    {
                        Quantity = 2,
                        KindOfRent = context.KindOfRents.FirstOrDefault(k=>k.Kind == "day(s)"),
                        Amount = 25,
                        BikeTypes = new List<BikeType>{context.BikeTypes.FirstOrDefault(t=>t.Type == "Sports bike") }
                    },
                    new Tarriff
                    {
                        Quantity = 3,
                        KindOfRent = context.KindOfRents.FirstOrDefault(k=>k.Kind == "day(s)"),
                        Amount = 35,
                        BikeTypes = new List<BikeType>{context.BikeTypes.FirstOrDefault(t=>t.Type == "Sports bike") }
                    },

                    /*Tarriffs for Cruiser bike*/
                    
                    //hour(s)
                    new Tarriff
                    {
                        Quantity = 1,
                        KindOfRent = context.KindOfRents.FirstOrDefault(k=>k.Kind == "hour(s)"),
                        Amount = 8,
                        BikeTypes = new List<BikeType>{context.BikeTypes.FirstOrDefault(t=>t.Type == "Cruiser bike") }
                    },
                    new Tarriff
                    {
                        Quantity = 2,
                        KindOfRent = context.KindOfRents.FirstOrDefault(k=>k.Kind == "hour(s)"),
                        Amount = 10,
                        BikeTypes = new List<BikeType>{context.BikeTypes.FirstOrDefault(t=>t.Type == "Cruiser bike") }
                    },
                    new Tarriff
                    {
                        Quantity = 3,
                        KindOfRent = context.KindOfRents.FirstOrDefault(k=>k.Kind == "hour(s)"),
                        Amount = 12,
                        BikeTypes = new List<BikeType>{context.BikeTypes.FirstOrDefault(t=>t.Type == "Cruiser bike") }
                    },
                    new Tarriff
                    {
                        Quantity = 4,
                        KindOfRent = context.KindOfRents.FirstOrDefault(k=>k.Kind == "hour(s)"),
                        Amount = 14,
                        BikeTypes = new List<BikeType>{context.BikeTypes.FirstOrDefault(t=>t.Type == "Cruiser bike") }
                    },
                    new Tarriff
                    {
                        Quantity = 5,
                        KindOfRent = context.KindOfRents.FirstOrDefault(k=>k.Kind == "hour(s)"),
                        Amount = 16,
                        BikeTypes = new List<BikeType>{context.BikeTypes.FirstOrDefault(t=>t.Type == "Cruiser bike") }
                    },

                    //day(s)

                    new Tarriff
                    {
                        Quantity = 1,
                        KindOfRent = context.KindOfRents.FirstOrDefault(k=>k.Kind == "day(s)"),
                        Amount = 18,
                        BikeTypes = new List<BikeType>{context.BikeTypes.FirstOrDefault(t=>t.Type == "Cruiser bike") }
                    },
                    new Tarriff
                    {
                        Quantity = 2,
                        KindOfRent = context.KindOfRents.FirstOrDefault(k=>k.Kind == "day(s)"),
                        Amount = 30,
                        BikeTypes = new List<BikeType>{context.BikeTypes.FirstOrDefault(t=>t.Type == "Cruiser bike") }
                    },
                    new Tarriff
                    {
                        Quantity = 3,
                        KindOfRent = context.KindOfRents.FirstOrDefault(k=>k.Kind == "day(s)"),
                        Amount = 40,
                        BikeTypes = new List<BikeType>{context.BikeTypes.FirstOrDefault(t=>t.Type == "Cruiser bike") }
                    },
                    
                    
                    /*Tarriffs for Cruiser bike*/
                    
                    //hour(s)
                    new Tarriff
                    {
                        Quantity = 1,
                        KindOfRent = context.KindOfRents.FirstOrDefault(k=>k.Kind == "hour(s)"),
                        Amount = 10,
                        BikeTypes = new List<BikeType>{context.BikeTypes.FirstOrDefault(t=>t.Type == "On-road bike") }
                    },
                    new Tarriff
                    {
                        Quantity = 2,
                        KindOfRent = context.KindOfRents.FirstOrDefault(k=>k.Kind == "hour(s)"),
                        Amount = 12,
                        BikeTypes = new List<BikeType>{context.BikeTypes.FirstOrDefault(t=>t.Type == "On-road bike") }
                    },
                    new Tarriff
                    {
                        Quantity = 3,
                        KindOfRent = context.KindOfRents.FirstOrDefault(k=>k.Kind == "hour(s)"),
                        Amount = 14,
                        BikeTypes = new List<BikeType>{context.BikeTypes.FirstOrDefault(t=>t.Type == "On-road bike") }
                    },
                    new Tarriff
                    {
                        Quantity = 4,
                        KindOfRent = context.KindOfRents.FirstOrDefault(k=>k.Kind == "hour(s)"),
                        Amount = 16,
                        BikeTypes = new List<BikeType>{context.BikeTypes.FirstOrDefault(t=>t.Type == "On-road bike") }
                    },
                    new Tarriff
                    {
                        Quantity = 5,
                        KindOfRent = context.KindOfRents.FirstOrDefault(k=>k.Kind == "hour(s)"),
                        Amount = 18,
                        BikeTypes = new List<BikeType>{context.BikeTypes.FirstOrDefault(t=>t.Type == "On-road bike") }
                    },

                    //day(s)

                    new Tarriff
                    {
                        Quantity = 1,
                        KindOfRent = context.KindOfRents.FirstOrDefault(k=>k.Kind == "day(s)"),
                        Amount = 20,
                        BikeTypes = new List<BikeType>{context.BikeTypes.FirstOrDefault(t=>t.Type == "On-road bike") }
                    },
                    new Tarriff
                    {
                        Quantity = 2,
                        KindOfRent = context.KindOfRents.FirstOrDefault(k=>k.Kind == "day(s)"),
                        Amount = 35,
                        BikeTypes = new List<BikeType>{context.BikeTypes.FirstOrDefault(t=>t.Type == "On-road bike") }
                    },
                    new Tarriff
                    {
                        Quantity = 3,
                        KindOfRent = context.KindOfRents.FirstOrDefault(k=>k.Kind == "day(s)"),
                        Amount = 45,
                        BikeTypes = new List<BikeType>{context.BikeTypes.FirstOrDefault(t=>t.Type == "On-road bike") }
                    },

                    /*Tarriffs for Custom bike*/
                    
                    //hour(s)
                    new Tarriff
                    {
                        Quantity = 1,
                        KindOfRent = context.KindOfRents.FirstOrDefault(k=>k.Kind == "hour(s)"),
                        Amount = 12,
                        BikeTypes = new List<BikeType>{context.BikeTypes.FirstOrDefault(t=>t.Type == "Custom bike") }
                    },
                    new Tarriff
                    {
                        Quantity = 2,
                        KindOfRent = context.KindOfRents.FirstOrDefault(k=>k.Kind == "hour(s)"),
                        Amount = 14,
                        BikeTypes = new List<BikeType>{context.BikeTypes.FirstOrDefault(t=>t.Type == "Custom bike") }
                    },
                    new Tarriff
                    {
                        Quantity = 3,
                        KindOfRent = context.KindOfRents.FirstOrDefault(k=>k.Kind == "hour(s)"),
                        Amount = 16,
                        BikeTypes = new List<BikeType>{context.BikeTypes.FirstOrDefault(t=>t.Type == "Custom bike") }
                    },
                    new Tarriff
                    {
                        Quantity = 4,
                        KindOfRent = context.KindOfRents.FirstOrDefault(k=>k.Kind == "hour(s)"),
                        Amount = 18,
                        BikeTypes = new List<BikeType>{context.BikeTypes.FirstOrDefault(t=>t.Type == "Custom bike") }
                    },
                    new Tarriff
                    {
                        Quantity = 5,
                        KindOfRent = context.KindOfRents.FirstOrDefault(k=>k.Kind == "hour(s)"),
                        Amount = 20,
                        BikeTypes = new List<BikeType>{context.BikeTypes.FirstOrDefault(t=>t.Type == "Custom bike") }
                    },

                    //day(s)

                    new Tarriff
                    {
                        Quantity = 1,
                        KindOfRent = context.KindOfRents.FirstOrDefault(k=>k.Kind == "day(s)"),
                        Amount = 22,
                        BikeTypes = new List<BikeType>{context.BikeTypes.FirstOrDefault(t=>t.Type == "Custom bike") }
                    },
                    new Tarriff
                    {
                        Quantity = 2,
                        KindOfRent = context.KindOfRents.FirstOrDefault(k=>k.Kind == "day(s)"),
                        Amount = 40,
                        BikeTypes = new List<BikeType>{context.BikeTypes.FirstOrDefault(t=>t.Type == "Custom bike") }
                    },
                    new Tarriff
                    {
                        Quantity = 3,
                        KindOfRent = context.KindOfRents.FirstOrDefault(k=>k.Kind == "day(s)"),
                        Amount = 50,
                        BikeTypes = new List<BikeType>{context.BikeTypes.FirstOrDefault(t=>t.Type == "Custom bike") }
                    }
                };
                foreach (var tarriff in tarriffs)
                {
                    context.Tarriffs.Add(tarriff);
                }
            }
        }
    }
}