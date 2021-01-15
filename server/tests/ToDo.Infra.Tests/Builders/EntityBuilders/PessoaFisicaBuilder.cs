using System;
using Bogus.Extensions.Brazil;
using ToDo.Domain.Entities.Pessoa;
using ToDo.Domain.Enums;
using ToDo.Domain.Models;
using ToDo.Infra.Tests.Core;

namespace ToDo.Infra.Tests.Builders.EntityBuilders
{
    public class PessoaFisicaBuilder : EntityBuilderBase<PessoaFisicaBuilder, Pessoa>
    {
        public Guid AggregateId { get; private set; }
        public int TipoId => (int)EPessoaTipo.PessoaFisica;
        public string Cpf { get; private set; }
        public string Nome { get; private set; }

        public override PessoaFisicaBuilder Create()
        {
            Cpf = Faker.Person.Cpf(false);
            Nome = Faker.Person.FullName.ToUpper();

            return this;
        }

        public override Pessoa Build() => new Pessoa(AggregateId, Cpf, Nome);
    }
}