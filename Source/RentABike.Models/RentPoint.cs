using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RentABike.Models
{
    public class RentPoint : BaseModel
    {
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(250)]
        public string Address { get; set; }

        [MaxLength(13)]
        public string Phone { get; set; }

        public virtual IList<ApplicationUser> Sellers { get; set; }

        public virtual IList<Bike> Bikes { get; set; }

        public RentPoint()
        {
            Sellers = new List<ApplicationUser>();

            Bikes = new List<Bike>();
        }

    }
}
