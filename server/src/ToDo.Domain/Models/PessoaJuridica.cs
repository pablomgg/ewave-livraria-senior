using ToDo.Domain.Exceptions;
using ToDo.Infra.Extensions;

namespace ToDo.Domain.Models
{
    public class PessoaJuridica
    {
        public int PessoaId { get; protected set; }
        public string RazaoSocial { get; private set; }
        public string NomeFantasia { get; private set; }
        public string Cnpj { get; private set; }

        private const int TAMANHO_RAZAO = 80;
        private const int TAMANHO_FANTASIA = 100;

        public PessoaJuridica() { }

        public PessoaJuridica(string cnpj, string razaoSocial, string nomeFantasia)
        {
            Validar(razaoSocial, nomeFantasia);

            Cnpj = cnpj;
            RazaoSocial = razaoSocial;
            NomeFantasia = nomeFantasia;
        }

        public void Alterar(string cnpj, string razaoSocial, string nomeFantasia)
        {
            Validar(razaoSocial, nomeFantasia);

            Cnpj = cnpj;
            RazaoSocial = razaoSocial;
            NomeFantasia = nomeFantasia;
        }

        private void Validar(string razaoSocial, string nomeFantasia)
        {
            if (razaoSocial.IsNullOrWhiteSpaceAndTheSizeIsLargerThan(TAMANHO_RAZAO)) throw new CampoMaiorQuePermitidoException(nameof(razaoSocial), TAMANHO_RAZAO);
            if (nomeFantasia.IsNotNullOrWhiteSpace() && nomeFantasia.IsNullOrWhiteSpaceAndTheSizeIsLargerThan(TAMANHO_FANTASIA)) throw new CampoMaiorQuePermitidoException(nameof(nomeFantasia), TAMANHO_FANTASIA);
        }
    }
}