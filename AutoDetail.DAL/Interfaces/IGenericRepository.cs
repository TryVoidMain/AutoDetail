using AutoDetail.Core.Interfaces;

namespace AutoDetail.DAL.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class, IDatabaseEntity
    {
        Task<TEntity> GetByIdAsync(Guid id);
        Task<IEnumerable<TEntity>> GetAll();
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);
        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entity);
    }
}
