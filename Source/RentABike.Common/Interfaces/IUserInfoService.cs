using System.Collections.Generic;
using RentABike.Models;
using RentABike.ViewModels;

namespace RentABike.Common.Interfaces
{
    public interface IUserInfoService
    {
        void CreateUserInfo(UserInfo userInfo);

        UserInfo GetUserInfoByUserId(string userId);

        void UpdateUserInfo(EditPersonalUserInfoViewModel vm);

        IEnumerable<UserInfo> AllUserInfos();

        void DeleteUserInfo(string userId);
    }
}