using AutoDetail.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AutoDetail.DAL.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IDatabaseEntity
    {
        protected readonly DbSet<TEntity> Entities;

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await Entities.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
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
    }
}
