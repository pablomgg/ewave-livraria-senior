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
    public class LivroService : ILivroService
    {
        private readonly IRepository _repository;

        public LivroService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task CriarAsync(Guid aggregateId, Guid autorAggregateId, Guid generoAggregateId, string titulo, string capa, string sinopse, int? paginas)
        {
            Validar(autorAggregateId, generoAggregateId, titulo, capa);

            var autor = await _repository.GetByAsync<Autor>(autorAggregateId);
            if (autor.IsNull()) throw new AutorNaoEncontradoException();

            var genero = await _repository.GetByAsync<Genero>(generoAggregateId);
            if (genero.IsNull()) throw new GeneroNaoEncontradoException();

            var existeLivroMesmoTituloMesmoAutor = await _repository.ExistAsync<Livro>(x => x.Titulo == titulo && x.AutorId == autor.Id);
            if(existeLivroMesmoTituloMesmoAutor) throw new LivroComTituloJaExistenteParaAutorSelecionadoException();

            await _repository.AddAsync<Livro>(new Livro(aggregateId, autor.Id, genero.Id, titulo, capa, sinopse, paginas));
        }

        public async Task AlterarAsync(Guid aggregateId, Guid autorAggregateId, Guid generoAggregateId, string titulo, string capa, string sinopse, int? paginas)
        {
            Validar(autorAggregateId, generoAggregateId, titulo, capa);

            var autor = await _repository.GetByAsync<Autor>(autorAggregateId);
            if (autor.IsNull()) throw new AutorNaoEncontradoException();

            var genero = await _repository.GetByAsync<Genero>(generoAggregateId);
            if (genero.IsNull()) throw new GeneroNaoEncontradoException();

            var livro = await _repository.GetByAsync<Livro>(aggregateId);
            if (livro.IsNull()) throw new LivroNaoEncontradoException();

            var existeLivroMesmoTituloMesmoAutor = await _repository.ExistAsync<Livro>(x => x.Titulo == titulo && x.AutorId == autor.Id);
            if (existeLivroMesmoTituloMesmoAutor) throw new LivroComTituloJaExistenteParaAutorSelecionadoException();

            livro.Alterar(autor.Id, genero.Id, titulo, capa, sinopse, paginas);
        }

        public async Task InativarOuAtivarAsync(Guid aggregateId)
        {
            var livro = await _repository.GetByAsync<Livro>(aggregateId);
            if (livro.IsNull()) throw new LivroNaoEncontradoException();

            livro.InativarOuAtivar();
        }

        private void Validar(Guid autorAggregateId, Guid generoAggregateId, string titulo, string capa)
        {
            if (autorAggregateId.IsEmpty()) throw new CampoNuloOuVazioOuMenorOuIgualZeroException(nameof(autorAggregateId), autorAggregateId.GetType());
            if (generoAggregateId.IsEmpty()) throw new CampoNuloOuVazioOuMenorOuIgualZeroException(nameof(generoAggregateId), generoAggregateId.GetType());
            if (titulo.IsNullOrWhiteSpace()) throw new CampoNuloOuVazioOuMenorOuIgualZeroException(nameof(titulo), titulo.GetType());
            if (capa.IsNullOrWhiteSpace()) throw new CampoNuloOuVazioOuMenorOuIgualZeroException(nameof(capa), capa.GetType());
        }
    }
}