using System;
using ToDo.Domain.Entities.Livro;
using ToDo.Infra.Tests.Core;

namespace ToDo.Infra.Tests.Builders.EntityBuilders
{
    public class GeneroBuilder : EntityBuilderBase<GeneroBuilder, Genero>
    {
        public Guid AggregateId { get; private set; }
        public string Nome { get; private set; }
        
        public override GeneroBuilder Create()
        {
            Nome = Faker.Person.FullName;

            return this;
        }

        public override Genero Build() => new Genero(AggregateId, Nome);
    }
}