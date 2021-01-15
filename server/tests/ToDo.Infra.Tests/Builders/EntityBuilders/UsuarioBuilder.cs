using System;
using ToDo.Domain.Entities.Usuario;
using ToDo.Infra.Tests.Core;

namespace ToDo.Infra.Tests.Builders.EntityBuilders
{
    public class UsuarioBuilder : EntityBuilderBase<UsuarioBuilder, Usuario>
    {
        public Guid AggregateId { get; private set; }
        public Guid PessoaAggregateId { get; private set; }
        public Guid InstituicaoDeEnsinoAggregateId { get; private set; }

        public override UsuarioBuilder Create()
        {
            AggregateId = Faker.Random.Guid();
            PessoaAggregateId = Faker.Random.Guid();
            InstituicaoDeEnsinoAggregateId = Faker.Random.Guid();

            return this;
        }

        public override Usuario Build() => new Usuario(AggregateId, PessoaAggregateId, InstituicaoDeEnsinoAggregateId);
    }
}