using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RentABike.Models;

namespace RentABike.ViewModels
{
    public class EditBikeViewModel
    {
        public int BikeId { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Model of Bike")]
        public string BikeModel { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        public int RentPointId { get; set; }

        [Display(Name = "Rent points")]
        public IEnumerable<RentPoint> RentPoints { get; set; }

        [Display(Name = "Rent points, where there is this bike:")]
        public IEnumerable<RentPoint> RentPointsWhereBikeIsExist { get; set; }

        [Display(Name = "Bike types")]
        public int BikeTypeId { get; set; }

        public IEnumerable<BikeType> BikeTypes { get; set; }

        [Required(ErrorMessage = "You must upload the image.")]
        [Display(Name = "Image")]
        public string Base64Image { get; set; }

    }
}