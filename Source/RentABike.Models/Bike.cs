using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.AccessControl;

namespace RentABike.Models
{
    public class Bike : BaseModel
    {
        [MaxLength(100)]
        public string Model { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        public byte[] Image { get; set; }

        [ForeignKey("BikeType")]
        public int? BikeTypeId { get; set; }

        public virtual BikeType BikeType { get; set; }

        public virtual IList<RentPoint> RentPoints { get; set; }

    }
}