using AutoDetail.DAL.DatabaseContext;
using AutoDetail.DAL.Helpers.Messages;
using AutoDetail.DAL.Interfaces;
using AutoDetail.DAL.Repository;
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
                _logger.LogError(ex, UnitOfWorkMessageHelper.SAVE_ASYNC_ERROR_MESSAGE);
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
                _logger.LogError(ex, UnitOfWorkMessageHelper.ADD_ASYNC_ERROR_MESSAGE);
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
                _logger.LogError(ex, UnitOfWorkMessageHelper.ADD_RANGE_ASYNC_ERROR_MESSAGE);
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
                _logger.LogError(ex, UnitOfWorkMessageHelper.UPDATE_ERROR_MESSAGE);
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
                _logger.LogError(ex, UnitOfWorkMessageHelper.UPDATE_RANGE_ERROR_MESSAGE);
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
                _logger.LogError(ex, UnitOfWorkMessageHelper.DELETE_ERROR_MESSAGE);
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
                _logger.LogError(ex, UnitOfWorkMessageHelper.DELETE_RANGE_ERROR_MESSAGE);
            }
        }

        private IGenericRepository<T> GetGenericRepository<T>() where T : class, IDatabaseEntity
        {
            return new GenericRepository<T>(_dbContext);
        }
    }
}
