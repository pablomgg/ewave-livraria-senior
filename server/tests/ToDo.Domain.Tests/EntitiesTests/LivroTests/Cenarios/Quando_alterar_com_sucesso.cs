using FluentAssertions;
using ToDo.Domain.Entities.Livro;
using ToDo.Infra.Tests.Builders.EntityBuilders;
using Xunit;

namespace ToDo.Domain.Tests.EntitiesTests.LivroTests.Cenarios
{
    public class Quando_alterar_com_sucesso
    {
        private readonly LivroBuilder _builder;
        private Livro Livro;

        public Quando_alterar_com_sucesso()
        {
            Livro = new LivroBuilder().Create().Build();
            _builder = new LivroBuilder().Create();
            Livro.Alterar(_builder.AutorId, _builder.GeneroId, _builder.Titulo, _builder.Capa, _builder.Sinopse, _builder.Paginas);
        } 

        [Fact]
        public void Deve_alterar_AutorId()
        {
            Livro.AutorId.Should().Be(_builder.AutorId);
        }

        [Fact]
        public void Deve_alterar_GeneroId()
        {
            Livro.GeneroId.Should().Be(_builder.GeneroId);
        }

        [Fact]
        public void Deve_alterar_Titulo()
        {
            Livro.Titulo.Should().Be(_builder.Titulo);
        }

        [Fact]
        public void Deve_alterar_Capa()
        {
            Livro.Capa.Should().Be(_builder.Capa);
        }

        [Fact]
        public void Deve_alterar_Sinopse()
        {
            Livro.Sinopse.Should().Be(_builder.Sinopse);
        }

        [Fact]
        public void Deve_alterar_Paginas()
        {
            Livro.Paginas.Should().Be(_builder.Paginas);
        }
    }
}