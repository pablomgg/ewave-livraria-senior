using System;

namespace ToDo.Dapper.Abstractions.Models
{
    public class LivroModel
    {
        public Guid AggregateId { get; set; }
        public Guid AutorAggregateId { get; set; }
        public Guid GeneroAggregateId { get; set; }
        public string Titulo { get; set; }
        public string Capa { get; set; }
        public string Sinopse { get; set; }
        public int Paginas { get; set; }
        public bool Disponivel { get; set; }
        public bool Ativo { get; set; }
    }
}