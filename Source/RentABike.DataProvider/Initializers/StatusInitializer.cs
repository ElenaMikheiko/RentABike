using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentABike.Models;
using RentABike.Models.Constants;

namespace RentABike.DataProvider.Initializers
{
    public static class StatusInitializer
    {
        public static void Initialize(RentABikeDbContext context)
        {
            if (!context.Statuses.Any())
            {
                var statuses = new List<Status>
                {
                    new Status
                    {
                        StatusName = OrderStatus.Overdue,
                        Description =
                            "If the user has given the bicycle to the rental point after the deadline, the order becomes OVERDUE.Payment is charged according to the tariff as for the whole hour."
                    },
                    new Status
                    {
                        StatusName = OrderStatus.Annulled,
                        Description =
                            "If the user did not receive the order 10 minutes after the appointed time, the order becomes ANNULED."
                    },
                    new Status
                    {
                        StatusName = OrderStatus.Cancelled,
                        Description =
                            "User canceled the order 10 minutes before the scheduled start rental time. The order becomes CANCELLED."
                    },
                    new Status
                    {
                        StatusName = OrderStatus.Active,
                        Description =
                            "This status is become after the delivery of the bike, but before the completion of the order."
                    },
                    new Status
                    {
                        StatusName = OrderStatus.Booked,
                        Description =
                            "This status has been set for a new order."
                    },
                    new Status
                    {
                        StatusName = OrderStatus.Completed,
                        Description =
                            "This status has been set for completed order."
                    },
                };

                foreach (var status in statuses)
                {
                    context.Statuses.Add(status);
                }
            }

        }
    }
}
