using System;
using ToDo.Infra.Core;

namespace ToDo.Domain.Entities.Usuario
{
    public class Usuario : Entity
    {
        public Guid PessoaAggregateId { get; private set; }
        public Guid InstituicaoDeEnsinoAggregateId { get; private set; }

        public virtual Pessoa.Pessoa Pessoa { get; protected set; }
        public virtual InstituicaoDeEnsino.InstituicaoDeEnsino InstituicaoDeEnsino { get; protected set; }

        public Usuario() { }

        public Usuario(Guid aggregateId, Guid pessoaAggregateId, Guid instituicaoDeEnsinoAggregateId)
        {
            AggregateId = aggregateId;
            PessoaAggregateId = pessoaAggregateId;
            InstituicaoDeEnsinoAggregateId = instituicaoDeEnsinoAggregateId;
            DataCriacao = DateTime.Now;
            Ativo = true;
        }

        public void InativarOuAtivar() => Ativo = !Ativo;
    }
}