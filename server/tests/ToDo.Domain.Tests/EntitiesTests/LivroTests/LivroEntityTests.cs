using Bogus;
using FluentAssertions;
using System;
using ToDo.Domain.Entities.Livro;
using ToDo.Domain.Exceptions;
using ToDo.Infra.Tests.Builders.EntityBuilders;
using Xunit;

namespace ToDo.Domain.Tests.EntitiesTests.LivroTests
{
    public class LivroEntityTests
    {
        private readonly LivroBuilder _builder;
        private readonly Faker _faker;

        public LivroEntityTests()
        {
            _builder = new LivroBuilder().Create();
            _faker = new Faker();
        }

        [Fact]
        public void Quando_criar_com_sucesso()
        {
            var act = new Action(() => new Livro(_builder.AggregateId, _builder.AutorId, _builder.GeneroId, _builder.Titulo, _builder.Capa, _builder.Sinopse, _builder.Paginas));
            act.Should().NotThrow();
        }


        [Fact]
        public void Quando_criar_com_Titulo_maior_que_permitido()
        {
            var act = new Action(() => new Livro(_builder.AggregateId, _builder.AutorId, _builder.GeneroId, _faker.Random.AlphaNumeric(256), _builder.Capa, _builder.Sinopse, _builder.Paginas));
            act.Should().Throw<CampoMaiorQuePermitidoException>();
        }

        [Fact]
        public void Quando_criar_com_Capa_maior_que_permitido()
        {
            var act = new Action(() => new Livro(_builder.AggregateId, _builder.AutorId, _builder.GeneroId, _builder.Titulo, _faker.Random.AlphaNumeric(801), _builder.Sinopse, _builder.Paginas));
            act.Should().Throw<CampoMaiorQuePermitidoException>();
        }

        [Fact]
        public void Quando_criar_com_Sinopse_maior_que_permitido()
        {
            var act = new Action(() => new Livro(_builder.AggregateId, _builder.AutorId, _builder.GeneroId, _builder.Titulo, _builder.Capa, _faker.Random.AlphaNumeric(401), _builder.Paginas));
            act.Should().Throw<CampoMaiorQuePermitidoException>();
        }


        [Fact]
        public void Quando_alterar_com_sucesso()
        {
            var act = new Action(() =>
            {
                var livro = new Livro(_builder.AggregateId, _builder.AutorId, _builder.GeneroId, _builder.Titulo, _builder.Capa, _builder.Sinopse, _builder.Paginas);
                livro.Alterar(_builder.AutorId, _builder.GeneroId, _builder.Titulo, _builder.Capa, _builder.Sinopse, _builder.Paginas);
            });
            act.Should().NotThrow();
        }

        [Fact]
        public void Quando_alterar_com_Titulo_maior_que_permitido()
        {
            var act = new Action(() =>
            {
                var livro = new Livro(_builder.AggregateId, _builder.AutorId, _builder.GeneroId, _builder.Titulo, _builder.Capa, _builder.Sinopse, _builder.Paginas);
                livro.Alterar(_builder.AutorId, _builder.GeneroId, _faker.Random.AlphaNumeric(256), _builder.Capa, _builder.Sinopse, _builder.Paginas);
            });
            act.Should().Throw<CampoMaiorQuePermitidoException>();
        }

        [Fact]
        public void Quando_alterar_com_Capa_maior_que_permitido()
        {
            var act = new Action(() =>
            {
                var livro = new Livro(_builder.AggregateId, _builder.AutorId, _builder.GeneroId, _builder.Titulo, _builder.Capa, _builder.Sinopse, _builder.Paginas);
                livro.Alterar(_builder.AutorId, _builder.GeneroId, _builder.Titulo, _faker.Random.AlphaNumeric(801), _builder.Sinopse, _builder.Paginas);
            });
            act.Should().Throw<CampoMaiorQuePermitidoException>();
        }

        [Fact]
        public void Quando_alterar_com_Sinopse_maior_que_permitido()
        {
            var act = new Action(() =>
            {
                var livro = new Livro(_builder.AggregateId, _builder.AutorId, _builder.GeneroId, _builder.Titulo, _builder.Capa, _builder.Sinopse, _builder.Paginas);
                livro.Alterar(_builder.AutorId, _builder.GeneroId, _builder.Titulo, _builder.Capa, _faker.Random.AlphaNumeric(401), _builder.Paginas);
            });
            act.Should().Throw<CampoMaiorQuePermitidoException>();
        }
    }
}
