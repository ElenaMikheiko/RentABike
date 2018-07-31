using System.Collections.Generic;
using RentABike.Models;

namespace RentABike.Logic.Interfaces
{
    public interface IBikeService
    {
        IEnumerable<Bike> Bikes();

        Bike GetBikeById(int id);

        void SaveBike(Bike bike);
    }
}