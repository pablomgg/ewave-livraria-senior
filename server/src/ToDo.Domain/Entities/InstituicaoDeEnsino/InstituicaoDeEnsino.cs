using System;
using ToDo.Infra.Core;

namespace ToDo.Domain.Entities.InstituicaoDeEnsino
{
    public class InstituicaoDeEnsino : Entity
    {
        public Guid PessoaAggregateId { get; private set; }
        public virtual Pessoa.Pessoa Pessoa { get; protected set; }

        public InstituicaoDeEnsino() { }

        public InstituicaoDeEnsino(Guid aggregateId, Guid pessoaAggregateId)
        {
            AggregateId = aggregateId;
            PessoaAggregateId = pessoaAggregateId;
            DataCriacao = DateTime.Now;
            Ativo = true;
        }

        public void InativarOuAtivar() => Ativo = !Ativo;
    }
}