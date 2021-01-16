using FluentAssertions;
using ToDo.Domain.Entities.Livro;
using ToDo.Infra.Tests.Builders.EntityBuilders;
using Xunit;

namespace ToDo.Domain.Tests.EntitiesTests.LivroTests.Cenarios
{
    public class Quando_criar_com_sucesso
    {
        private readonly LivroBuilder _builder;
        private Livro Livro;

        public Quando_criar_com_sucesso()
        {
            _builder = new LivroBuilder().Create();
            Livro = _builder.Build();
        }

        [Fact]
        public void Deve_conter_AggregateId()
        {
            Livro.AggregateId.Should().Be(_builder.AggregateId);
        }

        [Fact]
        public void Deve_conter_AutorId()
        {
            Livro.AutorId.Should().Be(_builder.AutorId);
        }

        [Fact]
        public void Deve_conter_GeneroId()
        {
            Livro.GeneroId.Should().Be(_builder.GeneroId);
        }

        [Fact]
        public void Deve_conter_Titulo()
        {
            Livro.Titulo.Should().Be(_builder.Titulo);
        }

        [Fact]
        public void Deve_conter_Capa()
        {
            Livro.Capa.Should().Be(_builder.Capa);
        }
    }
}