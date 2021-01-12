using System;
using System.Threading.Tasks;
using ToDo.Infra.Core;

namespace ToDo.Domain.Services
{
    public interface IDomainService
    {
        IDomainService NewGuid(out Guid aggregateId);
        IDomainService Execute<TService>(Func<TService, Task> srv) where TService : IService;
        Task CommitAsync();
    }
}