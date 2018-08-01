using RentABike.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RentABike.ViewModels
{
    public class CreationBikeViewModel
    {
        public int BikeId { get; set; }

        [Display(Name = "Model of Bike")]
        [MaxLength(100)]
        public string BikeModel { get; set; }

        [Required]
        public string Base64Image { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        public IEnumerable<BikeType> BikeTypes { get; set; }

        [Display(Name = "Type of Bike")]
        public int BikeTypeId { get; set; }

        public IEnumerable<RentPoint> RentPoints { get; set; }

        [Display(Name = "Rent Point")]
        public int RentPointId { get; set; }
    }
}
