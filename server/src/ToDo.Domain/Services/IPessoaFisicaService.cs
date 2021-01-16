using System;
using System.Threading.Tasks;
using ToDo.Domain.ValuesObjects;
using ToDo.Infra.Core;

namespace ToDo.Domain.Services
{
    public interface IPessoaFisicaService : IService
    {
        Task CriarAsync(Guid aggregateId, Cpf cpf, string nome);
        Task AlterarAsync(Guid aggregateId, Cpf cpf, string nome);
    }
}