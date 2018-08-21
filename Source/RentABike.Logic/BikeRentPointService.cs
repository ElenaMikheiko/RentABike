using System;
using System.Collections.Generic;
using RentABike.Common.Interfaces;
using RentABike.Models;
using RentABike.ViewModels;

namespace RentABike.Logic
{
    public class BikeRentPointService : IBikeRentPointService
    {

        private readonly IUnitOfWork _uof;

        public BikeRentPointService(IUnitOfWork unitOfWork)
        {
            _uof = unitOfWork;
        }

        public void SaveBikeAndRentPoint(CreationBikeViewModel vm)
        {
            string base64 = vm.Base64Image.Split(',')[1].Trim();
            var bytes = Convert.FromBase64String(base64);
            var rp = _uof.RentPointRepository.FindById(vm.RentPointId);
            var bt = _uof.BikeTypeRepository.FindById(vm.BikeTypeId);
            var bike = new Bike()
            {
                BikeType = bt,
                Image = bytes,
                Description = vm.Description,
                Model = vm.BikeModel,
                
            };

            bike.RentPoints = new List<RentPoint> {rp};

            _uof.BikeRepository.Create(bike);
            _uof.Save();
        }
    }
}