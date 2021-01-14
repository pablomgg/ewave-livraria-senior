using ToDo.Infra.Core;

namespace ToDo.Domain.Exceptions
{
    public class PessoaNaoEncontradaException : BusinessException
    {
        public PessoaNaoEncontradaException() : base("Pessoa não encontrada.") { }
    }

    public class PessoaCpfJaExisteException : BusinessException
    {
        public PessoaCpfJaExisteException() : base("Já existe um cadastro com esse cpf.") { }
    }

    public class PessoaCnpjJaExisteException : BusinessException
    {
        public PessoaCnpjJaExisteException() : base("Já existe um cadastro com esse cnpj.") { }
    }

    public class PessoaTipoNaoEncontradoException : BusinessException
    {
        public PessoaTipoNaoEncontradoException() : base("Tipo de pessoa não encontrada.") { }
    }

    public class PessoaTelefoneJaExisteException : BusinessException
    {
        public PessoaTelefoneJaExisteException() : base("O telefone já existe em nosso cadastro.") { }
    }

    public class PessoaTipoTelefoneNaoEncontradoException : BusinessException
    {
        public PessoaTipoTelefoneNaoEncontradoException() : base("Tipo de telefone não encontrado.") { }
    }

    public class PessoaNaoExisteTelefoneException : BusinessException
    {
        public PessoaNaoExisteTelefoneException() : base("Não existem telefones cadastrados.") { }
    }
    
    public class PessoaTelefoneNaoEncontradoException : BusinessException
    {
        public PessoaTelefoneNaoEncontradoException() : base("Telefone não encontrado.") { }
    }

    public class PessoaEmailJaExisteException : BusinessException
    {
        public PessoaEmailJaExisteException() : base("O e-mail já existe em nosso cadastro.") { }
    }

    public class PessoaTipoEmailNaoEncontradoException : BusinessException
    {
        public PessoaTipoEmailNaoEncontradoException() : base("Tipo de e-mail não encontrado.") { }
    }

    public class PessoaNaoExisteEmailException : BusinessException
    {
        public PessoaNaoExisteEmailException() : base("Não existem e-mails cadastrados.") { }
    }

    public class PessoaEmailNaoEncontradoException : BusinessException
    {
        public PessoaEmailNaoEncontradoException() : base("E-mail não encontrado.") { }
    }
}