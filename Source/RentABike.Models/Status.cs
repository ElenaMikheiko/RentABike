using System.ComponentModel.DataAnnotations;

namespace RentABike.Models
{
    public class Status : BaseModel
    {
        [MaxLength(20)]
        public string StatusName { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }
    }
}
