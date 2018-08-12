using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using RentABike.Logic.Interfaces;
using RentABike.ViewModels;

namespace RentABike.Logic
{
    public class UserInfoRentPointService : IUserInfoAndRentPointService
    {
        public IRentPointService _rentPointService;

        public IUserInfoService _userInfoService;

        //private ApplicationUserManager _userManager;


        public UserInfoRentPointService(IRentPointService rentPointService, IUserInfoService userInfoService/*, ApplicationUserManager userManager*/)
        {
            _userInfoService = userInfoService;
            _rentPointService = rentPointService;
            //_userManager = userManager;
        }


        public void SaveUserInfoAndRentPoint(EditPersonalUserInfoViewModel vm)
        {
            var rp = _rentPointService.GetRentPointById(vm.RentPointId);
            var userInfo = _userInfoService.GetUserInfoByUserId(vm.UserId);
            rp.Sellers.Add(userInfo.User);
            _rentPointService.UpdateRentPoint(rp);
            _userInfoService.UpdateUserInfo(vm);

        }
    }
}
