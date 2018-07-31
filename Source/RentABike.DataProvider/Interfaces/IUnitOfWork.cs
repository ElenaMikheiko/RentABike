using System;
using RentABike.DataProvider.Repositories;
using RentABike.Models;

namespace RentABike.DataProvider.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        GenericRepository<Bike> BikeRepository { get; }

        GenericRepository<RentPoint> RentPointRepository { get; }

        GenericRepository<BikeType> BikeTypeRepository { get; }

        void Save();
    }
}