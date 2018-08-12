using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;
using RentABike.Models;

namespace RentABike.ViewModels
{
    public class EditPersonalUserInfoViewModel
    {
        public string UserId { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Patronymic { get; set; }

        [Required]
        [MaxLength(50)]
        public string Surname { get; set; }

        [Required]
        [MaxLength(20)]
        public string Phone { get; set; }

        [Required]
        [MaxLength(30)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string Base64Image { get; set; }

        public string Role { get; set; }

        [Display(Name = "Rent point")]
        public int RentPointId { get; set; }

        public IEnumerable<RentPoint> RentPoints { get; set; }

    }
}
