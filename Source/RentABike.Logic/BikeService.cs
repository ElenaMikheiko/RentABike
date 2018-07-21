using System.Collections.Generic;
using RentABike.DataProvider.Interfaces;
using RentABike.Logic.Interfaces;
using RentABike.Models;

namespace RentABike.Logic
{
    public class BikeService : IBikeService
    {
        private readonly IRepository<Bike> _bikeRepository;

        public BikeService(IRepository<Bike> bikeRepository)
        {
            _bikeRepository = bikeRepository;
        }

        public IEnumerable<Bike> Bikes()
        {
            return _bikeRepository.GetWithInclude(bike => bike.BikeType);
        }
    }
}