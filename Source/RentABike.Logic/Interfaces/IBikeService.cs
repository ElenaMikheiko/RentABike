using System.Collections.Generic;
using RentABike.Models;
using RentABike.ViewModels;

namespace RentABike.Logic.Interfaces
{
    public interface IBikeService
    {
        IEnumerable<Bike> Bikes();

        Bike GetBikeById(int id);

        Bike GetBikeByIdIncludingBikeType(int id);

        void AddNewBike(Bike bike);

        void UpdateBike(EditBikeViewModel vm);

        IEnumerable<Bike> GetBikesByBikeTypeId(int bikeTypeId);
    }
}