using System;
using ToDo.Domain.Entities.Pessoa;
using ToDo.Domain.Enums;
using ToDo.Infra.Tests.Core;

namespace ToDo.Infra.Tests.Builders.EntityBuilders
{
    public class PessoaBuilder : EntityBuilderBase<PessoaBuilder, Pessoa>
    {
        public Guid AggregateId { get; private set; }
        public int TipoId { get; private set; }

        public PessoaFisicaBuilder PessoaFisica { get; set; }
        public PessoaJuridicaBuilder PessoaJuridica { get; set; } 

        public override PessoaBuilder Create()
        {
            AggregateId = Faker.Random.Guid();
            TipoId = Faker.Random.Number(1, 2);
            PessoaFisica = new PessoaFisicaBuilder().Create();
            PessoaJuridica = new PessoaJuridicaBuilder().Create();

            return this;
        }

        public override Pessoa Build()
        {
            var pessoa = new Pessoa(AggregateId, (EPessoaTipo) TipoId);
            pessoa.PessoaFisica = PessoaFisica.Build().PessoaFisica;
            pessoa.PessoaJuridica = PessoaJuridica.Build().PessoaJuridica;

            return pessoa;
        }
    }
}