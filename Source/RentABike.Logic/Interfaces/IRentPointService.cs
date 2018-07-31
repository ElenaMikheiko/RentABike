using System.Collections.Generic;
using RentABike.Models;
using RentABike.ViewModels;

namespace RentABike.Logic.Interfaces
{
    public interface IRentPointService
    {
        IEnumerable<RentPoint> AllRentPoint();

        void AddRentPoint(RentPointViewModel vm);

        RentPoint GetRentPointById(int id);

        void UpdateRentPoint(RentPoint rentPoint);
    }
}