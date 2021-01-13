using ToDo.Domain.Exceptions;
using ToDo.Infra.Extensions;

namespace ToDo.Domain.Models
{
    public class PessoaFisica
    {
        public int PessoaId { get; protected set; }
        public string Nome { get; private set; }
        public string Cpf { get; private set; }

        private const int TAMANHO_NOME = 120;

        public PessoaFisica(string cpf, string nome)
        {
            Validar(nome);

            Cpf = cpf;
            Nome = nome;
        }

        public void Alterar(string cpf, string nome)
        {
            Validar(nome);

            Cpf = cpf;
            Nome = nome;
        }

        private void Validar(string nome)
        {
            if (nome.IsNullOrWhiteSpaceAndTheSizeIsLargerThan(TAMANHO_NOME)) throw new CampoMaiorQuePermitidoException(nameof(nome), TAMANHO_NOME);
        }
    }
}