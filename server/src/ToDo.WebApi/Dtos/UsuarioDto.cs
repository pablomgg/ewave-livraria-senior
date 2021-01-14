using System;
using System.Collections.Generic;

namespace ToDo.WebApi.Dtos
{
    public class UsuarioDto
    {
        public Guid InstituicaoDeEnsinoAggregateId { get; set; } 

        public PessoaFisicaDto? PessoaFisica { get; set; }
        public PessoaEnderecoDto Endereco { get; set; }
        public IList<PessoaTelefoneDto> Telefones { get; set; }
        public IList<PessoaEmailDto> Emails { get; set; }
    }
}
