using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private RepositoryContext _context;

        public BaseRepository(RepositoryContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(TEntity entity) => await _context.AddAsync(entity);

        public void Delete(TEntity entity) => _context.Remove(entity);

        public IQueryable<TEntity> GetAll(bool trackChanges) =>
            (trackChanges ? _context.Set<TEntity>() :
                            _context.Set<TEntity>().AsNoTracking());

        public IQueryable<TEntity> GetByCondition(Expression<Func<TEntity, bool>> expression, bool trackChanges) =>
            (trackChanges ? _context.Set<TEntity>().Where(expression) :
                            _context.Set<TEntity>().Where(expression).AsNoTracking());

        public void Update(TEntity entity) => _context.Update(entity);
    }
}
