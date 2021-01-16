using FluentAssertions;
using ToDo.Domain.Entities.Emprestimo;
using ToDo.Infra.Tests.Builders.EntityBuilders;
using Xunit;

namespace ToDo.Domain.Tests.EntitiesTests.EmprestimoTests.Cenarios
{
    public class Quando_criar_com_sucesso
    {
        private readonly EmprestimoBuilder _builder;
        private Emprestimo Emprestimo;

        public Quando_criar_com_sucesso()
        { 
            _builder = new EmprestimoBuilder().Create();
            Emprestimo = _builder.Build();
        }

        [Fact]
        public void Deve_conter_AggregateId()
        {
            Emprestimo.AggregateId.Should().Be(_builder.AggregateId);
        }

        [Fact]
        public void Deve_conter_DataEmprestimo()
        {
            Emprestimo.DataEmprestimo.Should().Be(_builder.DataEmprestimo);
        }

        [Fact]
        public void Deve_conter_DataVencimento()
        {
            Emprestimo.DataVencimento.Should().Be(_builder.DataVencimento);
        }

        [Fact]
        public void Deve_conter_UsuarioId()
        {
            Emprestimo.UsuarioId.Should().Be(_builder.UsuarioId);
        }

        [Fact]
        public void Deve_conter_LivroId()
        {
            Emprestimo.LivroId.Should().Be(_builder.LivroId);
        }
    }
}