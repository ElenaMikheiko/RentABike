using System.Collections.Generic;

namespace RentABike.DataProvider.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Create(TEntity item);

        TEntity FindById(int id);

        IEnumerable<TEntity> GetAll();

        void Remove(TEntity item);

        void Update(TEntity item);
    }
}