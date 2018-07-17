using Microsoft.AspNet.Identity.EntityFramework;

namespace RentABike.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual RentPoint RentPoint { get; set; }
    }
}
