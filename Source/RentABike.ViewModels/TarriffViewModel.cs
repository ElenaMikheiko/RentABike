using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentABike.Models;

namespace RentABike.ViewModels
{
    public class TarriffViewModel
    {
        public BikeType BikeType { get; set; }

        public List<TarriffForEdit> Tarriffs { get; set; }

        public bool IsNew { get; set; }
    }

    public class TarriffForEdit
    {
        public KindOfRent KindOfRent { get; set; }

        public int Quantity { get; set; }

        public double Amount { get; set; }
    }
}
