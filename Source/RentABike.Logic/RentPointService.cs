using System.Collections.Generic;
using RentABike.DataProvider;
using RentABike.DataProvider.Interfaces;
using RentABike.Logic.Interfaces;
using RentABike.Models;
using RentABike.ViewModels;

namespace RentABike.Logic
{
    public class RentPointService : IRentPointService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RentPointService(IUnitOfWork uof)
        {
            _unitOfWork = uof;
        }

        public IEnumerable<RentPoint> AllRentPoint()
        {
            return _unitOfWork.RentPointRepository.GetAll();
        }

        public void AddRentPoint(RentPointViewModel viewModel)
        {
            var rentPoint = new RentPoint
            {
                Name = viewModel.Name,
                Address = viewModel.Address,
                Phone = viewModel.Phone
            };

            _unitOfWork.RentPointRepository.Create(rentPoint);
            _unitOfWork.Save();
        }

        public RentPoint GetRentPointById(int id)
        {
            return _unitOfWork.RentPointRepository.FindById(id);
        }

        public void UpdateRentPoint(RentPoint rentPoint)
        {
            _unitOfWork.RentPointRepository.Update(rentPoint);
        }
    }
}
