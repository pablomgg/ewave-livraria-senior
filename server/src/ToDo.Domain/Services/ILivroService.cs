using System;
using System.Threading.Tasks;
using ToDo.Infra.Core;

namespace ToDo.Domain.Services
{
    public interface ILivroService : IService
    {
        Task CriarAsync(Guid aggregateId, Guid autorAggregateId, Guid generoAggregateId, string titulo, string capa, string sinopse, int? paginas);
        Task AlterarAsync(Guid aggregateId, Guid autorAggregateId, Guid generoAggregateId, string titulo, string capa, string sinopse, int? paginas);
        Task InativarOuAtivarAsync(Guid aggregateId);
    }
}