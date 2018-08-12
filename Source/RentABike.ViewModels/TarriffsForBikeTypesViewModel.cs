using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RentABike.Models;

namespace RentABike.ViewModels
{
    public class TarriffsForBikeTypesViewModel
    {
        public BikeType BikeType { get; set; }

        public List<Tarriff> TarriffsForHours { get; set; }

        public List<Tarriff> TarriffsForDays { get; set; }

    }
}
