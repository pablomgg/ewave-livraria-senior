namespace ToDo.WebApi.Dtos
{
    public class PessoaEnderecoDto
    {
        public string Cep { get; set; }
        public string Bairro { get; set; }
        public string Logradouro { get; set; }
        public int CidadeId { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
    }
}
