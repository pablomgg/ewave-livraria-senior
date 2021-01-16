using System;
using System.Threading.Tasks;
using ToDo.Infra.Core;

namespace ToDo.Domain.Services
{
    public interface IPessoaService : IService
    {
        Task CriarEnderecoAsync(Guid aggregateId, string cep, string bairro, string logradouro, int cidadeId, string numero, string complemento);
        Task AlterarEnderecoAsync(Guid aggregateId, string cep, string bairro, string logradouro, int cidadeId, string numero, string complemento);
        Task AdicionarTelefoneAsync(Guid aggregateId, string numero, int tipoId);
        Task AlterarTelefoneAsync(Guid aggregateId, int id, string numero, int tipoId);
        Task AdicionarEmailAsync(Guid aggregateId, string endereco, int tipoId);
        Task AlterarEmailAsync(Guid aggregateId, int id, string endereco, int tipoId);
    }
}