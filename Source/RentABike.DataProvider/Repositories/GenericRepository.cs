using RentABike.DataProvider.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace RentABike.DataProvider.Repositories
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly RentABikeDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(RentABikeDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public virtual IEnumerable<TEntity> GetWithInclude(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return Include(includeProperties).ToList();
        }

        public virtual IEnumerable<TEntity> GetWithInclude(Func<TEntity, bool> predicate,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = Include(includeProperties);
            return query.Where(predicate).ToList();
        }

        public virtual TEntity FindById(int id)
        {
            return _dbSet.Find(id);
        }

        public virtual void Create(TEntity item)
        {
            _dbSet.Add(item);
        }

        public virtual void Update(TEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public void Remove(TEntity item)
        {
            _dbSet.Remove(item);
        }

        public IEnumerable<TEntity> GetAllWhere(Func<TEntity, bool> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }

        private IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _dbSet;
            return includeProperties
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

    }
}