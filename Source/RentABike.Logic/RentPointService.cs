using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentABike.DataProvider.Interfaces;
using RentABike.Logic.Interfaces;
using RentABike.Models;

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
    }
}
