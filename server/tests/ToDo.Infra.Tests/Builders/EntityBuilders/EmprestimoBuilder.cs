using System;
using ToDo.Domain.Entities.Emprestimo;
using ToDo.Domain.Entities.Livro;
using ToDo.Infra.Tests.Core;

namespace ToDo.Infra.Tests.Builders.EntityBuilders
{
    public class EmprestimoBuilder : EntityBuilderBase<EmprestimoBuilder, Emprestimo>
    {
        public Guid AggregateId { get; private set; }
        public DateTime DataEmprestimo { get; private set; }
        public DateTime DataVencimento { get; private set; }
        public DateTime? DataDevolucao { get; private set; }
        public int UsuarioId { get; private set; }
        public int LivroId { get; private set; }

        public override EmprestimoBuilder Create()
        {
            AggregateId = Faker.Random.Guid();
            DataEmprestimo = new DateTime(2020,12,15);
            DataVencimento = DataEmprestimo.AddDays(30);
            DataDevolucao = new DateTime(2021, 01, 10);
            UsuarioId = Faker.Random.Number(1, 10);
            LivroId = Faker.Random.Number(1, 10);

            return this;
        }

        public override Emprestimo Build() => new Emprestimo(AggregateId, DataEmprestimo, UsuarioId, LivroId);
    }
}