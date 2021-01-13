using System;
using System.Threading.Tasks;
using ToDo.Infra.Core;

namespace ToDo.Domain.Services
{
    public interface IGeneroService : IService
    {
        Task AdicionarAsync(Guid aggregateId, string nome);
        Task AlterarAsync(Guid aggregateId, string nome);
        Task InativarOuAtivarAsync(Guid aggregateId);
    }
}