using System.ComponentModel;

namespace ToDo.Domain.Enums
{
    public enum EPessoaTipo
    {
        [Description("Pessoa Física")]
        PessoaFisica = 1,

        [Description("Pessoa Jurídica")]
        PessoaJuridica = 2
    }
}