using System;
using System.Threading.Tasks;
using ToDo.Domain.Entities.Emprestimo;
using ToDo.Domain.Entities.Livro;
using ToDo.Domain.Entities.Usuario;
using ToDo.Domain.Exceptions;
using ToDo.Domain.Services;
using ToDo.Infra.Core;
using ToDo.Infra.Extensions;

namespace ToDo.Services
{
    public class EmprestimoService : IEmprestimoService
    {
        private readonly IRepository _repository;

        public EmprestimoService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task CriarAsync(Guid aggregateId, Guid usuarioAggregateId, Guid livroAggregateId, DateTime dataEmprestimo)
        {
            Validar(aggregateId, usuarioAggregateId, livroAggregateId, dataEmprestimo);

            var usuario = await _repository.GetByAsync<Usuario>(usuarioAggregateId);
            if (usuario.IsNull()) throw new UsuarioNaoEncontradoException();

            var livro = await _repository.GetByAsync<Livro>(livroAggregateId);
            if (livro.IsNull()) throw new LivroNaoEncontradoException();
            if (!livro.Disponivel) throw new LivroNaoDisponivelException();

            var quantidadeEmprestimo = await _repository.CountAsync<Emprestimo>(x => x.Ativo && x.UsuarioId == usuario.Id);
            if (quantidadeEmprestimo >= Emprestimo.QuantidadeMaximaAtivaDeEmprestimo) throw new EmprestimoQuantidadeMaximaExcedidaException(Emprestimo.QuantidadeMaximaAtivaDeEmprestimo);

            livro.Indisponibilizar();
            await _repository.AddAsync(new Emprestimo(aggregateId, dataEmprestimo, usuario.Id, livro.Id));
        }

        public async Task DevolverAsync(Guid aggregateId, DateTime dataDevolucao)
        {
            ValidarDevolucao(aggregateId, dataDevolucao);

            var emprestimo = await _repository.GetByAsync<Emprestimo>(aggregateId);
            if (emprestimo.IsNull()) throw new EmprestimoNaoEncontradoException();

            emprestimo.Devolucao(dataDevolucao);
            emprestimo.Livro.Disponibilizar();
        }

        private void Validar(Guid aggregateId, Guid usuarioAggregateId, Guid livroAggregateId, DateTime dataEmprestimo)
        {
            if (aggregateId.IsEmpty()) throw new CampoNuloOuVazioOuMenorOuIgualZeroException(nameof(aggregateId), aggregateId.GetType());
            if (usuarioAggregateId.IsEmpty()) throw new CampoNuloOuVazioOuMenorOuIgualZeroException(nameof(usuarioAggregateId), usuarioAggregateId.GetType());
            if (livroAggregateId.IsEmpty()) throw new CampoNuloOuVazioOuMenorOuIgualZeroException(nameof(livroAggregateId), livroAggregateId.GetType());
            if (dataEmprestimo.IsInvalid()) throw new CampoNuloOuVazioOuMenorOuIgualZeroException(nameof(livroAggregateId), livroAggregateId.GetType());
        }

        private void ValidarDevolucao(Guid aggregateId, DateTime dataDevolucao)
        {
            if (aggregateId.IsEmpty()) throw new CampoNuloOuVazioOuMenorOuIgualZeroException(nameof(aggregateId), aggregateId.GetType());
            if (dataDevolucao.IsInvalid()) throw new CampoNuloOuVazioOuMenorOuIgualZeroException(nameof(dataDevolucao), dataDevolucao.GetType());
        }
    }
}