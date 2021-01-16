using ToDo.Infra.Core;

namespace ToDo.Domain.Exceptions
{
    public class InstituicaoDeEnsinoNaoEncontradaException : BusinessException
    {
        public InstituicaoDeEnsinoNaoEncontradaException() :base("Instituição de ensino não encontrada."){ }
    }
}