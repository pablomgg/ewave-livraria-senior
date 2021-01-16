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
    public class PessoaFisicaService : IPessoaFisicaService
    {
        private readonly IRepository _repository;

        public PessoaFisicaService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task CriarAsync(Guid aggregateId, Cpf cpf, string nome)
        {
            Validar(nome);

            var existeCpfCadastrado = await _repository.ExistAsync<Pessoa>(x => x.PessoaFisica.Cpf == cpf);
            if(existeCpfCadastrado) throw new PessoaCpfJaExisteException();

            await _repository.AddAsync(new Pessoa(aggregateId, cpf, nome));
        }

        public async Task AlterarAsync(Guid aggregateId, Cpf cpf, string nome)
        {
            Validar(nome);

            var existeCpfCadastrado = await _repository.ExistAsync<Pessoa>(x => x.AggregateId != aggregateId && x.PessoaFisica.Cpf == cpf);
            if (existeCpfCadastrado) throw new PessoaCpfJaExisteException();

            var pessoa = await _repository.GetByAsync<Pessoa>(aggregateId);
            if (pessoa.IsNull()) throw new PessoaNaoEncontradaException();

            pessoa.AlterarPessoaFisica(cpf, nome);
        }

        private void Validar(string nome)
        {
            if (nome.IsNullOrWhiteSpace()) throw new CampoNuloOuVazioOuMenorOuIgualZeroException(nameof(nome), nome.GetType());
        }
    }
}