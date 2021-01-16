using System;
using System.Threading.Tasks;
using ToDo.Infra.Core;

namespace ToDo.Domain.Services
{
    public interface IUsuarioService : IService
    {
        Task CriarAsync(Guid aggregateId, Guid pessoaAggregateId, Guid instituicaoDeEnsinoAggregateId);
        Task InativarOuAtivarAsync(Guid aggregateId);
    }
}