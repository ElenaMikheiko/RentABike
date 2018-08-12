using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RentABike.Models;

namespace RentABike.ViewModels
{
    public class CreationOrderViewModel
    {
        public string UserId { get; set; }

        public int RentPointId { get; set; }

        [Display(Name = "Rent Point")]
        public IEnumerable<RentPoint> RentPoints { get; set; }

        public int BikeId { get; set; }

        [Display(Name = "Bike model")]
        public string BikeModel { get; set; }

        public int BikeTypeId { get; set; }

        public int ReturnPointId { get; set; }

        [Display(Name = "Return Point")]
        public IEnumerable<RentPoint> ReturnPoints { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "dd.MM.yyyy", ApplyFormatInEditMode = true)]
        [Display(Name = "Rental start date")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "HH:mm", ApplyFormatInEditMode = true)]
        [Display(Name = "Rental start date")]
        public DateTime StartTime { get; set; }

        //[Range(1, 24, ErrorMessage = "Can only be between 0 .. 15")]
        //public int RentalTime { get; set; }

        //public string KindOfTimeRent { get; set; }

        public int TarriffId { get; set; }

        public IEnumerable<Tarriff> Tarriffs { get; set; }

        public double Amount { get; set; }

        public DateTime EndDateTime { get; set; }

        public DateTime DateTimeCreationOrder { get; set; }
    }
}
