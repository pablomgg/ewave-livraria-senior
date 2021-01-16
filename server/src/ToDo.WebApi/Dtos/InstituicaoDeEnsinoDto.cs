using System.Collections.Generic;

namespace ToDo.WebApi.Dtos
{
    public class InstituicaoDeEnsinoDto
    { 
        public PessoaJuridicaDto? PessoaJuridica { get; set; }
        public PessoaEnderecoDto Endereco { get; set; }
        public IList<PessoaTelefoneDto> Telefones { get; set; }
        public IList<PessoaEmailDto> Emails { get; set; }
    }
}
