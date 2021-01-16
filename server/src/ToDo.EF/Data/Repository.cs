using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ToDo.Infra.Core;
using ToDo.Infra.Extensions;

namespace ToDo.EF.Data
{
    public class Repository : IRepository
    {
        private readonly ToDoContext _dbContext;

        public Repository(ToDoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task AddAsync<TEntity>(TEntity entity) where TEntity : Entity
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
        }

        public async Task<TEntity> GetByAsync<TEntity>(int id) where TEntity : Entity
        {
            var entity = _dbContext.Set<TEntity>().Local.SingleOrDefault(e => e.Id == id);
            return entity ?? await _dbContext.Set<TEntity>().SingleOrDefaultAsync(e => e.Id == id);
        }

        public async Task<TEntity> GetByAsync<TEntity>(Guid aggregateId) where TEntity : Entity
        {
            var entity = _dbContext.Set<TEntity>().Local.SingleOrDefault(e => e.AggregateId == aggregateId);
            return entity ?? await _dbContext.Set<TEntity>().SingleOrDefaultAsync(e => e.AggregateId == aggregateId);
        }

        public async Task<int> CountAsync<TEntity>(Expression<Func<TEntity, bool>> filter) where TEntity : Entity
        {
           return await _dbContext.Set<TEntity>().CountAsync(filter);
        }

        public virtual async Task DeleteAsync<T>(Guid aggregateId) where T : class
        {
            var entity = await _dbContext.Set<T>().FindAsync(aggregateId);
            if (entity.IsNotNull())
            {
                _dbContext.Remove(entity);
            }
        }

        public virtual async Task DeleteAsync<T>(int id) where T : class
        {
            var entity = await _dbContext.Set<T>().FindAsync(id);
            if (entity.IsNotNull())
            {
                _dbContext.Remove(entity);
            }
        }

        public async Task<bool> ExistAsync<TEntity>(Expression<Func<TEntity, bool>> filter) where TEntity : Entity
        {
            return await _dbContext.Set<TEntity>().AsNoTracking().AnyAsync(filter);
        } 
    }
}