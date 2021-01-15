using Bogus;

namespace ToDo.Infra.Tests.Core
{
    public abstract class ModelBuilderBase<TBuilder, TModel> : ILocaleAware
    where TBuilder : class, new()
    where TModel : class, new()
    {
        protected Faker Faker { get; set; }
        public string Locale { get; set; }

        protected ModelBuilderBase()
        {
            Locale = "pt_BR";
            Faker = new Faker(Locale);
        }

        public abstract TBuilder Create();
        public abstract TModel Build();
    }
}