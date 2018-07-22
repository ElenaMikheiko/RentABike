using RentABike.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RentABike.ViewModels
{
    public class CreationBikeViewModel
    {
        public int BikeId { get; set; }

        [Display(Name = "Model of Bike")]
        public string BikeModel { get; set; }

        public byte[] Image { get; set; }

        public string Description { get; set; }

        public IEnumerable<BikeType> BikeTypes { get; set; }

        [Display(Name = "Type of Bike")]
        public int BikeTypeId { get; set; }

        public IEnumerable<RentPoint> RentPoints { get; set; }

        [Display(Name = "Rent Point")]
        public int RentPointId { get; set; }
    }
}
