using AutoDetail.Core.Interfaces;
using System.Linq.Expressions;

namespace AutoDetail.DAL.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class, IDatabaseEntity
    {
        Task<TEntity> GetByIdAsync(Guid id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        IQueryable<TEntity> GetWhere(Expression<Func<TEntity, bool>> predicate);
        Task<List<TEntity>> GetWhereToListAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);
        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entity);
    }
}
