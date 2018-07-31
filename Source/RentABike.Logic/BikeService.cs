using System.Collections.Generic;
using RentABike.DataProvider.Interfaces;
using RentABike.Logic.Interfaces;
using RentABike.Models;

namespace RentABike.Logic
{
    public class BikeService : IBikeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BikeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Bike> Bikes()
        {
            return _unitOfWork.BikeRepository.GetWithInclude(bike => bike.BikeType);
        }

        public Bike GetBikeById(int id)
        {
            return _unitOfWork.BikeRepository.FindById(id);
        }

        public void SaveBike(Bike bike)
        {
            _unitOfWork.BikeRepository.Create(bike);
        }
    }
}