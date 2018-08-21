using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using RentABike.Models;

namespace RentABike.ViewModels
{
    public class EditPersonalUserInfoViewModel
    {
        public string UserId { get; set; }

        [Required]
        [MaxLength(30)]
        [AllowHtml]
        public string Name { get; set; }

        [MaxLength(50)]
        [AllowHtml]
        public string Patronymic { get; set; }

        [Required]
        [MaxLength(50)]
        [AllowHtml]
        public string Surname { get; set; }

        [Required]
        [MaxLength(20)]
        [AllowHtml]
        public string Phone { get; set; }

        [Required]
        [MaxLength(30)]
        [DataType(DataType.EmailAddress)]
        [AllowHtml]
        public string Email { get; set; }

        public string Base64Image { get; set; }

        public string Role { get; set; }

        [Display(Name = "Rent point")]
        public int RentPointId { get; set; }

        public IEnumerable<RentPoint> RentPoints { get; set; }

    }
}
