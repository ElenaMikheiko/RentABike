using System.Collections.Generic;
using RentABike.Models;
using RentABike.ViewModels;

namespace RentABike.Common.Interfaces
{
    public interface IRentPointService
    {
        IEnumerable<RentPoint> AllRentPoint();

        void AddRentPoint(RentPointViewModel vm);

        RentPoint GetRentPointById(int id);

        void UpdateRentPoint(RentPoint rentPoint);

        void DeleteRentPoint(RentPoint rentPoint);
    }
}