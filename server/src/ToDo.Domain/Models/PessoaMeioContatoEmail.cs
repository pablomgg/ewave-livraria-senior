using ToDo.Domain.Enums;
using ToDo.Domain.Exceptions;
using ToDo.Infra.Extensions;

namespace ToDo.Domain.Models
{
    public class PessoaMeioContatoEmail
    {
        public int Id { get; set; }
        public int PessoaId { get; private set; }
        public string Endereco { get; private set; }
        public int TipoId { get; private set; }

        public virtual PessoaMeioContatoEmailTipo Tipo { get; protected set; }

        private const int TAMANHO_ENDERECO = 180;

        public PessoaMeioContatoEmail() { }

        public PessoaMeioContatoEmail(string endereco, EPessoaMeioContatoEmailTipo tipo)
        {
            Validar(endereco);

            Endereco = endereco;
            TipoId = (int)tipo;
        }

        public void Alterar(string endereco, EPessoaMeioContatoEmailTipo tipo)
        {
            Validar(endereco);

            Endereco = endereco;
            TipoId = (int)tipo;
        }

        private void Validar(string endereco)
        {
            if (endereco.IsNullOrWhiteSpaceAndTheSizeIsLargerThan(TAMANHO_ENDERECO)) throw new CampoMaiorQuePermitidoException(nameof(endereco), TAMANHO_ENDERECO);
        }
    }
}