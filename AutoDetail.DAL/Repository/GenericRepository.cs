using AutoDetail.Core.Interfaces;
using AutoDetail.DAL.DatabaseContext;
using AutoDetail.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AutoDetail.DAL.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IDatabaseEntity
    {
        private readonly AutoDetailDbContext _dbContext;
        protected readonly DbSet<TEntity> Entities;

        public GenericRepository(AutoDetailDbContext dbContext)
        {
            ArgumentNullException.ThrowIfNull(dbContext);

            _dbContext = dbContext;
            Entities = _dbContext.Set<TEntity>();
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await Entities.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await GetAllQueryCommon().ToListAsync();
        }

        public async Task AddAsync(TEntity entity)
        {
            await Entities.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await Entities.AddRangeAsync(entities);
        }

        public void Update(TEntity entity)
        {
            Entities.Update(entity);
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            Entities.UpdateRange(entities);
        }

        public void Delete(TEntity entity)
        {
            Entities.Remove(entity);
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            Entities.RemoveRange(entities);
        }

        public IQueryable<TEntity> GetWhere(Expression<Func<TEntity, bool>> predicate)
        {
            return GetWhereCommon(predicate);
        }

        public async Task<List<TEntity>> GetWhereToListAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await GetWhereCommon(predicate).ToListAsync();
        }

        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Entities.FirstOrDefaultAsync(predicate);
        }

        private IQueryable<TEntity> GetAllQueryCommon()
        {
            return Entities.AsNoTracking().AsQueryable();
        }

        private IQueryable<TEntity> GetWhereCommon(Expression<Func<TEntity, bool>> predicate)
        {
            return Entities.AsNoTracking().Where(predicate).AsQueryable();
        }
    }
}
