using System;

namespace ToDo.WebApi.Dtos
{
    public class EmprestimoDto
    {
        public Guid UsuarioAggregateId { get; set; }
        public Guid LivroAggregateId { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucao { get; set; }
    }
}
