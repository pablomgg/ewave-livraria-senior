using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDo.WebApi.Dtos
{
    public class InstituicaoDeEnsinoDto
    { 
        public bool Ativo { get; set; }

        public PessoaJuridicaDto? PessoaJuridica { get; set; }
        public PessoaEnderecoDto Endereco { get; set; }
        public IList<PessoaTelefoneDto> Telefones { get; set; }
        public IList<PessoaEmailDto> Emails { get; set; }
    }
}
