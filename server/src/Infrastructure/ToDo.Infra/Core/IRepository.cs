using System;
using System.Threading.Tasks;

namespace ToDo.Infra.Core
{
    public interface IRepository
    {
        Task AddAsync<TEntity>(TEntity entity) where TEntity : Entity;
        Task<TEntity> GetByAsync<TEntity>(int id) where TEntity : Entity;
        Task<TEntity> GetByAsync<TEntity>(Guid aggregateId) where TEntity : Entity;
        Task DeleteAsync<T>(Guid aggregateId) where T : class;
        Task DeleteAsync<T>(int id) where T : class;
    }
}