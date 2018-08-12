using RentABike.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RentABike.ViewModels
{
    public class CreationBikeViewModel
    {
        public int BikeId { get; set; }

        [Required]
        [Display(Name = "Model of Bike")]
        [MaxLength(100)]
        public string BikeModel { get; set; }

        [Required(ErrorMessage = "You must upload the image.")]
        [Display(Name = "Image")]
        public string Base64Image { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        public IEnumerable<BikeType> BikeTypes { get; set; }

        [Display(Name = "Type of Bike")]
        [Required]
        public int BikeTypeId { get; set; }

        public IEnumerable<RentPoint> RentPoints { get; set; }

        [Required]
        [Display(Name = "Rent Point")]
        public int RentPointId { get; set; }
    }
}
