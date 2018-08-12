using System;
using System.Collections.Generic;
using RentABike.Models;

namespace RentABike.ViewModels
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }

        public string StatusOrder { get; set; }

        public DateTime DateTimeCreationOrder { get; set; }

        public double TotalCost { get; set; }

        public DateTime StartDateTimeRent { get; set; }

        public DateTime EndDateTimeRent { get; set; }

        public int RentPointId { get; set; }

        public RentPoint RentPoint { get; set; }

        public int ReturntRentPointId { get; set; }

        public RentPoint ReturnRentPoint { get; set; }

        public int BikeId { get; set; }

        public string BikeModel { get; set; }

        public int BikeTypeId { get; set; }

        public string BikeTypeName { get; set; }

        public string CustomerFullName { get; set; }

        public string CustomerPhoneNumber { get; set; }

        public int TarriffQuantity { get; set; }

        public string TarriffType { get; set; }

        public double Amount { get; set; }

        //public IEnumerable<Order> Orders { get; set; }

        //public PageInfo PageInfo { get; set; }
    }
}
