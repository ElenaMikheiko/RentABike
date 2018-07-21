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
    public class BikeTypeService : IBikeTypeService
    {
        private readonly IRepository<BikeType> _bikeTypeRepository;

        public BikeTypeService(IRepository<BikeType> bikeTypeRepository)
        {
            _bikeTypeRepository = bikeTypeRepository;
        }

        public IEnumerable<BikeType> AllBikeTypes()
        {
            return _bikeTypeRepository.GetAll();
        }
    }
}
