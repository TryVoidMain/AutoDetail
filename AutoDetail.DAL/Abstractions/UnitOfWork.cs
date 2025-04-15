using AutoDetail.DAL.DatabaseContext;
using AutoDetail.DAL.Interfaces;
using Microsoft.Extensions.Logging;

namespace AutoDetail.DAL.Abstractions
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AutoDetailDbContext _dbContext;
        private readonly ILogger<UnitOfWork> _logger;

        public UnitOfWork(
            AutoDetailDbContext dbContext,
            ILogger<UnitOfWork> logger)
        {
            ArgumentNullException.ThrowIfNull(dbContext);
            ArgumentNullException.ThrowIfNull(logger);

            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task SaveAsync()
        {
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }
        }

        public async Task AddAsync<TEntity>(TEntity entity) where TEntity : class, IDatabaseEntity
        {
            try
            {
                await _dbContext.AddAsync(entity);
            }
            catch (Exception ex)
            {

            }
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : class, IDatabaseEntity
        {
            try
            {
                _dbContext.Remove(entity);
            }
            catch (Exception ex)
            {

            }
        }

        public async Task AddRangeAsync<TEntity>(IEnumerable<TEntity> entity) where TEntity : class, IDatabaseEntity
        {
            try
            {
                await _dbContext.AddRangeAsync(entity);
            }
            catch (Exception ex)
            {

            }
        }

        public void UpdateRange<TEntity>(IEnumerable<TEntity> entity) where TEntity : class, IDatabaseEntity
        {
            try
            {
                _dbContext.UpdateRange(entity);
            }
            catch (Exception ex)
            {

            }
        }

        public void Update<TEntity>(TEntity entity) where TEntity : class, IDatabaseEntity
        {
            try
            {
                _dbContext.Update(entity);
            }
            catch (Exception ex)
            {

            }
        }

        public void DeleteRange<TEntity>(IEnumerable<TEntity> entity) where TEntity : class, IDatabaseEntity
        {
            try
            {
                _dbContext.RemoveRange(entity);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
