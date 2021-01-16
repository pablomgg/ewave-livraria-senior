using System;
using System.Threading.Tasks;
using ToDo.Domain.Entities;
using ToDo.Domain.Entities.Livro;
using ToDo.Domain.Exceptions;
using ToDo.Domain.Services;
using ToDo.Infra.Core;
using ToDo.Infra.Extensions;

namespace ToDo.Services
{
    public class AutorService : IAutorService
    {
        private readonly IRepository _repository;

        public AutorService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task CriarAsync(Guid aggregateId, string nome)
        {
            Validar(aggregateId, nome);

            var autorJaExiste = await _repository.ExistAsync<Autor>(x => x.Nome == nome);
            if (autorJaExiste) throw new AutorJaExisteException();

            await _repository.AddAsync(new Autor(aggregateId, nome));
        }

        public async Task AlterarAsync(Guid aggregateId, string nome)
        {
            Validar(aggregateId, nome);

            var autor = await _repository.GetByAsync<Autor>(aggregateId);
            if (autor.IsNull()) throw new AutorNaoEncontradoException();

            var autorJaExiste = await _repository.ExistAsync<Autor>(x => x.Nome == nome);
            if (autorJaExiste) throw new AutorJaExisteException();

            autor.Alterar(nome);
        }

        public async Task InativarOuAtivarAsync(Guid aggregateId)
        {
            var autor = await _repository.GetByAsync<Autor>(aggregateId);
            if (autor.IsNull()) throw new AutorNaoEncontradoException();

            autor.InativarOuAtivar();
        }

        private void Validar(Guid aggregateId, string nome)
        {
            if (aggregateId.IsEmpty()) throw new CampoNuloOuVazioOuMenorOuIgualZeroException(nameof(aggregateId), aggregateId.GetType());
            if (nome.IsNullOrWhiteSpace()) throw new CampoNuloOuVazioOuMenorOuIgualZeroException(nameof(nome), nome.GetType());
        }
    }
}