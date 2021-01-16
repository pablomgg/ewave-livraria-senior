using System;
using ToDo.Domain.Entities.Livro;
using ToDo.Infra.Tests.Core;

namespace ToDo.Infra.Tests.Builders.EntityBuilders
{
    public class AutorBuilder : EntityBuilderBase<AutorBuilder, Autor>
    {
        public Guid AggregateId { get; set; }
        public string Nome { get; private set; }

        public override AutorBuilder Create()
        {
            Nome = Faker.Person.FullName;

            return this;
        }

        public override Autor Build() => new Autor(AggregateId, Nome);
    }
}