using System;
using RentABike.DataProvider.Interfaces;
using RentABike.DataProvider.Repositories;
using RentABike.Models;

namespace RentABike.DataProvider
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RentABikeDbContext _dbContext;

        private bool _disposed;

        public UnitOfWork()
        {
            _dbContext = new RentABikeDbContext();
        }

        public GenericRepository<Bike> BikeRepository => new GenericRepository<Bike>(_dbContext);

        public GenericRepository<RentPoint> RentPointRepository => new GenericRepository<RentPoint>(_dbContext);

        public GenericRepository<BikeType> BikeTypeRepository => new GenericRepository<BikeType>(_dbContext);

        public GenericRepository<UserInfo> UserInfoRepository => new GenericRepository<UserInfo>(_dbContext);

        public GenericRepository<ApplicationUser> ApplicationUserRepository => new GenericRepository<ApplicationUser>(_dbContext);

        public GenericRepository<Order> OrderRepository => new GenericRepository<Order>(_dbContext);

        public GenericRepository<Status> StatusRepository => new GenericRepository<Status>(_dbContext);

        public GenericRepository<Tarriff> TarriffRepository => new GenericRepository<Tarriff>(_dbContext);


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing) _dbContext.Dispose();
                _disposed = true;
            }
        }
    }
}