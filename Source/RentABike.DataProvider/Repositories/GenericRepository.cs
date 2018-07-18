using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using RentABike.DataProvider.Interfaces;

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

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public TEntity FindById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Create(TEntity item)
        {
            _dbSet.Add(item);
            _context.SaveChanges();
        }

        public void Update(TEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Remove(TEntity item)
        {
            _dbSet.Remove(item);
            _context.SaveChanges();
        }
    }
}