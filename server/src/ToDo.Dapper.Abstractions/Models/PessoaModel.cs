using System;

namespace ToDo.Dapper.Abstractions.Models
{
    public class PessoaModel
    {
        public int Id { get; set; }
        public Guid AggregateId { get; set; }

        public PessoaFisicaModel PessoaFisica { get; set; }
        public PessoaJuridicaModel PessoaJuridica { get; set; }
        public PessoaEnderecoModel Endereco { get; set; }
    }
}