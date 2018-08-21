using System;
using RentABike.Common.Interfaces;
using RentABike.DataProvider.Interfaces;
using RentABike.DataProvider.Repositories;
using RentABike.Models;

namespace RentABike.DataProvider
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RentABikeDbContext _dbContext;

        private bool _disposed;

        public UnitOfWork(RentABikeDbContext db)
        {
            _dbContext = db;
        }

        public IRepository<Bike> BikeRepository => new GenericRepository<Bike>(_dbContext);

        public IRepository<RentPoint> RentPointRepository => new GenericRepository<RentPoint>(_dbContext);

        public IRepository<BikeType> BikeTypeRepository => new GenericRepository<BikeType>(_dbContext);

        public IRepository<UserInfo> UserInfoRepository => new GenericRepository<UserInfo>(_dbContext);

        public IRepository<ApplicationUser> ApplicationUserRepository => new GenericRepository<ApplicationUser>(_dbContext);

        public IRepository<Order> OrderRepository => new GenericRepository<Order>(_dbContext);

        public IRepository<Status> StatusRepository => new GenericRepository<Status>(_dbContext);

        public IRepository<Tarriff> TarriffRepository => new GenericRepository<Tarriff>(_dbContext);

        public IRepository<KindOfRent> KindOfRentRepository => new GenericRepository<KindOfRent>(_dbContext);

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