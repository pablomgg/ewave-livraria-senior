using System;
using System.Text.Json.Serialization;

namespace ToDo.Dapper.Abstractions.Models
{
    public class LivroModel
    {
        public Guid AggregateId { get; set; }
        public string Titulo { get; set; }
        public string Capa { get; set; }
        public string Sinopse { get; set; }
        public int Paginas { get; set; }
        public bool Disponivel { get; set; }
        public bool Ativo { get; set; }

        [JsonIgnore]
        public int AutorId { get; set; }
        public AutorModel Autor { get; set; }
        [JsonIgnore]
        public int GeneroId { get; set; }
        public GeneroModel Genero { get; set; }
    }
}