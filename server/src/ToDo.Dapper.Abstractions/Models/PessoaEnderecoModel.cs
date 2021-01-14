namespace ToDo.Dapper.Abstractions.Models
{
    public class PessoaEnderecoModel
    {
        public string Cep { get; set; }
        public string Bairro { get; set; }
        public string Logradouro { get; set; }
        public int EstadoId { get; set; }
        public string Estado { get; set; }
        public int CidadeId { get; set; }
        public string Cidade { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
    }
}