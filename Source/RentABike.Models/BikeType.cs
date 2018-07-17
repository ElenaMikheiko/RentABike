using System.ComponentModel.DataAnnotations;

namespace RentABike.Models
{
    public class BikeType : BaseModel
    {
        [MaxLength(30)]
        public string Type { get; set; }
    }
}
