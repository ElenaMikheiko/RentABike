using System.Linq;
using System.Security.Cryptography.X509Certificates;
using RentABike.DataProvider.Interfaces;
using RentABike.Logic.Interfaces;
using RentABike.Models;

namespace RentABike.Logic
{
    public class UserInfoService : IUserInfoService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserInfoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreateUserInfo(UserInfo userInfo)
        {
            _unitOfWork.UserInfoRepository.Create(userInfo);
            _unitOfWork.Save();
        }

        public UserInfo GetUserInfoByUserId(string userId)
        {
            return _unitOfWork.UserInfoRepository.GetAllWhere(u=>u.Id == userId).FirstOrDefault();
        }
    }
}