using System;
using ToDo.Domain.Exceptions;
using ToDo.Infra.Core;
using ToDo.Infra.Extensions;

namespace ToDo.Domain.Entities
{
    public class Genero : Entity
    {
        public string Nome { get; set; }

        private const int TAMANHO_NOME = 180;

        public Genero() { }

        public Genero(Guid aggregateId, string nome)
        {
            Validar(nome);

            AggregateId = aggregateId;
            Nome = nome.ToUpper();
            DataCriacao = DateTime.Now;
            Ativo = true;
        }

        public void Alterar(string nome)
        {
            Validar(nome);

            Nome = nome.ToUpper();
        }

        public void InativarOuAtivar()
        {
            Ativo = !Ativo;
        }
        private void Validar(string nome)
        {
            if (nome.IsNullOrWhiteSpaceAndTheSizeIsLargerThan(TAMANHO_NOME)) throw new CampoMaiorQuePermitidoException(nameof(nome), TAMANHO_NOME);
        }
    }
}