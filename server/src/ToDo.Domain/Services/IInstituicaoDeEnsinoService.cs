using System;
using System.Threading.Tasks;
using ToDo.Infra.Core;

namespace ToDo.Domain.Services
{
    public interface IInstituicaoDeEnsinoService : IService
    {
        Task CriarAsync(Guid aggregateId, Guid pessoaAggregateId);
        Task InativarOuAtivarAsync(Guid aggregateId);
    }
}