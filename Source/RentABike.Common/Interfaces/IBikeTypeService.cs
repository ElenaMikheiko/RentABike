using System.Collections.Generic;
using RentABike.Models;

namespace RentABike.Common.Interfaces
{
    public interface IBikeTypeService
    {
        IEnumerable<BikeType> AllBikeTypes();

        void SaveBikeType(BikeType bikeType);

        BikeType GetBikeTypeById(int id);

        void DeleteBikeType(int id);
    }
}