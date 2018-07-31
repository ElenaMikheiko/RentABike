using System.Collections.Generic;
using RentABike.DataProvider;
using RentABike.DataProvider.Interfaces;
using RentABike.Logic.Interfaces;
using RentABike.Models;

namespace RentABike.Logic
{
    public class BikeTypeService : IBikeTypeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BikeTypeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<BikeType> AllBikeTypes()
        {
            return _unitOfWork.BikeTypeRepository.GetAll();
        }

        public BikeType GetBikeTypeById(int id)
        {
            return _unitOfWork.BikeTypeRepository.FindById(id);
        }

        public void SaveBikeType(BikeType bikeType)
        {
            _unitOfWork.BikeTypeRepository.Create(bikeType);
        }
    }
}