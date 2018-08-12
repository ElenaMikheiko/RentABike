using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using RentABike.DataProvider.Interfaces;
using RentABike.Logic.Interfaces;
using RentABike.Models;
using RentABike.ViewModels;

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

        public void UpdateUserInfo(EditPersonalUserInfoViewModel vm)
        {
            var userInfo = GetUserInfoByUserId(vm.UserId);
            userInfo.Email = vm.Email;
            userInfo.Name = vm.Name;
            userInfo.Surname = vm.Surname;
            userInfo.Patronymic = vm.Patronymic;
            userInfo.Phone = vm.Phone;
            if (vm.Base64Image != null)
            {
                var base64 = vm.Base64Image.Contains(',') ? vm.Base64Image.Split(',')[1].Trim() : vm.Base64Image;
                var imgBytes = Convert.FromBase64String(base64);

                userInfo.Photo = imgBytes;

            }

            _unitOfWork.UserInfoRepository.Update(userInfo);
            _unitOfWork.Save();
        }

        public IEnumerable<UserInfo> AllUserInfos()
        {
            return _unitOfWork.UserInfoRepository.GetAll();
        }
    }
}