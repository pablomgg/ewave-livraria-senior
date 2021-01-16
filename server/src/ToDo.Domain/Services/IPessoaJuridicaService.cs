using System;
using System.Threading.Tasks;
using ToDo.Domain.ValuesObjects;
using ToDo.Infra.Core;

namespace ToDo.Domain.Services
{
    public interface IPessoaJuridicaService : IService
    {
        Task CriarAsync(Guid aggregateId, Cnpj cnpj, string razaoSocial, string nomeFantasia);
        Task AlterarAsync(Guid aggregateId, Cnpj cnpj, string razaoSocial, string nomeFantasia);
    }
}