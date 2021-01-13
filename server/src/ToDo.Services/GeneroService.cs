using System;
using System.Threading.Tasks;
using ToDo.Domain.Entities;
using ToDo.Domain.Exceptions;
using ToDo.Domain.Services;
using ToDo.Infra.Core;
using ToDo.Infra.Extensions;

namespace ToDo.Services
{
    public class GeneroService : IGeneroService
    {
        private readonly IRepository _repository;

        public GeneroService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task AdicionarAsync(Guid aggregateId, string nome)
        {
            Validar(aggregateId, nome);

            var generoJaExiste = await _repository.ExistAsync<Genero>(x => x.Nome == nome);
            if (generoJaExiste) throw new GeneroJaExisteException();

            await _repository.AddAsync(new Genero(aggregateId, nome));
        }

        public async Task AlterarAsync(Guid aggregateId, string nome)
        {
            Validar(aggregateId, nome);

            var genero = await _repository.GetByAsync<Genero>(aggregateId);
            if (genero.IsNull()) throw new GeneroNaoEncontradoException();

            var generoJaExiste = await _repository.ExistAsync<Genero>(x => x.Nome == nome);
            if (generoJaExiste) throw new GeneroJaExisteException();

            genero.Alterar(nome);
        }

        public async Task InativarOuAtivarAsync(Guid aggregateId)
        {
            var genero = await _repository.GetByAsync<Genero>(aggregateId);
            if (genero.IsNull()) throw new GeneroNaoEncontradoException();

            genero.InativarOuAtivar();
        }

        private void Validar(Guid aggregateId, string nome)
        {
            if (aggregateId.IsEmpty()) throw new CampoNuloOuVazioOuMenorOuIgualZeroException(nameof(aggregateId), aggregateId.GetType());
            if (nome.IsNullOrWhiteSpace()) throw new CampoNuloOuVazioOuMenorOuIgualZeroException(nameof(nome), nome.GetType());
        }
    }
}