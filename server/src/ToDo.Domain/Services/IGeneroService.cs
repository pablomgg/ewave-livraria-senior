using System;
using System.Threading.Tasks;
using ToDo.Infra.Core;

namespace ToDo.Domain.Services
{
    public interface IGeneroService : IService
    {
        Task CriarAsync(Guid aggregateId, string nome);
        Task AlterarAsync(Guid aggregateId, string nome);
        Task InativarOuAtivarAsync(Guid aggregateId);
    }
}