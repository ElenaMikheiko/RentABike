using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentABike.Models;
using RentABike.ViewModels;

namespace RentABike.Logic.Interfaces
{
    public interface IRentPointService
    {
        IEnumerable<RentPoint> AllRentPoint();

        void AddRentPoint(RentPointViewModel vm);
    }
}
