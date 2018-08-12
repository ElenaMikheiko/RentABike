using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentABike.ViewModels;

namespace RentABike.Logic.Interfaces
{
    public interface IUserInfoAndRentPointService
    {
        void SaveUserInfoAndRentPoint(EditPersonalUserInfoViewModel vm);
    }
}
