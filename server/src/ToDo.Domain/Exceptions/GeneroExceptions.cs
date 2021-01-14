using ToDo.Infra.Core;

namespace ToDo.Domain.Exceptions
{
    public class GeneroNaoEncontradoException : BusinessException
    {
        public GeneroNaoEncontradoException() : base("Genero não encontrado.") { }
    }

    public class GeneroJaExisteException : BusinessException
    {
        public GeneroJaExisteException() : base("Genero já cadastrado.") { }
    }
}