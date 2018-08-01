using System.ComponentModel.DataAnnotations;

namespace RentABike.Models
{
    public class UserInfo :BaseModel
    {
        public  string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [MaxLength(30)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Patronymic { get; set; }

        [MaxLength(50)]
        public string Surname { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; }

        [MaxLength(30)]
        public string Email { get; set; }

        public byte[] Photo { get; set; }
    }
}