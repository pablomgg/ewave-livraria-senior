using ToDo.Domain.Enums;
using ToDo.Domain.Exceptions;
using ToDo.Infra.Extensions;

namespace ToDo.Domain.Models
{
    public class PessoaMeioContatoTelefone
    {
        public int Id { get; set; }
        public int PessoaId { get; protected set; }
        public string Numero { get; private set; }
        public int TipoId { get; private set; }

        public virtual PessoaMeioContatoTelefoneTipo Tipo { get; protected set; }

        private const int TAMANHO_NUMERO = 11;

        public PessoaMeioContatoTelefone() { }

        public PessoaMeioContatoTelefone(string numero, EPessoaMeioContatoTelefoneTipo tipo)
        {
            Validar(numero);
             
            Numero = numero;
            TipoId = (int)tipo;
        }

        public void Alterar(string numero, EPessoaMeioContatoTelefoneTipo tipo)
        {
            Validar(numero);
                 
            Numero = numero;
            TipoId = (int)tipo;
        }

        private void Validar(string numero)
        {
            if(numero.IsNullOrWhiteSpaceAndTheSizeIsLargerThan(TAMANHO_NUMERO)) throw new CampoMaiorQuePermitidoException(nameof(numero), TAMANHO_NUMERO);
        }
    }
}