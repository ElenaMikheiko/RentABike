using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RentABike.Models;

namespace RentABike.ViewModels
{
    public class DetailsBikeViewModel
    {
        public int BikeId { get; set; }

        public string Model { get; set; }

        public string Description { get; set; }

        public byte[] Image { get; set; }

        public int? BikeTypeId { get; set; }

        public virtual BikeType BikeType { get; set; }

        public virtual IList<RentPoint> RentPoints { get; set; }

        public double TarrifForOneDay { get; set; }

        public double TarrifForOneHour { get; set; }

    }
}
