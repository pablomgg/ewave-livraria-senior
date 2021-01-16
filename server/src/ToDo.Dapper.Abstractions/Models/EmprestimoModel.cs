using System;

namespace ToDo.Dapper.Abstractions.Models
{
    public class EmprestimoModel
    {
        public Guid AggregateId { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime DataDevolucao { get; set; }
        public bool Ativo { get; set; }
        public string Titulo { get; set; }
        public int UsuarioId { get; set; }
        public UsuarioModel Usuario { get; set; }
        public int LivroId { get; set; }
        public LivroModel Livro { get; set; }
    }
}