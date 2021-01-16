using Bogus;
using ToDo.Infra.Core;

namespace ToDo.Infra.Tests.Core
{
    public abstract class EntityBuilderBase<TBuilder, TEntity> : ILocaleAware
    where TBuilder : class, new()
    where TEntity : Entity, new()
    {
        protected Faker Faker { get; set; }
        public string Locale { get; set; }

        protected EntityBuilderBase()
        {
            Locale = "pt_BR";
            Faker = new Faker(Locale);
        }

        public abstract TBuilder Create();
        public abstract TEntity Build();
    }
}