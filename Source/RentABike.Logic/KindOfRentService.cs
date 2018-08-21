using System.Collections.Generic;
using System.Linq;
using RentABike.Common.Interfaces;
using RentABike.Logic.Interfaces;
using RentABike.Models;

namespace RentABike.Logic
{
    public class KindOfRentService : IKindOfRentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public KindOfRentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<KindOfRent> GetAllKindsOfRent()
        {
            return _unitOfWork.KindOfRentRepository.GetAll();
        }

        public KindOfRent GetKindOfRentByName(string kind)
        {
            return _unitOfWork.KindOfRentRepository.GetAllWhere(k => k.Kind.Equals(kind)).FirstOrDefault();
        }
    }
}
