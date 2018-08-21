using RentABike.Common.Interfaces;
using RentABike.ViewModels;

namespace RentABike.Logic
{
    public class UserInfoRentPointService : IUserInfoAndRentPointService
    {
        private IRentPointService _rentPointService;

        private IUserInfoService _userInfoService;

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
