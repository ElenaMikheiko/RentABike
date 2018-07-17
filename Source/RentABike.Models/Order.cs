using System;

namespace RentABike.Models
{
    public class Order : BaseModel
    {
        public virtual ApplicationUser User { get; set; }

        public virtual Status Status { get; set; }

        public virtual Bike Bike { get; set; }

        public virtual RentPoint RentPoint { get; set; }

        public virtual RentPoint ReturnPoint { get; set; }

        public DateTime StartDateTimeRent { get; set; }

        public double Amount { get; set; }

        public DateTime EndDateTimeRent { get; set; }
    }
}
