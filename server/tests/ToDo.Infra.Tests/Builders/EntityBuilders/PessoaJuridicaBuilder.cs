using System;
using Bogus.Extensions.Brazil;
using ToDo.Domain.Entities.Pessoa;
using ToDo.Domain.Enums;
using ToDo.Domain.Models;
using ToDo.Infra.Tests.Core;

namespace ToDo.Infra.Tests.Builders.EntityBuilders
{
    public class PessoaJuridicaBuilder : EntityBuilderBase<PessoaJuridicaBuilder, Pessoa>
    {
        public Guid AggregateId { get; private set; }
        public int TipoId => (int)EPessoaTipo.PessoaJuridica;
        public string Cnpj { get; private set; }
        public string RazaoSocial { get; private set; }
        public string NomeFantasia { get; private set; }

        public override PessoaJuridicaBuilder Create()
        {
            AggregateId = Faker.Random.Guid();
            Cnpj = Faker.Company.Cnpj(false);
            RazaoSocial = Faker.Company.CompanyName(1);
            NomeFantasia = Faker.Company.CompanySuffix();

            return this;
        }

        public override Pessoa Build() => new Pessoa(AggregateId, Cnpj, RazaoSocial, NomeFantasia);
    }
}