using RentABike.ViewModels;

namespace RentABike.Common.Interfaces
{
    public interface IUserInfoAndRentPointService
    {
        void SaveUserInfoAndRentPoint(EditPersonalUserInfoViewModel vm);
    }
}
