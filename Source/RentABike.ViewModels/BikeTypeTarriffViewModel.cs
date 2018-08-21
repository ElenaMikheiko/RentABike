using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using RentABike.Models;

namespace RentABike.ViewModels
{
    public class BikeTypeTarriffViewModel
    {
        [Required]
        [MaxLength(30)]
        [AllowHtml]
        public string Type { get; set; }

        public IEnumerable<Tarriff> Tarriffs { get; set; }

        public int TarriffId { get; set; }

        public IEnumerable<KindOfRent> KindsOfRent { get; set; }

        [Required]
        public double Amount { get; set; }

        [Required]
        public int Quantity { get; set; }

    }
}
