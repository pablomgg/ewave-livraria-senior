using System;

namespace ToDo.Dapper.Abstractions.Models
{
    public class AutorModel
    {
        public Guid AggregateId { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
    }
}