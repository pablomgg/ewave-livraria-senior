using ToDo.Infra.Core;

namespace ToDo.Domain.Exceptions
{
    public class UsuarioNaoEncontradoException : BusinessException
    {
        public UsuarioNaoEncontradoException() : base("Usuario não encontrado.") { }
    }
}