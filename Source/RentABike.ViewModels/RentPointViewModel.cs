using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace RentABike.ViewModels
{
    public class RentPointViewModel
    {
        public int RentPointId { get; set; }

        [Required]
        [MaxLength(100)]

        public string Name { get; set; }

        [Required]
        [MaxLength(250)]

        public string Address { get; set; }

        [Required]
        [MaxLength(20)]
        public string Phone { get; set; }
    }
}
