using System;
using RentABike.DataProvider.Interfaces;
using RentABike.Models;

namespace RentABike.Common.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Bike> BikeRepository { get; }

        IRepository<RentPoint> RentPointRepository { get; }

        IRepository<BikeType> BikeTypeRepository { get; }

        IRepository<UserInfo> UserInfoRepository { get; }

        IRepository<ApplicationUser> ApplicationUserRepository { get; }

        IRepository<Order> OrderRepository { get; }

        IRepository<Status> StatusRepository { get; }

        IRepository<Tarriff> TarriffRepository { get; }

        IRepository<KindOfRent> KindOfRentRepository { get; }


        void Save();
    }
}