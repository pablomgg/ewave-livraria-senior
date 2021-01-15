using ToDo.Domain.Exceptions;
using ToDo.Infra.Extensions;

namespace ToDo.Domain.Models
{
    public class PessoaEndereco
    {
        public int PessoaId { get; protected set; }
        public string Cep { get; private set; }
        public string Bairro { get; private set; }
        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }
        public int CidadeId { get; private set; }

        private const int TAMANHO_CEP = 8;
        private const int TAMANHO_LOGRADOURO = 180;
        private const int TAMANHO_NUMERO = 6;
        private const int TAMANHO_BAIRRO = 180;
        private const int TAMANHO_COMPLEMENTO = 255;

        public PessoaEndereco() { }

        public PessoaEndereco(string cep, string bairro, string logradouro, int cidadeId, string numero = null, string complemento = null)
        {
            Validar(cep, bairro, logradouro, numero, complemento);

            Cep = cep;
            Bairro = bairro;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            CidadeId = cidadeId;
        }

        public void Alterar(string cep, string bairro, string logradouro, int cidadeId, string numero = null, string complemento = null)
        {
            Validar(cep, bairro, logradouro, numero, complemento);

            Cep = cep;
            Bairro = bairro;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            CidadeId = cidadeId;
        }

        private void Validar(string cep, string bairro, string logradouro, string numero = null, string complemento = null)
        {
            if (cep.IsNullOrWhiteSpaceAndTheSizeIsLargerThan(TAMANHO_CEP)) throw new CampoMaiorQuePermitidoException(nameof(cep), TAMANHO_CEP);
            if (bairro.IsNullOrWhiteSpaceAndTheSizeIsLargerThan(TAMANHO_BAIRRO)) throw new CampoMaiorQuePermitidoException(nameof(bairro), TAMANHO_BAIRRO);
            if (logradouro.IsNullOrWhiteSpaceAndTheSizeIsLargerThan(TAMANHO_LOGRADOURO)) throw new CampoMaiorQuePermitidoException(nameof(logradouro), TAMANHO_LOGRADOURO);
            if (numero.IsNotNullOrWhiteSpace() && numero.IsNullOrWhiteSpaceAndTheSizeIsLargerThan(TAMANHO_NUMERO)) throw new CampoMaiorQuePermitidoException(nameof(numero), TAMANHO_NUMERO);
            if (complemento.IsNotNullOrWhiteSpace() && complemento.IsNullOrWhiteSpaceAndTheSizeIsLargerThan(TAMANHO_COMPLEMENTO)) throw new CampoMaiorQuePermitidoException(nameof(complemento), TAMANHO_COMPLEMENTO);
        }
    }
}