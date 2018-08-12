using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentABike.DataProvider.Interfaces;
using RentABike.Logic.Interfaces;
using RentABike.Models;
using RentABike.Models.Constants;

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
