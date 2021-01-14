using System;
using ToDo.Infra.Core;
using ToDo.Infra.Extensions;

namespace ToDo.Domain.Entities.Emprestimo
{
    public class Emprestimo : Entity
    {
        public DateTime DataEmprestimo { get; private set; }
        public DateTime DataVencimento { get; private set; }
        public DateTime? DataDevolucao { get; private set; }
        public DateTime DataRestricaoExpirar { get; private set; }

        public int UsuarioId { get; set; }
        public virtual Usuario.Usuario Usuario { get; set; }

        public int LivroId { get; set; }
        public virtual Livro.Livro Livro { get; set; }
        public static int QuantidadeMaximaAtivaDeEmprestimo => 2;

        public Emprestimo() { }

        public Emprestimo(Guid aggregateId, DateTime dataEmprestimo, int usuarioId, int livroId)
        {
            AggregateId = aggregateId;
            DataEmprestimo = dataEmprestimo;
            DataVencimento = dataEmprestimo.AddDays(30);
            UsuarioId = usuarioId;
            LivroId = livroId;
            DataCriacao = DateTime.Now;
            Ativo = true;
        }

        public void Devolucao(DateTime data)
        {
            DataDevolucao = data;
            Ativo = false; 
        }
    }
}