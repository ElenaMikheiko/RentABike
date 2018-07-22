using System.Collections.Generic;
using RentABike.DataProvider.Interfaces;
using RentABike.Logic.Interfaces;
using RentABike.Models;
using RentABike.ViewModels;

namespace RentABike.Logic
{
    public class RentPointService : IRentPointService
    {
        private readonly IRepository<RentPoint> _rentPointRepository;

        public RentPointService(IRepository<RentPoint> rentPointRepository)
        {
            _rentPointRepository = rentPointRepository;
        }

        public IEnumerable<RentPoint> AllRentPoint()
        {
            return _rentPointRepository.GetAll();
        }

        public void AddRentPoint(RentPointViewModel viewModel)
        {
            var rentPoint = new RentPoint
            {
                Name = viewModel.Name,
                Address = viewModel.Address,
                Phone = viewModel.Phone
            };

            _rentPointRepository.Create(rentPoint);
        }
    }
}
