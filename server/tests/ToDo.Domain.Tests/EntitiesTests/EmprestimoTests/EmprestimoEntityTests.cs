using Bogus;
using FluentAssertions;
using System;
using ToDo.Domain.Entities.Emprestimo;
using ToDo.Domain.Exceptions;
using ToDo.Infra.Tests.Builders.EntityBuilders;
using Xunit;

namespace ToDo.Domain.Tests.EntitiesTests.EmprestimoTests
{
    public class EmprestimoEntityTests
    {
        private readonly EmprestimoBuilder _builder;
        private readonly Faker _faker;

        public EmprestimoEntityTests()
        {
            _builder = new EmprestimoBuilder().Create();
            _faker = new Faker();
        }

        [Fact]
        public void Quando_criar_com_sucesso()
        {
            var act = new Action(() => new Emprestimo(_builder.AggregateId, _builder.DataEmprestimo, _builder.UsuarioId, _builder.LivroId));
            act.Should().NotThrow();
        }

        [Fact]
        public void Quando_devolver_e_DataDevolucao_for_anterior_a_DataEmprestimo()
        {
            var act = new Action(() =>
            {
                var emprestimo = new Emprestimo(_builder.AggregateId, _builder.DataEmprestimo, _builder.UsuarioId, _builder.LivroId);
                emprestimo.Devolucao(_faker.Date.Between(new DateTime(2020, 05, 10), new DateTime(2020, 12, 10)));
            });
            act.Should().Throw<EmprestimoDataDevolucaoNaoPodeSerAnteriorQueDataEmprestimoException>();
        }
    }
}