using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentABike.Models
{
    public class Tarriff : BaseModel
    {
        [ForeignKey("KindOfRent")]
        public int KindOfRentId { get; set; }

        public virtual KindOfRent KindOfRent { get; set; }

        public virtual IList<BikeType> BikeTypes { get; set; }

        public double Amount { get; set; }

        public int Quantity { get; set; }

        public Tarriff()
        {
            BikeTypes = new List<BikeType>();
        }
    }
}
