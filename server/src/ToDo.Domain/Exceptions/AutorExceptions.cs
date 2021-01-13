using System.Net;
using ToDo.Infra.Core;

namespace ToDo.Domain.Exceptions
{
    public class AutorNaoEncontradoException : BusinessException
    {
        public AutorNaoEncontradoException() : base("Autor(a) não encontrado(a).") { }
    }

    public class AutorJaExisteException : BusinessException
    {
        public AutorJaExisteException() : base("Autor(a) já cadastrado(a).") { }
    }
}