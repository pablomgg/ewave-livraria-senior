using System;
using System.Threading.Tasks;
using ToDo.Domain.Services;
using ToDo.Infra.Core;

namespace ToDo.Services
{
    public class DomainService : IDomainService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IServiceProvider _provider;

        public DomainService(IUnitOfWork unitOfWork, IServiceProvider provider)
        {
            _unitOfWork = unitOfWork;
            _provider = provider;
        }

        public IDomainService NewGuid(out Guid aggregateId)
        {
            aggregateId = GuidGenerator.Generate;
            return this;
        }

        public IDomainService Execute<TService>(Func<TService, Task> srv) where TService : IService
        {
            var service = _provider.GetService(typeof(TService));
            srv((TService)service).GetAwaiter().GetResult();
            return this;
        }

        public IDomainService Execute<TService>(Action<TService> srv) where TService : IService
        {
            var service = _provider.GetService(typeof(TService));
            srv((TService)service);

            return this;
        }

        public async Task CommitAsync()
        {
            await _unitOfWork.CommitAsync();
        }
    }
}