using System;
using System.Threading.Tasks;
using ToDo.Infra.Core;

namespace ToDo.Domain.Services
{
    public interface IAutorService : IService
    {
        Task CriarAsync(Guid aggregateId, string nome);
        Task AlterarAsync(Guid aggregateId, string nome);
        Task InativarOuAtivarAsync(Guid aggregateId);
    }
}