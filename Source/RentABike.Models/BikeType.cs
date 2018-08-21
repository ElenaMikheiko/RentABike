using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RentABike.Models
{
    public class BikeType : BaseModel
    {
        [Required]
        [MaxLength(30)]
        public string Type { get; set; }

        public virtual IList<Tarriff> Tarriffs { get; set; }

        public virtual IList<Bike> Bikes { get; set; }

        public BikeType()
        {
            Tarriffs = new List<Tarriff>();
            Bikes = new List<Bike>();
        }

    }
}
