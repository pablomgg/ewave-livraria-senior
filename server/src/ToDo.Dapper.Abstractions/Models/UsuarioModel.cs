using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ToDo.Dapper.Abstractions.Models
{
    public class UsuarioModel
    {
        public Guid AggregateId { get; set; }
        public Guid PessoaAggregateId { get; set; }
        public Guid InstituicaoDeEnsinoAggregateId { get; set; }
        public bool Ativo { get; set; }
        [JsonIgnore]
        public int PessoaId { get; set; }

        public PessoaFisicaModel PessoaFisica { get; set; }
        public PessoaEnderecoModel Endereco { get; set; }
        public IEnumerable<PessoaTelefoneModel> Telefones { get; set; }
        public IEnumerable<PessoaEmailModel> Emails { get; set; }
    }
}