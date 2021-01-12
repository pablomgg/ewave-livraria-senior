using System;
using ToDo.Infra.Core;

namespace ToDo.Domain.Entities
{
    public class Livro : Entity
    {
        public string Nome { get; set; }

        public Livro(string nome)
        {
            Nome = nome;
            AggregateId = Guid.NewGuid();
            DataCriacao = DateTime.Now;
        }
    }
}