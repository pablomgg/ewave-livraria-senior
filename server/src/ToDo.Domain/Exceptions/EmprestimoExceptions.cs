using ToDo.Infra.Core;

namespace ToDo.Domain.Exceptions
{
    public class EmprestimoNaoEncontradoException : BusinessException
    {
        public EmprestimoNaoEncontradoException() : base("Emprestimo não encontrado.") { }
    }

    public class EmprestimoQuantidadeMaximaExcedidaException : BusinessException
    {
        public EmprestimoQuantidadeMaximaExcedidaException(int quantidade) : base($"Quantidade máxima({quantidade}) de emprestimos ativos ultrapassada. Devolva um livro para poder emprestar outro!") { }
    }

    public class EmprestimoDataDevolucaoNaoPodeSerAnteriorQueDataEmprestimoException : BusinessException
    {
        public EmprestimoDataDevolucaoNaoPodeSerAnteriorQueDataEmprestimoException() : base("Data de devolução não pode ser anterior a data de emprestimo!") { }
    }
}