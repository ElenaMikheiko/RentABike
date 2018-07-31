using System;
using System.Collections.Generic;
using RentABike.DataProvider.Interfaces;
using RentABike.Logic.Interfaces;
using RentABike.Models;
using RentABike.ViewModels;

namespace RentABike.Logic
{
    public class BikeRentPointService : IBikeRentPointService
    {

        private readonly IUnitOfWork _uof;
        private readonly IBikeService _bikeService;

        private readonly IRentPointService _rentPointService;

        private readonly IBikeTypeService _bikeTypeService;

        public BikeRentPointService(IBikeService bikeService, IRentPointService rentPointService, IBikeTypeService bikeTypeService, IUnitOfWork unitOfWork)
        {
            _bikeService = bikeService;
            _rentPointService = rentPointService;
            _bikeTypeService = bikeTypeService;
            _uof = unitOfWork;
        }

        public void SaveBikeAndRentPoint(CreationBikeViewModel vm)
        {
            string base64 = vm.Base64Image.Split(',')[1].Trim();
            var bytes = Convert.FromBase64String(base64);
            var rp = _rentPointService.GetRentPointById(vm.RentPointId);
            var bt = _bikeTypeService.GetBikeTypeById(vm.BikeTypeId);
            var bike = new Bike()
            {
                //BikeTypeId = vm.BikeTypeId,
                BikeType = bt,
                Image = bytes,
                Description = vm.Description,
                Model = vm.BikeModel,
                
            };
            bike.RentPoints.Add(rp);

            //var existingRentPoint = _rentPointService.GetRentPointById(vm.RentPointId);
            //existingRentPoint.Bikes = new List<Bike>(){bike};

            //_rentPointService.UpdateRentPoint(existingRentPoint);
            _bikeService.SaveBike(bike);
            _uof.Save();
        }
    }
}