using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;
using RentABike.Models;

namespace RentABike.ViewModels
{
    public class PreviewNewOrderViewModel
    {
        public string UserId { get; set; }

        public int RentPointId { get; set; }

        public RentPoint RentPoint { get; set; }

        public int BikeId { get; set; }

        [Display(Name = "Bike model")]
        public string BikeModel { get; set; }

        public int ReturnPointId { get; set; }

        public RentPoint ReturnPoint { get; set; }

        public DateTime StartDateTime { get; set; }

        public int RentalTime { get; set; }

        public string KindOfTimeRent { get; set; }

        public double Amount { get; set; }

        public DateTime EndDateTime { get; set; }

        public DateTime DateTimeCreationOrder { get; set; }

        public int BikeTypeId { get; set; }

        public int TarriffId { get; set; }

        public Tarriff Tarriff { get; set; }

    }
}
