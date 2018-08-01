using RentABike.Models;

namespace RentABike.Logic.Interfaces
{
    public interface IUserInfoService
    {
        void CreateUserInfo(UserInfo userInfo);

        UserInfo GetUserInfoByUserId(string userId);
    }
}