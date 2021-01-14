using System;
using System.Threading.Tasks;
using ToDo.Domain.Entities.Pessoa;
using ToDo.Domain.Exceptions;
using ToDo.Domain.Services;
using ToDo.Domain.ValuesObjects;
using ToDo.Infra.Core;
using ToDo.Infra.Extensions;

namespace ToDo.Services
{
    public class PessoaJuridicaService : IPessoaJuridicaService
    {
        private readonly IRepository _repository;

        public PessoaJuridicaService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task CriarAsync(Guid aggregateId, Cnpj cnpj, string razaoSocial, string nomeFantasia)
        {
            Validar(razaoSocial);

            var existeCnpjCadastrado = await _repository.ExistAsync<Pessoa>(x => x.PessoaJuridica.Cnpj == cnpj);
            if (existeCnpjCadastrado) throw new PessoaCnpjJaExisteException();

            await _repository.AddAsync(new Pessoa(aggregateId, cnpj, razaoSocial, nomeFantasia));
        }

        public async Task AlterarAsync(Guid aggregateId, Cnpj cnpj, string razaoSocial, string nomeFantasia)
        {
            Validar(razaoSocial);

            var existeCnpjCadastrado = await _repository.ExistAsync<Pessoa>(x => x.AggregateId != aggregateId && x.PessoaJuridica.Cnpj == cnpj);
            if (existeCnpjCadastrado) throw new PessoaCnpjJaExisteException();

            var pessoa = await _repository.GetByAsync<Pessoa>(aggregateId);
            if (pessoa.IsNull()) throw new PessoaNaoEncontradaException();

            pessoa.AlterarPessoaJuridica(cnpj, razaoSocial, nomeFantasia);
        }

        private void Validar(string razaoSocial)
        {
            if (razaoSocial.IsNullOrWhiteSpace()) throw new CampoNuloOuVazioOuMenorOuIgualZeroException(nameof(razaoSocial), razaoSocial.GetType());
        }
    }
}