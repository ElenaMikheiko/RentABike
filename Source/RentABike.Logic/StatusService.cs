using System.Linq;
using RentABike.Common.Interfaces;
using RentABike.Logic.Interfaces;
using RentABike.Models;

namespace RentABike.Logic
{
    public class StatusService : IStatusService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StatusService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Status GetStatusByStatusName(string statusName)
        {
            return _unitOfWork.StatusRepository.GetAllWhere(x => x.StatusName == statusName).FirstOrDefault();
        }
    }
}
