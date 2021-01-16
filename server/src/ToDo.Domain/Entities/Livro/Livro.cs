using System;
using ToDo.Domain.Exceptions;
using ToDo.Infra.Core;
using ToDo.Infra.Extensions;

namespace ToDo.Domain.Entities.Livro
{
    public class Livro : Entity
    {
        public string Titulo { get; private set; }
        public string Sinopse { get; private set; }
        public int? Paginas { get; private set; }
        public string Capa { get; private set; }
        public bool Disponivel { get; private set; }
        public int AutorId { get; private set; }
        public virtual Autor Autor { get; protected set; }
        public int GeneroId { get; private set; }
        public virtual Genero Genero { get; protected set; }
        
        private const int TAMANHO_TITULO = 255;
        private const int TAMANHO_CAPA = 800;
        private const int TAMANHO_SINOPSE = 400;

        public Livro() { }
        
        public Livro(Guid aggregateId, int autorId, int generoId, string titulo, string capa, string sinopse, int? paginas = 0 )
        {
            Validar(titulo, capa, sinopse);

            AggregateId = aggregateId;
            Titulo = titulo;
            Sinopse = sinopse;
            Paginas = paginas;
            Capa = capa;
            AutorId = autorId;
            GeneroId = generoId;
            DataCriacao = DateTime.Now;
            Disponivel = true;
            Ativo = true;
        }

        public void Alterar(int autorId, int generoId, string titulo, string capa, string sinopse, int? paginas = 0)
        {
            Validar(titulo, capa, sinopse);

            Titulo = titulo;
            Sinopse = sinopse;
            Paginas = paginas;
            Capa = capa;
            AutorId = autorId;
            GeneroId = generoId;
        }

        public void InativarOuAtivar() => Ativo = !Ativo;

        public void Disponibilizar() => Disponivel = true;
        
        public void Indisponibilizar() => Disponivel = false;

        private void Validar(string titulo, string capa, string sinopse)
        {
           if(titulo.IsNullOrWhiteSpaceAndTheSizeIsLargerThan(TAMANHO_TITULO)) throw new CampoMaiorQuePermitidoException(nameof(titulo), TAMANHO_TITULO);
           if(capa.IsNullOrWhiteSpaceAndTheSizeIsLargerThan(TAMANHO_CAPA)) throw new CampoMaiorQuePermitidoException(nameof(capa), TAMANHO_CAPA);
           if(sinopse.IsNotNullOrWhiteSpace() && sinopse.IsNullOrWhiteSpaceAndTheSizeIsLargerThan(TAMANHO_SINOPSE)) throw new CampoMaiorQuePermitidoException(nameof(sinopse), TAMANHO_SINOPSE);
        }
    }
}