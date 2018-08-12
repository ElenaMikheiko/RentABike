using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentABike.Models
{
    public class Order : BaseModel
    {
        [ForeignKey("User")]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [ForeignKey("Status")]
        public int StatusId { get; set; }

        public virtual Status Status { get; set; }

        [ForeignKey("Bike")]
        public int BikeId { get; set; }

        public virtual Bike Bike { get; set; }

        [ForeignKey("RentPoint")]
        public int RentPointId { get; set; }

        public virtual RentPoint RentPoint { get; set; }

        [ForeignKey("ReturnPoint")]
        public int ReturnPointId { get; set; }

        public virtual RentPoint ReturnPoint { get; set; }

        public DateTime StartDateTimeRent { get; set; }

        public double Amount { get; set; }

        public DateTime EndDateTimeRent { get; set; }

        public DateTime DateTimeCreationOrder { get; set; }

        [ForeignKey("Tarriff")]
        public int TarriffId { get; set; }

        public virtual Tarriff Tarriff { get; set; }

    }
}
