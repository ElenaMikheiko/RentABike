using System.Collections.Generic;
using RentABike.Models;

namespace RentABike.Logic.Interfaces
{
    public interface IBikeTypeService
    {
        IEnumerable<BikeType> AllBikeTypes();

        void SaveBikeType(BikeType bikeType);

        BikeType GetBikeTypeById(int id);
    }
}