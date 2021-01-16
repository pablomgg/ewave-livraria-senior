using System;
using ToDo.Domain.Entities.Livro;
using ToDo.Infra.Tests.Core;

namespace ToDo.Infra.Tests.Builders.EntityBuilders
{
    public class LivroBuilder : EntityBuilderBase<LivroBuilder, Livro>
    {
        public Guid AggregateId { get; set; }
        public string Titulo { get; private set; }
        public string Sinopse { get; private set; }
        public int? Paginas { get; private set; }
        public string Capa { get; private set; }
        public bool Disponivel { get; private set; }
        public int AutorId { get; private set; } 
        public int GeneroId { get; private set; } 
         
        public override LivroBuilder Create()
        {
            AggregateId = Faker.Random.Guid();
            Titulo = Faker.Lorem.Letter(30);
            Sinopse = Faker.Lorem.Letter(180);
            Paginas = Faker.Random.Number(1, 999);
            Capa = Faker.Image.DataUri(200, 200);
            Disponivel = true;
            AutorId = Faker.Random.Number(1, 10);
            GeneroId = Faker.Random.Number(1, 10);

            return this;
        }

        public override Livro Build() => new Livro(AggregateId, AutorId, GeneroId, Titulo, Capa, Sinopse, Paginas);
    }
}