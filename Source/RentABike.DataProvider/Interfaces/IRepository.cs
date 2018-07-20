using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RentABike.DataProvider.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Create(TEntity item);

        TEntity FindById(int id);

        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> GetAllWhere(Func<TEntity, bool> predicate);

        IEnumerable<TEntity> GetWithInclude(params Expression<Func<TEntity, object>>[] includeProperties);

        IEnumerable<TEntity> GetWithInclude(Func<TEntity, bool> predicate, 
                                            params Expression<Func<TEntity, object>>[] includeProperties);

        void Remove(TEntity item);

        void Update(TEntity item);
    }
}