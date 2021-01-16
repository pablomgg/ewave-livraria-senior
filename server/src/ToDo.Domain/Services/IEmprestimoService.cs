using System;
using System.Threading.Tasks;
using ToDo.Infra.Core;

namespace ToDo.Domain.Services
{
    public interface IEmprestimoService : IService
    {
        Task CriarAsync(Guid aggregateId, Guid usuarioAggregateId, Guid livroAggregateId, DateTime dataEmprestimo);
        Task DevolverAsync(Guid aggregateId, DateTime dataDevolucao);
    }
}