using RentABike.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentABike.ViewModels
{
    public class CreateBikeViewModel
    {
        public string BikeModel { get; set; }

        public byte[] Image { get; set; }

        public string Description { get; set; }

        public IEnumerable<BikeType> BikeTypes { get; set; }

        public int BikeTypeId { get; set; }

        public IEnumerable<RentPoint> RentPoints { get; set; }

        public int RentPointId { get; set; }


    }
}
