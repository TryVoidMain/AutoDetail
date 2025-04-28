using AutoDetail.Core.Interfaces;

namespace AutoDetail.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        Task AddAsync<TEntity>(TEntity entity) where TEntity : class, IDatabaseEntity;
        Task AddRangeAsync<TEntity>(IEnumerable<TEntity> entity) where TEntity : class, IDatabaseEntity;
        void Update<TEntity>(TEntity entity) where TEntity : class, IDatabaseEntity;
        void UpdateRange<TEntity>(IEnumerable<TEntity> entity) where TEntity : class, IDatabaseEntity;
        void Delete<TEntity>(TEntity entity) where TEntity : class, IDatabaseEntity;
        void DeleteRange<TEntity>(IEnumerable<TEntity> entity) where TEntity : class, IDatabaseEntity;
        Task SaveAsync();
        IGenericRepository<T> GetGenericRepository<T>() where T : class, IDatabaseEntity;
    }
}
