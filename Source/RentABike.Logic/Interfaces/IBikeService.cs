using System.Collections.Generic;
using RentABike.Models;

namespace RentABike.Logic.Interfaces
{
    public interface IBikeService
    {
        IEnumerable<Bike> Bikes();

        Bike GetBikById(int id);
    }
}