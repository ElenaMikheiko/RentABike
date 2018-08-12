using System;
using System.Collections.Generic;
using System.Linq;
using RentABike.DataProvider.Interfaces;
using RentABike.Logic.Interfaces;
using RentABike.Models;
using RentABike.ViewModels;

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

        public Bike GetBikeByIdIncludingBikeType(int id)
        {
            var bike = _unitOfWork.BikeRepository.GetWithInclude(bike2 => bike2.BikeType);
            return bike.FirstOrDefault(b=>b.Id == id);
        }

        public void AddNewBike(Bike bike)
        {
            _unitOfWork.BikeRepository.Create(bike);
        }

        public void UpdateBike(EditBikeViewModel vm)
        {
            var bike = _unitOfWork.BikeRepository.FindById(vm.BikeId);
            bike.Description = vm.Description;
            bike.Model = vm.BikeModel;
            string base64;
            if (vm.Base64Image.Contains(','))
            {
                base64 = vm.Base64Image.Split(',')[1].Trim();
            }
            else
            {
                base64 = vm.Base64Image;

            }
            var imgBytes = Convert.FromBase64String(base64);

            bike.Image = imgBytes;
            bike.BikeType = _unitOfWork.BikeTypeRepository.FindById(vm.BikeTypeId);
            bike.RentPoints.Add(_unitOfWork.RentPointRepository.FindById(vm.RentPointId));
            _unitOfWork.BikeRepository.Update(bike);
            _unitOfWork.Save();
        }

        public IEnumerable<Bike> GetBikesByBikeTypeId(int bikeTypeId)
        {
            return _unitOfWork.BikeRepository.GetAllWhere(b => b.BikeType.Id == bikeTypeId);
        }
    }
}