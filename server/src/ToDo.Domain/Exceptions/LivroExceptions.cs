using ToDo.Infra.Core;

namespace ToDo.Domain.Exceptions
{
    public class LivroNaoEncontradoException : BusinessException
    {
        public LivroNaoEncontradoException() : base("Livro não encontrado!") { }
    }

    public class LivroComTituloJaExistenteParaAutorSelecionadoException : BusinessException
    {
        public LivroComTituloJaExistenteParaAutorSelecionadoException() : base("Já existe um livro cadastrado com esse titulo para o autor(a) selecionado(a)!") { }
    }
}