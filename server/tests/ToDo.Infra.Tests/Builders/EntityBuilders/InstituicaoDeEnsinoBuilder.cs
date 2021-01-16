using System;
using ToDo.Domain.Entities.InstituicaoDeEnsino;
using ToDo.Infra.Tests.Core;

namespace ToDo.Infra.Tests.Builders.EntityBuilders
{
    public class InstituicaoDeEnsinoBuilder : EntityBuilderBase<InstituicaoDeEnsinoBuilder, InstituicaoDeEnsino>
    {
        public Guid AggregateId { get; private set; }
        public Guid PessoaAggregateId { get; private set; }

        public override InstituicaoDeEnsinoBuilder Create()
        {
            AggregateId = Faker.Random.Guid();
            PessoaAggregateId = Faker.Random.Guid();

            return this;
        }

        public override InstituicaoDeEnsino Build() => new InstituicaoDeEnsino(AggregateId, PessoaAggregateId);
    }
}